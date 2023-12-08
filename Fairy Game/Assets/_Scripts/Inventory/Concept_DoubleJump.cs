using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concept_DoubleJump : ConceptCollectionNotifier
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        conceptMechanic = "double jump";
        conceptName = "Hope for the Future";
        paragraph = "Let’s cherish this for what it was. I wish we could have saved each other from the anguish of the last few weeks. We made our choices. Maybe this is just how this story had to end.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
