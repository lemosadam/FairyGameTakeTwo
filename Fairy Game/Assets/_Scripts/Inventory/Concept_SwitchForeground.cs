using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concept_SwitchForeground : ConceptCollectionNotifier
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        conceptMechanic = "switch foreground";
        conceptName = "Being Gaslit";
        paragraph = "Now, I know better, and I can laugh at how gullible I was. When I finish telling everyone what I went through, it’s like you’ve lost your hold on my past. My memories are my own again.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
