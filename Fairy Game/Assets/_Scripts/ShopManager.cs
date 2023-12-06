using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Dictionary<string, GameObject> shopConcepts = new Dictionary<string,GameObject>(); //this should be protected or private
    public Dictionary<string, GameObject> objectOnCounter = new Dictionary<string, GameObject>();
    public InventoryManagerWithEvents inventoryManager;
    public GameObject conceptObjectToBeTraded;
    public ConceptCollectionNotifier conCN;

    //public static event Action<ConceptCollectionNotifier> OnConceptRemovedFromShop;

    // Start is called before the first frame update
    void Start()
    {
        shopConcepts["Slot1"] = GameObject.Find("Shrink Concept");
        GameObject.Find("Shrink Concept").transform.position = new Vector2(1000, 1000);

        
    }

    public void OnTradeButton1Click()
    {
        GameObject exchange = shopConcepts["Slot1"];
        shopConcepts["Slot1"] = inventoryManager.concepts["Slot1"];
        inventoryManager.concepts["Slot1"].GetComponent<ConceptCollectionNotifier>().OnSold();
        inventoryManager.Exchange("Slot1", exchange);
        Debug.Log("Trade button 1 pressed");
    }

    private bool IsInSlot1()
    {
        return shopConcepts.ContainsKey("Slot1");
    }
    private bool IsInSlot2()
    {
        return shopConcepts.ContainsKey("Slot2");
    }
    private bool IsInSlot3()
    {
        return shopConcepts.ContainsKey("Slot3");
    }

    private bool IsInSlot4()
    {
        return shopConcepts.ContainsKey("Slot4");
    }


}