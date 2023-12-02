using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InventoryManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> concepts = new List<GameObject>();

    // Event handler delegate
    public delegate void InventoryUpdatedEventHandler();
    // Event to be observed
    public event InventoryUpdatedEventHandler OnInventoryUpdated;

    public TMP_Text slot1text;

    void Start()
    {
        
        //slot1text = GameObject.Find("Slot1Text").GetComponent<TMP_Text>();
        
    }
    void Update()
    {
        // Example: Press the space key to display the inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            DisplayInventory();
            Debug.Log("I pressed I");
        }


        //slot1text.text = concepts[0].ToString();

    }   

    public bool AddConcept(GameObject conceptObject)
    {
        // Check if the concept is already in the inventory
        if (concepts.Contains(conceptObject))
        {
            Debug.LogWarning("Concept already in the inventory.");
            return false;
        }

        // Check if there is space in the inventory
        if (concepts.Count < 4)
        {
            concepts.Add(conceptObject);
            Debug.Log(conceptObject +" added to inventory");
            
            // Notify observers when the inventory is updated
            NotifyObservers();

            return true;
        }
        else
        {
            Debug.LogWarning("Inventory is full. Cannot add more concepts.");
            return false;
        }
    }

    public bool RemoveConcept(GameObject conceptObject)
    {
        if (concepts.Contains(conceptObject))
        {
            concepts.Remove(conceptObject);

            // Notify observers when the inventory is updated
            NotifyObservers();

            return true;
        }
        else
        {
            Debug.LogWarning("Concept not found in the inventory.");
            return false;
        }
    }

    private void NotifyObservers()
    {
        // Trigger the event to notify observers
        OnInventoryUpdated?.Invoke();
    }

    // Example method to display inventory (for testing purposes)
    public void DisplayInventory()
    {
        foreach (var conceptObject in concepts)
        {
            Debug.Log($"Concept: {conceptObject.name}");
        }
    }
}