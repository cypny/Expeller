using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject BasicEnemy;
    [SerializeField] private GameObject SpiralEnemy;
    [SerializeField] private GameObject BigEnemy;
    [SerializeField] private GameObject SupportEnemy;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject warrior;
    [SerializeField] private GameObject machine;
    public Vector3 origin = Vector3.zero;
    public Vector3 ort = new Vector3(1, 1, 1);
    public float radius = 0;
    public void SpawnMachine()
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        Instantiate(machine, position, Quaternion.identity);
    }
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
    public void SpawnWave(int[] count)
    {
        // count[] 0-базовый, 1-спераль, 2-большой, 3-сапорт
        GameController.countEnemy = count[0] * 2;
        for (int i = 0; i < count[0]; i++)
        {
            SpawnOneEnemy(BasicEnemy);
            Invoke("SpawnBasicEnemy", 10f);
        }
        GameController.countEnemy += count[1];
        for (int i = 0; i < count[1]; i++)
        {
            SpawnOneEnemy(SpiralEnemy);
        }
        GameController.countEnemy += count[2];
        for (int i = 0; i < count[2]; i++)
        {
            SpawnOneEnemy(BigEnemy);
        }
        GameController.countEnemy += count[3];
        for (int i = 0; i < count[3]; i++)
        {
            SpawnOneEnemy(SupportEnemy);
        }
    }
    private void SpawnBasicEnemy()
    {
        Vector3 randomPosition = origin;
        randomPosition.x = Random.Range(0.2f, 1) * radius * (Random.Range(0, 2) * 2 - 1);
        randomPosition.y = Random.Range(0.2f, 1) * radius * (Random.Range(0, 2) * 2 - 1);
        Instantiate(BasicEnemy, randomPosition, Quaternion.identity);
    }
    private void SpawnOneEnemy(GameObject enemy)
    {
        Vector3 randomPosition = origin;
        randomPosition.x = Random.Range(0.2f, 1) * radius * (Random.Range(0, 2) * 2 - 1);
        randomPosition.y = Random.Range(0.2f, 1) * radius * (Random.Range(0, 2) * 2 - 1);
        Instantiate(enemy, randomPosition, Quaternion.identity);
    }
}
