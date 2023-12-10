using SupanthaPaul;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkTrigger : MonoBehaviour
{
    public PlayerController playerController;
    public Transform playerTransform;
    public float scalerSmallValue = 0.95f;
    public float scalerLargeValue = 1.05f;
    private float playerScaleX;
    private float playerScaleY;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //playerScaleX = playerTransform.localScale.x;
       //playerScaleY = playerTransform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerController.m_facingRight==true && playerController.canWalkBackground ==true)
        {
            Vector2 smallScale = playerTransform.localScale * scalerSmallValue;
            playerTransform.localScale = smallScale;
        }
        if (other.CompareTag("Player") && playerController.m_facingRight == false && playerController.canWalkBackground == true)
        {
            Vector2 smallScale = playerTransform.localScale * scalerLargeValue;
            playerTransform.localScale = smallScale;
        }
    }
}
