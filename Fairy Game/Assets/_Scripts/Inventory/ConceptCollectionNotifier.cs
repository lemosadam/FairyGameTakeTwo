using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ConceptCollectionNotifier : MonoBehaviour
{
    public GameObject conceptObject;
    public Sprite conceptIcon;
    public bool isInInventory = false;

    public static event Action<ConceptCollectionNotifier> OnConceptCollected;
    public static event Action<ConceptCollectionNotifier> OnConceptTraded;
    public static event Action<ConceptCollectionNotifier> Trading;


    [SerializeField]
    public string conceptName;
    public string conceptMechanic;
    public int slotTag;

    public InventoryManagerWithEvents inventoryManager;
    public ShopManager shopManager;


    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (OnConceptCollected != null)
        {
            conceptObject = this.gameObject;
            //conceptObject.SetActive(false);
            OnConceptCollected(this);
            this.isInInventory = true;
            
        }
    }

public void ConceptBoughtFromShop()
    {
        if (OnConceptCollected != null)
        {
            OnTradeButton1Click();
            
            //conceptObject = shopConcept;
            //conceptObject.SetActive(false);
            //OnConceptCollected(conceptObject);
            this.isInInventory = true;
        }
    }

    public void OnTradeButton1Click()
    {

        Debug.Log("Trade Button 1 clicked");
        // put what's in the shop on the counter
        // put what's in the inventory in the shop
        // put what's on the counter in the inventory
        foreach (GameObject shopConcept in shopManager.shopConcepts)
        {
            if (shopConcept.CompareTag("Slot1"))
            {
                //conceptObjectToBeTraded = shopConcept;
               // shopConcepts.Remove(shopConcept);
                //objectOnCounter.Add(shopConcept);
                foreach (GameObject concept in inventoryManager.concepts)
                {
                    if (concept.CompareTag("Slot1"))
                    {
                        inventoryManager.concepts.Remove(concept);
                        //shopConcepts.Add(concept);
                        inventoryManager.concepts.Add(shopConcept);

                        //objectOnCounter.Remove(shopConcept);
                    }
                }


            }
        }

    }




}
