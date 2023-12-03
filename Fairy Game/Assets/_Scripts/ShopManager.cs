using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<GameObject> shopConcepts = new List<GameObject>();
    public List<GameObject> objectOnCounter = new List<GameObject>();
    public InventoryManagerWithEvents inventoryManager;
    public GameObject conceptObjectToBeTraded;
    public ConceptCollectionNotifier conCN;

    //public static event Action<ConceptCollectionNotifier> OnConceptRemovedFromShop;

    // Start is called before the first frame update
    void Start()
    {
        //ConceptCollectionNotifier.OnConceptCollected += ConceptAddedToInventory;
    }

    public void OnTradeButton1Click()
    {
        foreach (GameObject shopConcept in shopConcepts)
        {
            if (shopConcept.CompareTag("Slot1"))
            {
                //conceptObjectToBeTraded = shopConcept;
                shopConcepts.Remove(shopConcept);
                objectOnCounter.Add(shopConcept);
                //concept.isInShop = false;
                foreach (GameObject concept in inventoryManager.concepts)
                {
                    if (concept.CompareTag("Slot1"))
                    {
                        inventoryManager.concepts.Remove(concept);
                        shopConcepts.Add(concept);
                        inventoryManager.concepts.Add(shopConcept);
                        //conceptTraded.isInInventory = true;
                        objectOnCounter.Remove(shopConcept);
                    }
                }
            }
        }

    }


    private void ConceptAddedToShop(ConceptCollectionNotifier concept)
    {
        //check if Slot 1 is filled
        if (!IsInSlot1() && concept.CompareTag("Slot1"))
        {
            Debug.Log("Player traded " + concept.conceptName);
            shopConcepts.Add(concept.conceptObject);
            concept.conceptObject.SetActive(false);
        }
        else
        {
            Debug.Log("Slot 1 filled!");
        }

        //check if Slot 2 is filled
        if (!IsInSlot2() && concept.CompareTag("Slot2"))
        {
            Debug.Log("Player traded " + concept.conceptName);
            shopConcepts.Add(concept.conceptObject);
            concept.conceptObject.SetActive(false);
        }
        else
        {
            Debug.Log("Slot 2 filled!");
        }

        //check if Slot 3 is filled
        if (!IsInSlot3() && concept.CompareTag("Slot3"))
        {
            Debug.Log("Player traded " + concept.conceptName);
            shopConcepts.Add(concept.conceptObject);
            concept.conceptObject.SetActive(false);
        }
        else
        {
            Debug.Log("Slot 3 filled!");
        }

        //check if Slot 4 is filled
        if (!IsInSlot4() && concept.CompareTag("Slot4"))
        {
            Debug.Log("Player traded " + concept.conceptName);
            shopConcepts.Add(concept.conceptObject);
            concept.conceptObject.SetActive(false);
        }
        else
        {
            Debug.Log("Slot 4 filled!");
        }


    }


    private bool IsInSlot1()
    {
        foreach (GameObject concept in shopConcepts)
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
        foreach (GameObject concept in shopConcepts)
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
        foreach (GameObject concept in shopConcepts)
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
        foreach (GameObject concept in shopConcepts)
        {
            if (concept.CompareTag("Slot4"))
            {
                return true;
            }
        }
        return false;
    }

   
}