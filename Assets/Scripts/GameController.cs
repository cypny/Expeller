using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameObject[] enemys;
    public static float damageClick = 0;
    public static int countWave = 1;
    public CoinText CoinText;
    public Timer timer;
    public GameObject ToStore;
    public GameObject StartWaveButton;
    public static bool isBuyWall;
    public static bool isBuyWarrior;
    public SpawnEnemy spawner;
    // Start is called before the first frame update
    public void EndWave()
    {
        ClearScene();
        ToStore.SetActive(true);
        StartWaveButton.SetActive(true);
        CoinText.Coin += 100 * countWave + (countWave+10) * (countWave+10);
    }
    public void StartWave()
    {
        StartWaveButton.SetActive(false);
        ToStore.SetActive(false);
        switch (countWave)
        {
            case 1:
                spawner.SpawnWave(2);
                break;
            case 2:
                spawner.SpawnWave(5);
                break;
            case 3:
                spawner.SpawnWave(7);
                break;
            default:
                spawner.SpawnWave(countWave * 2);
                break;
        }
        timer.isRun = true;

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
    private static void ClearScene()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            Destroy(enemy);
        }
    }
}
