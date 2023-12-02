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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
