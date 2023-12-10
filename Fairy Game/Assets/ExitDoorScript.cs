using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorScript : MonoBehaviour
{

    public GameObject player;
    public bool isPlayerAtDoor = false;
    public GameObject exitUIPanel;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAtDoor && Input.GetKeyDown(KeyCode.F))
        {
            OpenExitPanel();
        }
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

    void OpenExitPanel()
    {
        exitUIPanel.SetActive(true);
    }
}
