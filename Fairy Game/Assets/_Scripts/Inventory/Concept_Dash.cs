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
        paragraph = "Let’s make this work. I wish we had met years ago. We made such a good team. Maybe this is the beginning of something special.";
    }


}
