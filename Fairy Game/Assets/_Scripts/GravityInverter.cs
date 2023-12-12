using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GravityInverter : MonoBehaviour
{
    public static event Action OnGravityToggled; 
    public GameObject player;
    public GameObject followCamera;
    private bool hasCrushingHeartbreak = false;

    // Start is called before the first frame update
    void Start()
    {
        //ConceptCollectionNotifier.OnConceptCollected += ToggleGravityOn;
        ConceptCollectionNotifier.OnConceptPurchased += ToggleGravityOn;
        ConceptCollectionNotifier.OnConceptSold += ToggleGravityOff;

        player = GameObject.FindGameObjectWithTag("Player");
        followCamera = GameObject.Find("Follow Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && hasCrushingHeartbreak == false)
        {
            Debug.Log("Collided");
            OnGravityToggled();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player && hasCrushingHeartbreak == false)
        {
            Debug.Log("Left Anti gravity");
            OnGravityToggled();
        }
    }

    void ToggleGravityOn(GameObject concept)
    {
        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "inverse jump")
        {
            hasCrushingHeartbreak = true;
            Debug.Log(hasCrushingHeartbreak);
        }
    }

    void ToggleGravityOff(GameObject concept)
    {
        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "inverse jump")
        {
            hasCrushingHeartbreak = false;
            Debug.Log(hasCrushingHeartbreak);
        }
        
    }

}
