using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RubinVaseToggler : MonoBehaviour
{
    public TilemapRenderer foreground;
    public TilemapRenderer switchableBackground;
    public GameObject switchableGround;
    //public TilemapCollider2D switchableGroundCollider;

    // Start is called before the first frame update
    void Start()
    {
        ConceptCollectionNotifier.OnConceptCollected += ConceptAddedToInventory;
        ConceptCollectionNotifier.OnConceptPurchased += ConceptAddedToInventory;
        ConceptCollectionNotifier.OnConceptSold += ConceptRemovedFromInventory;

        
        switchableBackground.enabled = false;
        //switchableGroundCollider = switchableGround.GetComponent<TilemapCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ConceptAddedToInventory(GameObject concept)
    {
        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "switch foreground")
        {
            foreground.enabled = false;
            switchableGround.GetComponent<TilemapCollider2D>().enabled = false;
            switchableGround.GetComponent<TilemapRenderer>().enabled = false;
            switchableBackground.enabled = true;
        }
    }

    void ConceptRemovedFromInventory(GameObject concept)
    {
        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "switch foreground")
        {
            switchableBackground.enabled = false;
            switchableGround.GetComponent<TilemapCollider2D>().enabled = true;
            switchableGround.GetComponent<TilemapRenderer>().enabled = true;
            foreground.enabled = true;
        }
    }


}
