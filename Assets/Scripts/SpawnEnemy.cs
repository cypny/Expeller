using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject BasicEnemy;
    public Vector3 origin = Vector3.zero;
    public float radius = 0;
    void FixedUpdate()
    {
        if (Input.anyKey)
        {

            Spawn();
        }
    }
    private void Spawn()
    {
        Vector3 randomPosition = origin + Random.insideUnitSphere * radius;
        Instantiate(BasicEnemy, randomPosition, Quaternion.identity);
    }
}
