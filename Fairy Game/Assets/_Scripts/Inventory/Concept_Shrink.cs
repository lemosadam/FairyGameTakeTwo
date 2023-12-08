using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concept_Shrink : ConceptCollectionNotifier
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        conceptMechanic = "shrink";
        conceptName = "Feeling Intimidated";
        paragraph = "I remember I couldn’t believe you would talk to me. We were at a tournament when I first approached you. You still had your armor on. You were a magnificent sight.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
