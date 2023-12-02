using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMover : MonoBehaviour
{
    public List<Transform> points;
    public Transform platform;
    int goalPoint = 0;
    [SerializeField] float moveSpeed = 2;



    // Update is called once per frame
    void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        platform.position = Vector2.MoveTowards(platform.position, points[goalPoint].position, Time.deltaTime * moveSpeed);

        if(Vector2.Distance(platform.position, points[goalPoint].position)<0.1f)
        {
            if (goalPoint == points.Count - 1)
            {
                goalPoint = 0;
            }
            else
            {
                goalPoint++;
            }
        }

    }

}
