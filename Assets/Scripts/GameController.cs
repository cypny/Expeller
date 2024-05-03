using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject[] enemys;

    public SpawnEnemy spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner.SpawnWave(5);
    }
    private void ClearScene()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            Destroy(enemy);
        }
    }
}
