using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concept_InverseJump : ConceptCollectionNotifier
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        conceptMechanic = "inverse jump";
        conceptName = "Crushing Heartbreak";
        paragraph = "I can’t do this anymore. I’m suffering because of how much you mean to me. Heartache eats away at my memories of your head on my chest.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
