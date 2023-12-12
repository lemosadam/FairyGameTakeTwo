using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlotsDisplayer : MonoBehaviour
{
    public Image Slot1;
    public Image Slot2;
    public Image Slot3;
    public Image Slot4;

    void Start()
    {
        ConceptCollectionNotifier.OnConceptSold += SpriteDisplayedInShop;
        
    }
    private void SpriteDisplayedInShop(GameObject concept)
    {
        Sprite sprite = concept.GetComponent<ConceptCollectionNotifier>().conceptIcon;

        if (concept != null && concept.CompareTag("Slot1"))
        {
            Slot1.sprite = sprite;

        }
        if (concept != null && concept.CompareTag("Slot2"))
        {
            Slot2.sprite = sprite;

        }
        if (concept != null && concept.CompareTag("Slot3"))
        {
            Slot3.sprite = sprite;
            Debug.Log("Slot 3 in inventory");

        }
        if (concept != null && concept.CompareTag("Slot4"))
        {
            Slot4.sprite = sprite;

        }
    }

   

}
