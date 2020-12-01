using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoxSpawner : MonoBehaviour
{
    public GameObject healthBox;
    public Transform ground;
    public float delay = 3.0f;

    private void Start()
    {
        InvokeRepeating("SpawnHealthBox", 0.0f, delay);
    }

    void SpawnHealthBox()
    {
        float xpos = Random.Range(-1.0f, 1.0f) * (ground.localScale.x / 2);
        float zpos = Random.Range(-1.0f, 1.0f) * (ground.localScale.z / 2);

        Vector3 spawnPos = new Vector3(xpos, 1, zpos);

        Instantiate(healthBox, spawnPos, Quaternion.identity);
    }
}
