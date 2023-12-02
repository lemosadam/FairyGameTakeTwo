using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTeleporter : MonoBehaviour
{
    public Transform frontTeleporterTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player entered portal");
            Transform playerTransform = other.transform;
            playerTransform.position = frontTeleporterTransform.position;
        }
    }
}
