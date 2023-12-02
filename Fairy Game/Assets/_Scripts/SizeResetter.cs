using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeResetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Transform playerTransform = other.transform;
            playerTransform.localScale = Vector3.one;
        }
    }
}
