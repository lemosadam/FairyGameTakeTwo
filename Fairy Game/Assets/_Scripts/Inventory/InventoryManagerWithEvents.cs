using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryManagerWithEvents : MonoBehaviour
{
    public Dictionary<string,GameObject> concepts = new Dictionary<string,GameObject>();


    public bool letterCompleted = false;
    public static event Action OnLetterCompleted;
    public static event Action OnSingleJumpInInventory;
    public static event Action OnDoubleJumpInInventory;


    // Start is called before the first frame update
    void Start()
    {
        ConceptCollectionNotifier.OnConceptCollected += ConceptAddedToInventory;
        ConceptCollectionNotifier.OnConceptCollected += LetterCompleted;
        concepts.Clear();
    }

    private void Update()
    {
       
    }


    public void Exchange(string slotTag, GameObject exchange)
    {
        concepts[slotTag] = exchange; 
        exchange.GetComponent<ConceptCollectionNotifier>().OnPurchased();
    }

    private void ConceptAddedToInventory(GameObject concept)
    {
       //check if Slot 1 is filled
        if (!IsInSlot1() && concept.CompareTag("Slot1"))
        {
            //Debug.Log("Player collected " + concept.GetComponent<ConceptCollectionNotifier>().conceptName);
            concepts["Slot1"] = concept;
        }
        else
        {
            //Debug.Log("Slot 1 filled!");
        }
       
        //check if Slot 2 is filled
        if (!IsInSlot2() && concept.CompareTag("Slot2"))
        {
            //Debug.Log("Player collected " + concept.GetComponent<ConceptCollectionNotifier>().conceptName);
            concepts["Slot2"] = concept;
        }
        else
        {
            //Debug.Log("Slot 2 filled!");
        }

        //check if Slot 3 is filled
        if (!IsInSlot3() && concept.CompareTag("Slot3"))
        {
            //Debug.Log("Player collected " + concept.GetComponent<ConceptCollectionNotifier>().conceptName);
            concepts["Slot3"] = concept;
        }
        else
        {
            //Debug.Log("Slot 3 filled!");
        }

        //check if Slot 4 is filled
        if (!IsInSlot4() && concept.CompareTag("Slot4"))
        {
            //Debug.Log("Player collected " + concept.GetComponent<ConceptCollectionNotifier>().conceptName);
            concepts["Slot4"] = concept;
        }
        else
        {
            //Debug.Log("Slot 4 filled!");
        }

        //check if concept is jumping power

        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "jump") 
        {
            //Debug.Log("Jump concept in inventory");
            OnSingleJumpInInventory();
        }

        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump")
        {
            OnDoubleJumpInInventory();
        }


    }
       
    
    private bool IsInSlot1()
    {
        return concepts.ContainsKey("Slot1");
    }
    private bool IsInSlot2()
    {
        return concepts.ContainsKey("Slot2");
    }
    private bool IsInSlot3()
    {
        return concepts.ContainsKey("Slot3");
    }

    private bool IsInSlot4()
    {
        return concepts.ContainsKey("Slot4");
    }

    void LetterCompleted(GameObject concept)
    {
        if (concepts.ContainsKey("Slot1") && concepts.ContainsKey("Slot2") && concepts.ContainsKey("Slot3") && concepts.ContainsKey("Slot4"))
        {
            letterCompleted = true;
            OnLetterCompleted();
        }
    }
}
