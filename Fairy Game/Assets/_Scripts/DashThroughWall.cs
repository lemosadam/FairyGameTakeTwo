using SupanthaPaul;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashThroughWall : MonoBehaviour
{
    //public PlayerController playerController;
    public List<Collider2D> entryColliders;

    public Collider2D wallCollider;
    public float distanceThreshold = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distanceToWall = Vector2.Distance(player.transform.position, transform.position);

            PlayerController playerController = player.GetComponent<PlayerController>();
            if (distanceToWall <= distanceThreshold && playerController.isDashing)
            {
                wallCollider.enabled = false;
            }
            else
            {
                wallCollider.enabled = true;
            }
        }
    }


}
