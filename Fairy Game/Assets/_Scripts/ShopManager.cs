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

    public void OnTradeButton2Click()
    {
        GameObject exchange = shopConcepts["Slot2"];
        shopConcepts["Slot2"] = inventoryManager.concepts["Slot2"];
        inventoryManager.concepts["Slot2"].GetComponent<ConceptCollectionNotifier>().OnSold();
        inventoryManager.Exchange("Slot2", exchange);
        Debug.Log("Trade button 2 pressed");
    }

    public void OnTradeButton3Click()
    {
        GameObject exchange = shopConcepts["Slot3"];
        shopConcepts["Slot3"] = inventoryManager.concepts["Slot3"];
        inventoryManager.concepts["Slot3"].GetComponent<ConceptCollectionNotifier>().OnSold();
        inventoryManager.Exchange("Slot3", exchange);
        Debug.Log("Trade button 3 pressed");
    }

    public void OnTradeButton4Click()
    {
        GameObject exchange = shopConcepts["Slot4"];
        shopConcepts["Slot4"] = inventoryManager.concepts["Slot4"];
        inventoryManager.concepts["Slot4"].GetComponent<ConceptCollectionNotifier>().OnSold();
        inventoryManager.Exchange("Slot4", exchange);
        Debug.Log("Trade button 4 pressed");
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