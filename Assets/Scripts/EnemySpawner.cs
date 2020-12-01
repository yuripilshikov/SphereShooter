﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float delay;
    public GameObject[] enemies;

    void SpawnEnemy()
    {
        int randomPos = (int)Random.Range(0, transform.childCount);
        GameObject enemy = enemies[(int)Random.Range(0, enemies.Length)];
        Instantiate(enemy, transform.GetChild(randomPos).position, enemy.transform.rotation);
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.0f, delay);
    }
}
