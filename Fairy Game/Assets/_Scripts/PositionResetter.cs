using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionResetter : MonoBehaviour
{
    public GameObject startPosisitonObj;
    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = startPosisitonObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = startPosition;
    }

}
