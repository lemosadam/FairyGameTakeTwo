using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concept_Dash : ConceptCollectionNotifier
{

    //public static event Action<Concept_ChildLaughter> OnLaughterCollected;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        conceptMechanic = "dash";
        conceptName = "Unfounded Optimism";
    }


}
