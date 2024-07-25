using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionResetter : MonoBehaviour
{
    public GameObject startPosisitonObj;
    private Vector2 startPosition;
    public static event Action<GameObject> OnPositionReset;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = startPosisitonObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = startPosition;
        GameObject collisionObj = other.gameObject;
        OnPositionReset(collisionObj);
    }

}
