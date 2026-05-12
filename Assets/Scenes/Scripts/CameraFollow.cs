using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float minX, maxX;

    public bool followPlayer = true;

    void LateUpdate()
    {
        if (!followPlayer) return;

        transform.position = new Vector3(
            player.position.x,
            0,
            -10
        );
    }
}



