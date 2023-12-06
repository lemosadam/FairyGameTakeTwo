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
    
    public TextMeshProUGUI paragraph1;
    public TextMeshProUGUI paragraph2;
    public TextMeshProUGUI paragraph3;
    public TextMeshProUGUI paragraph4;



    //public Image conceptImage;

    // Start is called before the first frame update
    void Start()
    {
        ConceptCollectionNotifier.OnConceptCollected += SpriteDisplayedInInventory;
        ConceptCollectionNotifier.OnConceptCollected += TextDisplayedInLetter;

        ConceptCollectionNotifier.OnConceptPurchased += SpriteDisplayedInInventory;
        ConceptCollectionNotifier.OnConceptPurchased += TextDisplayedInLetter;
    }

    private void ConceptCollectionNotifier_OnConceptTraded(GameObject obj)
    {
        throw new System.NotImplementedException();
    }

    private void SpriteDisplayedInInventory(GameObject concept)
    {
        //Sprite sprite
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

    private void TextDisplayedInLetter(GameObject concept)
    {
        
        string paragraph = concept.GetComponent<ConceptCollectionNotifier>().paragraph;
        if (concept != null && concept.CompareTag("Slot1"))
        {
            paragraph1.text = paragraph;

        }

        if (concept != null && concept.CompareTag("Slot2"))
        {
            paragraph2.text = paragraph;

        }

        if (concept != null && concept.CompareTag("Slot3"))
        {
            paragraph3.text = paragraph;

        }

        if (concept != null && concept.CompareTag("Slot4"))
        {
            paragraph4.text = paragraph;

        }

        Debug.Log("Concept collected or traded: " + concept.GetComponent<ConceptCollectionNotifier>().conceptName);
    }


}
