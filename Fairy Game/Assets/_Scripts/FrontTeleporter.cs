using SupanthaPaul;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontTeleporter : MonoBehaviour
{

    // Reference to the player GameObject
    public GameObject player;

    // Flag to indicate whether the player is at the door
    public bool isPlayerAtDoor = false;
    public GameObject linkedDoor;
    public GameObject followCamera;
    private bool doorEnter = false;

    public static event Action OnMagicDoorBlocked; //UI should listen to this to display go talk to NPC message
    public static event Action UseDoor;
    public static event Action<GameObject> OnPlayerTeleportedFront;


    public PlayerController playerController;

    void Start()
    {
        // Get the player GameObject
        player = GameObject.FindGameObjectWithTag("Player");
        followCamera = GameObject.Find("Follow Camera");

        DialogueManager.OnLetterActive += TriggerDoor;

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            // Player is at the door
            isPlayerAtDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            // Player has left the door
            isPlayerAtDoor = false;
        }
    }

    void Update()
    {
        // Check for user input or any other conditions to interact with the door
        if (isPlayerAtDoor && Input.GetKeyDown(KeyCode.F) && playerController.canWalkBackground)
        {
            // Perform door interaction logic here
            Teleport();
        }

        if (isPlayerAtDoor && Input.GetKeyDown(KeyCode.F) && playerController.canWalkBackground == false)
        {
            Debug.Log("Magic door is blocked");
            OnMagicDoorBlocked();
        }
    }
    public void Teleport()
    {
        followCamera.transform.position = linkedDoor.transform.position;
        player.transform.position = linkedDoor.transform.position;
        OnPlayerTeleportedFront(player);

    }

    void TriggerDoor()
    {
        doorEnter = true;
    }
    //public Transform backTeleporterTransform;
    //public PlayerController playerController;
    //private float xOffset=1.5f;

    //public static event Action<GameObject> OnPlayerTeleportedFront;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player") && playerController.canWalkBackground == true)
    //    {
    //        Debug.Log("Player entered portal");
    //        Transform playerTransform = other.transform;
    //        Vector2 offsetPosition = new Vector2(backTeleporterTransform.position.x - xOffset, backTeleporterTransform.position.y);
    //        playerTransform.position = offsetPosition;
    //        OnPlayerTeleportedFront(other.gameObject);
    //    }
    //}
}
