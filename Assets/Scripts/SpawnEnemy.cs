using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject BasicEnemy;
    public Vector3 origin = Vector3.zero;
    public float radius = 0;
 
    public void SpawnWave(int count)
    {
        for(int i = 0; i < count; i++)
        {
            SpawnBasicEnemy();
        }
    }
    private void SpawnBasicEnemy()
    {
        Vector3 randomPosition = origin+ Random.insideUnitSphere * radius;
        Instantiate(BasicEnemy, randomPosition, Quaternion.identity);
    }
}
