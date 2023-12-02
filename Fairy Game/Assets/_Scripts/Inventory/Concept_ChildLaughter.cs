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
    }

    
}
