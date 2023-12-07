using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchScript : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float flipThreshold = 0.01f;  // The threshold for flipping the NPC

    void Update()
    {
        // Check if the player exists
        if (player != null)
        {
            // Calculate the direction from the NPC to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Flip the NPC based on the direction
            FlipCharacter(directionToPlayer.x);

           
        }
    }

    void FlipCharacter(float direction)
    {
        // Flip the NPC based on the opposite direction
        if (Mathf.Abs(direction) > flipThreshold)
        {
            // Flip the NPC sprite horizontally
            transform.localScale = new Vector3(-Mathf.Sign(direction), 1f, 1f);
        }
    }
}
