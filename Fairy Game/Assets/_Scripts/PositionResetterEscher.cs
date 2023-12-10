using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionResetterEscher : MonoBehaviour
{
    public static event Action<GameObject> OnResetPosition;
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnResetPosition(other.gameObject);
            Transform playerTransform = other.transform;
            if (playerTransform.localScale.x < 0)
            {
                playerTransform.localScale = new Vector3(-1, 1, 1);
            }
            else { playerTransform.localScale = new Vector3(1, 1, 1); }

        }
    }


}
