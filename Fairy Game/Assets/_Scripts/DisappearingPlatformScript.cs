using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatformScript : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        ConceptCollectionNotifier.OnConceptCollected += ConceptAddedToInventory;
        ConceptCollectionNotifier.OnConceptPurchased += ConceptAddedToInventory;
        ConceptCollectionNotifier.OnConceptSold += ConceptRemovedFromInventory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ConceptAddedToInventory(GameObject concept)
    {
        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "see color")
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }

        }

    }

    private void ConceptRemovedFromInventory(GameObject concept)
    {
        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "see color")
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

        }
    }
}
