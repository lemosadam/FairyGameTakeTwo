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

    private void SpriteDisplayedInShop(ConceptCollectionNotifier concept)
    {
        if (concept != null && concept.CompareTag("Slot1"))
        {
            Slot1.sprite = concept.conceptIcon;

        }
        if (concept != null && concept.CompareTag("Slot2"))
        {
            Slot2.sprite = concept.conceptIcon;

        }
        if (concept != null && concept.CompareTag("Slot3"))
        {
            Slot3.sprite = concept.conceptIcon;
            Debug.Log("Slot 3 in inventory");

        }
        if (concept != null && concept.CompareTag("Slot4"))
        {
            Slot4.sprite = concept.conceptIcon;

        }
    }


}
