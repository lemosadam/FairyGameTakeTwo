using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GravityInverter : MonoBehaviour
{
    public static event Action OnGravityToggled; 
    public GameObject player;
    public GameObject followCamera;

    // Start is called before the first frame update
    void Start()
    {
        DoorScript.OnTeleportComplete += InvertGravity;

        player = GameObject.FindGameObjectWithTag("Player");
        followCamera = GameObject.Find("Follow Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InvertGravity()
    {
        OnGravityToggled();
    }
    
}
