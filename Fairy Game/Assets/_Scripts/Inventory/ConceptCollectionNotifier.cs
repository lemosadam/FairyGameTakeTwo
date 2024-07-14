using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ConceptCollectionNotifier : MonoBehaviour
{
    public GameObject conceptObject;
    public Sprite conceptIcon;
    public bool isInInventory = false;
    public bool isInShop;

    public static event Action<GameObject> OnConceptCollected;
    public static event Action<GameObject> OnConceptPurchased;
    public static event Action<GameObject> OnConceptSold;
    public static event Action OnSingleJumpSold;
    public static event Action OnDoubleJumpSold;


    [SerializeField] //consider adding this info to a seperate script
    public string conceptName;
    public string conceptMechanic;
    public int slotTag;
    public string paragraph;
    public Vector2 inventoryLocation = new Vector2(1000, 1000);

    public InventoryManagerWithEvents inventoryManager;
    public ShopManager shopManager;


    private void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
            conceptObject = gameObject;
            OnConceptCollected(gameObject);
            this.isInInventory = true;
            conceptObject.transform.position = inventoryLocation;
    }
    public void OnPurchased()
    {
        OnConceptPurchased(gameObject);
    }
    public void OnSold()
    {
        OnConceptSold(gameObject);
        if (this.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "jump")
        {
            OnSingleJumpSold();
            Debug.Log("Single jump sold");
        }
        
        if (this.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump")
        {
            OnDoubleJumpSold();
        }
        
    }
   
}
