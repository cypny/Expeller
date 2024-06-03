using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image bar;
    private float health;
    [SerializeField] private Text Score;
    public float maxhealth;
    [SerializeField] private AudioSource lose;
    [SerializeField] private AudioSource Fight;
    public GameObject end;
    public void Start()
    {
        health = maxhealth;
        bar.fillAmount = 1;
    }

    public void ValueChange(float damage)
    {
        bar.fillAmount -= damage / maxhealth;
        health -= damage;
        if (health <= 0)
        {
            Score.text = GameController.countWave.ToString(CultureInfo.InvariantCulture);
            end.SetActive(true);
            Fight.Stop();
            lose.Play();
            Invoke("End",3);
        }
    }
    private void End()
    {
        Application.Quit();
    }
}
