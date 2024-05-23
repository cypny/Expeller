using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject[] enemys;
    public static float damageClick = 0;
    public static int countWave = 1;

    public static bool isBuyWall;
    public static bool isBuyWarrior;
    public SpawnEnemy spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner.SpawnWave(5);
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (isBuyWall)
            {
                spawner.SpawnWall();
                isBuyWall = false;
            }
            if (isBuyWarrior)
            {
                spawner.SpawnWarrior();
                isBuyWarrior = false;
            }
        }
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
