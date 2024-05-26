using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameObject[] enemys;
    public static float damageClick = 0.5f;
    public static float speedClick = 5.5f;
    public static int countWave = 1;
    public static int countEnemy = 1;
    [SerializeField] private CoinText CoinText;
    [SerializeField] private GameObject ToStore;
    [SerializeField] private GameObject StartWaveButton;
    [SerializeField] private GameObject TimerText;
    public static bool isBuyWall;
    public static bool isBuyWarrior;
    [SerializeField] private AudioSource Fight;
    [SerializeField] private AudioSource notFight;

    public SpawnEnemy spawner;
    // Start is called before the first frame update
    public void EndWave()
    {
        Fight.Pause();
        notFight.Play();
        ClearScene();
        TimerText.SetActive(false);
        ToStore.SetActive(true);
        Timer.PlayorStop();
        Timer.SetTime(60);
        StartWaveButton.SetActive(true);
        CoinText.Coin += 50 * countWave + (countWave+10) * (countWave+10);
        countEnemy = -1;
        countWave += 1;
}
    public void StartWave()
    {
        Fight.Play();
        notFight.Pause();
        StartWaveButton.SetActive(false);
        TimerText.SetActive(true);
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
        Timer.PlayorStop();
    }
    private void FixedUpdate()
    {
        if(countEnemy == 0)
        {
            EndWave();
        }
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
