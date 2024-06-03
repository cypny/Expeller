using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer audioMixer;

    void Start()
    {
        // Инициализируем значение слайдера текущим значением громкости
        var volume = 0f;
        audioMixer.GetFloat("Volume", out volume);
        volumeSlider.value = volume;

        // Добавляем обработчик события изменения значения слайдера
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        var volumeToMixer=Mathf.Log10(volume) * 20;
        audioMixer.SetFloat("Volume", volumeToMixer);
    }
}
