using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    public static int CountEnemyAlive = 0;
    public Wave[] Waves;
    public Transform START;
    public float waveRate = 0.2f;
    void Start()
    {
        StartCoroutine(_spawnEnemy());
    }

    IEnumerator _spawnEnemy()
    {
        foreach(Wave wave in Waves)
        {
            for ( int i = 0; i < wave.count; ++i)
            {
                GameObject.Instantiate(wave.enemyPrefab, START.position, Quaternion.identity);
                CountEnemyAlive++;
                if (i != wave.count - 1)
                    yield return new WaitForSeconds(wave.rate);
            }
            while (CountEnemyAlive > 0)
                yield return 0;
        }
        yield return new WaitForSeconds(waveRate);
    }
}
