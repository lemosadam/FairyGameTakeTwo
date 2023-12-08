using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concept_SeeColor : ConceptCollectionNotifier
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        conceptMechanic = "see color";
        conceptName = "Whirlwind Romance";
        paragraph = "I remember our first magic carpet ride. We were flying into the sunrise when you kissed me. You still tasted like cherry cordial. You were so deliciously shy.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
