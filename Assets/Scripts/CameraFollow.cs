using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float height = 12.5f;

    private void LateUpdate()
    {
        if(player)
        {
            this.transform.position = new Vector3(player.position.x, height, player.position.z);
        }
    }
}
