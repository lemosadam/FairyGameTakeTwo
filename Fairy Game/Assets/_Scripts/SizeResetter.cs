using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SupanthaPaul;

public class SizeResetter : MonoBehaviour
{

    private Transform originalPlayerTransform;
    public GameObject Player;
    private 
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
        if (other.CompareTag("Player"))
        {
            originalPlayerTransform.localScale = other.transform.localScale;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Transform currentPlayerTransform = other.transform;
            currentPlayerTransform.localScale = originalPlayerTransform.localScale;
            
            
        }
    }
}
