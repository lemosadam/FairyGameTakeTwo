﻿using UnityEngine;

namespace SupanthaPaul
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float speed;
		[Header("Jumping")]
        //[SerializeField] public bool canjump;
        [SerializeField] private float jumpForce;
		[SerializeField] private float fallMultiplier;
		[SerializeField] private Transform groundCheck;
		[SerializeField] private float groundCheckRadius;
		[SerializeField] private LayerMask whatIsGround;
        [SerializeField] private LayerMask whatIsRealGround;
        [SerializeField] public LayerMask whatIsMagicGround;
        public int extraJumpModifier = -1;
		[SerializeField] private GameObject jumpEffect;
		[Header("Dashing")]
		[SerializeField] public bool canDash = false;
		[SerializeField] private float dashSpeed = 30f;
		[Tooltip("Amount of time (in seconds) the player will be in the dashing speed")]
		[SerializeField] private float startDashTime = 0.1f;
		[Tooltip("Time (in seconds) between dashes")]
		[SerializeField] private float dashCooldown = 0.2f;
		[SerializeField] private GameObject dashEffect;

		// Access needed for handling animation in Player script and other uses
		[SerializeField] public bool isGrounded;
		[HideInInspector] public float moveInput;
		[HideInInspector] public bool canMove = true;
		[HideInInspector] public bool isDashing = false;
		[HideInInspector] public bool actuallyWallGrabbing = false;
		// controls whether this instance is currently playable or not
		[HideInInspector] public bool isCurrentlyPlayable = false;

		[Header("Wall grab & jump")]
		[Tooltip("Right offset of the wall detection sphere")]
		public Vector2 grabRightOffset = new Vector2(0.16f, 0f);
		public Vector2 grabLeftOffset = new Vector2(-0.16f, 0f);
		public float grabCheckRadius = 0.24f;
		public float slideSpeed = 2.5f;
		public Vector2 wallJumpForce = new Vector2(10.5f, 18f);
		public Vector2 wallClimbForce = new Vector2(4f, 14f);

		private Rigidbody2D m_rb;
		private ParticleSystem m_dustParticle;
		public bool m_facingRight = true; //made public for Escher Stair
		private bool m_isUpright = true;
		private readonly float m_groundedRememberTime = 0.25f;
		private float m_groundedRemember = 0f;
		public int m_extraJumps;
		private float m_extraJumpForce;
		private float m_dashTime;
		private bool m_hasDashedInAir = false;
		private bool m_onWall = false;
		private bool m_onRightWall = false;
		private bool m_onLeftWall = false;
		private bool m_wallGrabbing = false;
		private readonly float m_wallStickTime = 0.25f;
		private float m_wallStick = 0f;
		private bool m_wallJumping = false;
		private float m_dashCooldown;
		private bool m_gravityInverted; //bool to check if gravity is inverted for inverse jump power
        float invertedJumpForce;

        // 0 -> none, 1 -> right, -1 -> left
        private int m_onWallSide = 0;
		private int m_playerSide = 1;

		public bool canWalkBackground = false;
		public Vector3 currentPlayerSize;
		

		void Start()
		{
			currentPlayerSize = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
			// create pools for particles
			PoolManager.instance.CreatePool(dashEffect, 2);
			PoolManager.instance.CreatePool(jumpEffect, 2);

			// if it's the player, make this instance currently playable
			if (transform.CompareTag("Player"))
				isCurrentlyPlayable = true;

			//m_extraJumps = extraJumpCount;
			m_dashTime = startDashTime;
			m_dashCooldown = dashCooldown;
			m_extraJumpForce = jumpForce * 0.7f;

			m_rb = GetComponent<Rigidbody2D>();
			m_dustParticle = GetComponentInChildren<ParticleSystem>();


           m_gravityInverted = false;

            ConceptCollectionNotifier.OnConceptCollected += ConceptAddedToInventory;
            ConceptCollectionNotifier.OnConceptPurchased += ConceptAddedToInventory;
			ConceptCollectionNotifier.OnConceptSold += ConceptRemovedFromInventory;
			GravityInverter.OnGravityToggled += InvertGravity;
			BackTeleporter.OnPlayerTeleportedBack += BackgroundAsGround;
            FrontTeleporter.OnPlayerTeleportedFront += RevertGround;
			PositionResetterEscher.OnResetPosition += RevertGround;
            //GravityInverter.OnGravityToggled += RevertGravity;
        }

		private void FixedUpdate()
		{
			// check if grounded
			isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
			Debug.Log("Player is Grounded");
			if (!isGrounded)
			{
				Debug.Log("Player is not grounded");
			}
			var position = transform.position;
			// check if on wall
			m_onWall = Physics2D.OverlapCircle((Vector2)position + grabRightOffset, grabCheckRadius, whatIsGround)
			          || Physics2D.OverlapCircle((Vector2)position + grabLeftOffset, grabCheckRadius, whatIsGround);
			m_onRightWall = Physics2D.OverlapCircle((Vector2)position + grabRightOffset, grabCheckRadius, whatIsGround);
			m_onLeftWall = Physics2D.OverlapCircle((Vector2)position + grabLeftOffset, grabCheckRadius, whatIsGround);

			// calculate player and wall sides as integers
			CalculateSides();

			if((m_wallGrabbing || isGrounded) && m_wallJumping)
			{
				m_wallJumping = false;
			}
			// if this instance is currently playable
			if (isCurrentlyPlayable)
			{
				// horizontal movement
				if(m_wallJumping)
				{
					m_rb.velocity = Vector2.Lerp(m_rb.velocity, (new Vector2(moveInput * speed, m_rb.velocity.y)), 1.5f * Time.fixedDeltaTime);
				}
				else
				{
					if(canMove && !m_wallGrabbing)
						m_rb.velocity = new Vector2(moveInput * speed, m_rb.velocity.y);
					else if(!canMove)
						m_rb.velocity = new Vector2(0f, m_rb.velocity.y);
				}
				// better jump physics
				if (m_rb.velocity.y < 0f)
				{
					m_rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
				}

				// Flipping
				if (!m_facingRight && moveInput > 0f)
					Flip();
				else if (m_facingRight && moveInput < 0f)
					Flip();

				// Dashing logic
				
                    if (isDashing)
                    {
                        if (m_dashTime <= 0f)
                        {
                            isDashing = false;
                            m_dashCooldown = dashCooldown;
                            m_dashTime = startDashTime;
                            m_rb.velocity = Vector2.zero;
                        }
                        else
                        {
                            m_dashTime -= Time.deltaTime;
                            if (m_facingRight)
                                m_rb.velocity = Vector2.right * dashSpeed;
                            else
                                m_rb.velocity = Vector2.left * dashSpeed;
                        }
                    }
                				

				// wall grab
				if(m_onWall && !isGrounded && m_rb.velocity.y <= 0f && m_playerSide == m_onWallSide)
				{
					actuallyWallGrabbing = true;    // for animation
					m_wallGrabbing = true;
					m_rb.velocity = new Vector2(moveInput * speed, -slideSpeed);
					m_wallStick = m_wallStickTime;
				} else
				{
					m_wallStick -= Time.deltaTime;
					actuallyWallGrabbing = false;
					if (m_wallStick <= 0f)
						m_wallGrabbing = false;
				}
				if (m_wallGrabbing && isGrounded)
					m_wallGrabbing = false;

				// enable/disable dust particles
				float playerVelocityMag = m_rb.velocity.sqrMagnitude;
				if(m_dustParticle.isPlaying && playerVelocityMag == 0f)
				{
					m_dustParticle.Stop();
				}
				else if(!m_dustParticle.isPlaying && playerVelocityMag > 0f)
				{
					m_dustParticle.Play();
				}

			}
		}

		private void Update()
		{
			// horizontal input
			moveInput = InputSystem.HorizontalRaw();

			if (isGrounded)
			{
				m_extraJumps = 1 + extraJumpModifier;
			}

			// grounded remember offset (for more responsive jump)
			m_groundedRemember -= Time.deltaTime;
			if (isGrounded)
				m_groundedRemember = m_groundedRememberTime;

			if (!isCurrentlyPlayable) return;
			// if not currently dashing and hasn't already dashed in air once
			if (!isDashing && !m_hasDashedInAir && m_dashCooldown <= 0f)
			{
				// dash input (left shift)
				if (InputSystem.Dash())
				{
					isDashing = true;
					// dash effect
					PoolManager.instance.ReuseObject(dashEffect, transform.position, Quaternion.identity);
					// if player in air while dashing
					if(!isGrounded)
					{
						m_hasDashedInAir = true;
					}
					// dash logic is in FixedUpdate
				}
			}
			m_dashCooldown -= Time.deltaTime;
			
			// if has dashed in air once but now grounded
			if (m_hasDashedInAir && isGrounded)
				m_hasDashedInAir = false;
			
			// Jumping
			if(InputSystem.Jump() && m_extraJumps > 0 && !isGrounded && !m_wallGrabbing)	// extra jumping
			{
				Debug.Log("double jumping");
				m_rb.velocity = new Vector2(m_rb.velocity.x, m_extraJumpForce); ;
				m_extraJumps--;
				// jumpEffect
				PoolManager.instance.ReuseObject(jumpEffect, groundCheck.position, Quaternion.identity);
			}
			else if(InputSystem.Jump() && (isGrounded || m_groundedRemember > 0f))	// normal single jumping
			{
				Debug.Log("single jumping");
				m_rb.velocity = new Vector2(m_rb.velocity.x, jumpForce);
				// jumpEffect
				PoolManager.instance.ReuseObject(jumpEffect, groundCheck.position, Quaternion.identity);
			}
			else if(InputSystem.Jump() && m_wallGrabbing && moveInput!=m_onWallSide )		// wall jumping off the wall
			{
				m_wallGrabbing = false;
				m_wallJumping = true;
				Debug.Log("Wall jumped");
				if (m_playerSide == m_onWallSide)
					Flip();
				m_rb.AddForce(new Vector2(-m_onWallSide * wallJumpForce.x, wallJumpForce.y), ForceMode2D.Impulse);
			}
			else if(InputSystem.Jump() && m_wallGrabbing && moveInput != 0 && (moveInput == m_onWallSide))      // wall climbing jump
			{
				m_wallGrabbing = false;
				m_wallJumping = true;
				Debug.Log("Wall climbed");
				if (m_playerSide == m_onWallSide)
					Flip();
				m_rb.AddForce(new Vector2(-m_onWallSide * wallClimbForce.x, wallClimbForce.y), ForceMode2D.Impulse);
			}

        }

		void Flip()
		{
			m_facingRight = !m_facingRight;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}

		void Invert()
		{
			m_isUpright = !m_isUpright;
            Vector3 scale = transform.localScale;
			jumpForce = jumpForce * -1;
            scale.y *= -1;
            transform.localScale = scale;
        }

		void CalculateSides()
		{
			if (m_onRightWall)
				m_onWallSide = 1;
			else if (m_onLeftWall)
				m_onWallSide = -1;
			else
				m_onWallSide = 0;

			if (m_facingRight)
				m_playerSide = 1;
			else
				m_playerSide = -1;
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
			Gizmos.DrawWireSphere((Vector2)transform.position + grabRightOffset, grabCheckRadius);
			Gizmos.DrawWireSphere((Vector2)transform.position + grabLeftOffset, grabCheckRadius);
		}

		//shrink player, double jump
		private void ConceptAddedToInventory(GameObject concept)
		{
			if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "shrink")
			{
				currentPlayerSize = gameObject.transform.localScale / 1.75f;
				gameObject.transform.localScale = currentPlayerSize;
			}

            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump")
            {
				//m_extraJumps++;
				extraJumpModifier = 0;
                Debug.Log("Extra jumps: " + m_extraJumps);

            }
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "inverse jump")
            {
				speed = speed - 1.5f;
            }
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "walk background")
            {
				canWalkBackground = true;
            }
        }

        private void ConceptRemovedFromInventory(GameObject concept)
        {
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "shrink")
            {
                currentPlayerSize = gameObject.transform.localScale * 1.75f;
                gameObject.transform.localScale = currentPlayerSize;
            }
            
			if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump")
            {
				//m_extraJumps--;
				extraJumpModifier = -1;
				Debug.Log("Extra jumps: " + m_extraJumps);

            }
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "walk background")
            {
				canWalkBackground = false;
            }
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "inverse jump")
            {
				speed = speed + 1.5f;
            }

        }

		private void InvertGravity()
		{
            m_rb.gravityScale = m_rb.gravityScale * -1;
            m_gravityInverted = !m_gravityInverted;
            Invert();
            Debug.Log("Gravity inverted?" + m_rb.gravityScale);
            
		}

		private void BackgroundAsGround(GameObject player)
		{
			whatIsGround = whatIsMagicGround;
		}

        private void RevertGround(GameObject player)
        {
			whatIsGround = whatIsRealGround;
        }

        /*private void RevertGravity()
        {
            if (m_gravityInverted == true)
            {
                m_rb.gravityScale = m_rb.gravityScale * -1;
                m_gravityInverted = !m_gravityInverted;
                Invert();
                Debug.Log("Gravity inverted?" + m_rb.gravityScale);
            }
        }*/

    }
}
