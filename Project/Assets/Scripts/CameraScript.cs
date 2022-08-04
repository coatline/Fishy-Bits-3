using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float zDistance = -10;
    public Transform player;

    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
        if (player != null)
        {
            transform.position = player.position + transform.forward * zDistance;
        }
    }
}
