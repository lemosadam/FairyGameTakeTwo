using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class DoorScript : MonoBehaviour
{ 

    // Reference to the player GameObject
    public GameObject player;

// Flag to indicate whether the player is at the door
    public bool isPlayerAtDoor = false;
    public GameObject linkedDoor;
    public GameObject followCamera;
    private bool doorEnter = false;

    public static event Action DoorBlocked; //UI should listen to this to display go talk to NPC message
    public static event Action UseDoor;


    void Start()
    {
    // Get the player GameObject
    player = GameObject.FindGameObjectWithTag("Player");
    followCamera = GameObject.Find("Follow Camera");

        DialogueManager.OnLetterActive += TriggerDoor;
    
    }

void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject == player)
    {
        // Player is at the door
        isPlayerAtDoor = true;
        Debug.Log("Player is at the door");
    }
}

void OnTriggerExit2D(Collider2D other)
{
    if (other.gameObject == player)
    {
        // Player has left the door
        isPlayerAtDoor = false;
        Debug.Log("Player left the door");
    }
}

void Update()
{
    // Check for user input or any other conditions to interact with the door
    if (isPlayerAtDoor && Input.GetKeyDown(KeyCode.F) && doorEnter == true)
    {
        // Perform door interaction logic here
        Debug.Log("Interacting with the door");
            Teleport();
    }

        if (isPlayerAtDoor && Input.GetKeyDown(KeyCode.F) && doorEnter == false)
        {
            Debug.Log("You should talk to the NPC first");
            DoorBlocked();
        }
}
    public void Teleport()
    {
        followCamera.transform.position = linkedDoor.transform.position;
        player.transform.position = linkedDoor.transform.position;
        UseDoor();
        
    }

    void TriggerDoor()
    {
        doorEnter = true;
    }




}