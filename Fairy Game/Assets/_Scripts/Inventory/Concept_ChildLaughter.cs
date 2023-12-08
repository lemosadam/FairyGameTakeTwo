using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Concept_ChildLaughter : ConceptCollectionNotifier
{
    
    //public static event Action<Concept_ChildLaughter> OnLaughterCollected;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        conceptMechanic = "jump";
        conceptName = "Child's Laughter";
        paragraph = "If only things were as easy as they were when we were children. I’m longing for those days of innocent naivete. My fellow knights balk at my foolish giggles.";
    }

    
}
