using SupanthaPaul;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BackTeleporter : MonoBehaviour
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
    public static event Action<GameObject> OnPlayerTeleportedBack;


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
        OnPlayerTeleportedBack(player);

    }

    void TriggerDoor()
    {
        doorEnter = true;
    }
    //public GameObject player;
    //public Transform frontTeleporterTransform;
    //public PlayerController playerController;
    //private float xOffset=1.5f;

    //public bool isPlayerAtDoor;

    //public static event Action<GameObject> OnPlayerTeleportedBack;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    isPlayerAtDoor = false;
    //    player = GameObject.FindWithTag("Player");
    //    playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (isPlayerAtDoor && playerController.canWalkBackground && Input.GetKeyDown(KeyCode.F))
    //    {
    //        Debug.Log("Player entered near/far door");
    //        Teleport();
    //    }
    //}


    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        // Player is at the door
    //        isPlayerAtDoor = true;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        // Player has left the door
    //        isPlayerAtDoor = false;
    //    }
    //}

    //private void Teleport()
    //{
    //    Transform playerTransform = player.transform;
    //    Vector2 offsetPosition = new Vector2(frontTeleporterTransform.position.x - xOffset, frontTeleporterTransform.position.y);
    //    playerTransform.position = offsetPosition;
    //    OnPlayerTeleportedBack(player.gameObject);
    //    followCamera.transform.position = linkedDoor.transform.position;
    //    player.transform.position = linkedDoor.transform.position;
    //    UseDoor();
    //}

}
