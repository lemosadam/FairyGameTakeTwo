using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterSaveScript : MonoBehaviour
{
    public string paragraph1;
    public string paragraph2;
    public string paragraph3;
    public string paragraph4;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ConceptCollectionNotifier.OnConceptCollected += UpdateLetter;
        ConceptCollectionNotifier.OnConceptPurchased += UpdateLetter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateLetter(GameObject concept)
    {
        if (concept.CompareTag("Slot1"))
        {
            paragraph1 = concept.GetComponent<ConceptCollectionNotifier>().paragraph;
        }

        if (concept.CompareTag("Slot2"))
        {
            paragraph2 = concept.GetComponent<ConceptCollectionNotifier>().paragraph;
        }

        if (concept.CompareTag("Slot3"))
        {
            paragraph3 = concept.GetComponent<ConceptCollectionNotifier>().paragraph;
        }

        if (concept.CompareTag("Slot4"))
        {
            paragraph4 = concept.GetComponent<ConceptCollectionNotifier>().paragraph;
        }
    }
}
