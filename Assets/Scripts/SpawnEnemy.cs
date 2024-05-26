using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject BasicEnemy;
    public GameObject wall;
    public GameObject warrior;
    public Vector3 origin = Vector3.zero;
    public Vector3 ort = new Vector3(1, 1, 1);
    public float radius = 0;
    public void SpawnWall()
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        Instantiate(wall, position, Quaternion.identity);
    }
    public void SpawnWarrior()
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        Instantiate(warrior, position, Quaternion.identity);
    }
    public void SpawnWave(int count)
    {
        GameController.countEnemy = count * 2;
        for (int i = 0; i < count; i++)
        {
            SpawnBasicEnemy();
            Invoke("SpawnBasicEnemy", 10f);
        }
        
    }
    private void SpawnBasicEnemy()
    {
        Vector3 randomPosition = origin;
        randomPosition.x = Random.Range(0.2f, 1) * radius * (Random.Range(0, 2) * 2 - 1);
        randomPosition.y = Random.Range(0.2f, 1) * radius * (Random.Range(0, 2) * 2 - 1);
        Instantiate(BasicEnemy, randomPosition, Quaternion.identity);
    }
}
