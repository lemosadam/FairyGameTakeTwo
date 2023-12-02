using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryManagerWithEvents : MonoBehaviour
{
    public List<GameObject> concepts = new List<GameObject>();

    //public static event Action<ConceptCollectionNotifier> Slot1Filled;

    // Start is called before the first frame update
    void Start()
    {
        ConceptCollectionNotifier.OnConceptCollected += ConceptAddedToInventory;
    }


    private void ConceptAddedToInventory(ConceptCollectionNotifier concept)
    {
       //check if Slot 1 is filled
        if (!IsInSlot1() && concept.CompareTag("Slot1"))
        {
            Debug.Log("Player collected " + concept.conceptName);
            concepts.Add(concept.conceptObject);
            concept.conceptObject.SetActive(false);
        }
        else
        {
            Debug.Log("Slot 1 filled!");
        }
       
        //check if Slot 2 is filled
        if (!IsInSlot2() && concept.CompareTag("Slot2"))
        {
            Debug.Log("Player collected " + concept.conceptName);
            concepts.Add(concept.conceptObject);
            concept.conceptObject.SetActive(false);
        }
        else
        {
            Debug.Log("Slot 2 filled!");
        }

        //check if Slot 3 is filled
        if (!IsInSlot3() && concept.CompareTag("Slot3"))
        {
            Debug.Log("Player collected " + concept.conceptName);
            concepts.Add(concept.conceptObject);
            concept.conceptObject.SetActive(false);
        }
        else
        {
            Debug.Log("Slot 3 filled!");
        }

        //check if Slot 4 is filled
        if (!IsInSlot4() && concept.CompareTag("Slot4"))
        {
            Debug.Log("Player collected " + concept.conceptName);
            concepts.Add(concept.conceptObject);
            concept.conceptObject.SetActive(false);
        }
        else
        {
            Debug.Log("Slot 4 filled!");
        }


    }
       
    
    private bool IsInSlot1()
    {
        foreach (GameObject concept in concepts)
        {
            if (concept.CompareTag("Slot1"))
            {
                return true;
            }
        }
        return false;
    }
    private bool IsInSlot2()
    {
        foreach (GameObject concept in concepts)
        {
            if (concept.CompareTag("Slot2"))
            {
                return true;
            }
        }
        return false;
    }
    private bool IsInSlot3()
    {
        foreach (GameObject concept in concepts)
        {
            if (concept.CompareTag("Slot3"))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsInSlot4()
    {
        foreach (GameObject concept in concepts)
        {
            if (concept.CompareTag("Slot4"))
            {
                return true;
            }
        }
        return false;
    }

}
