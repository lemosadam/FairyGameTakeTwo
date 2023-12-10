using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundWalkEnabler : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask backgroundWindowLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        BackTeleporter.OnPlayerTeleportedBack += ExcludeGround;
        FrontTeleporter.OnPlayerTeleportedFront += ExcludeBackground;
        PositionResetterEscher.OnResetPosition += ExcludeBackground;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExcludeGround(GameObject player)
    {
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
        playerRB.excludeLayers = groundLayer;
        playerRB.includeLayers = backgroundWindowLayer;

    }   
    
    void ExcludeBackground(GameObject player)
    {
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
        playerRB.excludeLayers = backgroundWindowLayer; 
        playerRB.includeLayers = groundLayer;
    }
}
