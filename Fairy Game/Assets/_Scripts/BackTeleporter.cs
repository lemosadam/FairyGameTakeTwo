using SupanthaPaul;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTeleporter : MonoBehaviour
{
    public Transform frontTeleporterTransform;
    public PlayerController playerController;
    private float xOffset=1.5f;

    public static event Action<GameObject> OnPlayerTeleportedBack;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && playerController.canWalkBackground == true)
        {
            Debug.Log("Player entered portal");
            Transform playerTransform = other.transform;
            Vector2 offsetPosition = new Vector2(frontTeleporterTransform.position.x - xOffset, frontTeleporterTransform.position.y);
            playerTransform.position = offsetPosition;
            OnPlayerTeleportedBack(other.gameObject);
        }
    }
}
