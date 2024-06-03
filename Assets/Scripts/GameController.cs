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
    [SerializeField] private GameObject ghostWall;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject ToStore;
    [SerializeField] private GameObject StartWaveButton;
    [SerializeField] private GameObject TimerText;
    public static bool isBuyWall;
    public static bool isBuyWarrior;
    public static bool isBuyMachine;
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
                var wave = new int[] { 2, 0, 0, 0 };
                spawner.SpawnWave(wave);
                break;
            case 2:
                wave = new int[] { 3, 1, 0, 0 };
                spawner.SpawnWave(wave);
                break;
            case 3:
                wave = new int[] { 4, 0, 1, 2 };
                spawner.SpawnWave(wave);
                break;
            default:
                wave = GenerateRandomWave();
                spawner.SpawnWave(wave);
                break;
        }
        Timer.PlayorStop();
    }
    private int[] GenerateRandomWave()
    {
        var wave = new int[4];
        wave[0] = Mathf.CeilToInt(Random.Range(2, countWave*2));
        wave[1] = Mathf.CeilToInt(Random.Range(0, countWave/2));
        wave[2] = Mathf.CeilToInt(Random.Range(0, countWave/3));
        wave[3] = Mathf.CeilToInt(Random.Range(0, countWave/4));
        return wave;
    }
    private void FixedUpdate()
    {
        if (countEnemy == 0)
        {
            EndWave();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }
        if (isBuyWall)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                spawner.SpawnWall();
                isBuyWall = false;
            }
            ghostWall.SetActive(isBuyWall);
        }
        if (isBuyWarrior)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                spawner.SpawnWarrior();
                isBuyWarrior = false;
            }
        }
        if (isBuyMachine)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                spawner.SpawnMachine();
                isBuyMachine = false;
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
