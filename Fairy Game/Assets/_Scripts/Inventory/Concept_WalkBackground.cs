using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concept_WalkBackground : ConceptCollectionNotifier
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        conceptMechanic = "walk background";
        conceptName = "Bittersweet Longing";
        paragraph = "Now, I run my finger along your handwriting, and I can hear your voice. When I finish your letters, it’s like you’ve left all over again. Daydreams are my refuge.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
