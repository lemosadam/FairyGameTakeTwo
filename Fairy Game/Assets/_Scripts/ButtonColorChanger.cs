using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChanger : MonoBehaviour
{
    public Image buttonImage;
    public Color originalColor;
    public Color flashColor;
    public float flashDuration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = gameObject.GetComponent<Image>();
        //changerColor = Color.red;


        ConceptCollectionNotifier.OnConceptCollected += ConceptAddedToInventory;
        ConceptCollectionNotifier.OnConceptPurchased += ConceptAddedToInventory;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void ConceptAddedToInventory(GameObject concept) 
    {
        Debug.Log("button should change color");
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 5; i++)
        {
            buttonImage.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
            buttonImage.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
        }
        buttonImage.color = originalColor; // Revert to original color
    }
}