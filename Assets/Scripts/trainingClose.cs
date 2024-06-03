using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainingClose : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void Close()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Close();
        }
    }
}
