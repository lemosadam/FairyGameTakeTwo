using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotsDisplayer : MonoBehaviour
{
    public Image Slot1;
    public Image Slot2;
    public Image Slot3;
    public Image Slot4;

    public TextMeshPro paragraph1;
    public TextMeshPro paragraph2;
    public TextMeshPro paragraph3;
    public TextMeshPro paragraph4;



    //public Image conceptImage;

    // Start is called before the first frame update
    void Start()
    {
        ConceptCollectionNotifier.OnConceptCollected += SpriteDisplayedInInventory;
        ConceptCollectionNotifier.OnConceptCollected += TextDisplayedInLeter;
    }

    private void SpriteDisplayedInInventory(ConceptCollectionNotifier concept)
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

    private void TextDisplayedInLeter(ConceptCollectionNotifier concept)
    {
        if (concept != null && concept.CompareTag("Slot1"))
        {
            paragraph1.text = concept.paragraph;

        }

        if (concept != null && concept.CompareTag("Slot2"))
        {
            paragraph2.text = concept.paragraph;

        }

        if (concept != null && concept.CompareTag("Slot3"))
        {
            paragraph3.text = concept.paragraph;

        }

        if (concept != null && concept.CompareTag("Slot4"))
        {
            paragraph4.text = concept.paragraph;

        }
    }


}
