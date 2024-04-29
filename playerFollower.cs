using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollower : MonoBehaviour
{
    // Reference to the player's transform
    public Transform player;
    // Offset from the player's position
    public Vector3 offset;
    // Space in which the offset is applied
    private Space offsetPositionSpace = Space.Self;
    // Whether the follower should always look at the player
    private bool lookAt = true;

    // Update is called once per frame
    void Update()
    {
        // Check if the offset position space is set to self
        if (offsetPositionSpace == Space.Self)
        {
            // Move the follower to a position relative to the player's position
            transform.position = player.TransformPoint(offset);
        }
        else
        {
            // Move the follower to an absolute position relative to the player's position
            transform.position = player.position + offset;
        }

        // Compute rotation
        if (lookAt)
        {
            // Rotate the follower to always look at the player
            transform.LookAt(player);
        }
        else
        {
            // Use the player's rotation as the follower's rotation
            transform.rotation = player.rotation;
        }
    }
}


