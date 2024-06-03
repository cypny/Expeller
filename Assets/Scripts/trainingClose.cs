using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainingClose : MonoBehaviour
{
    [SerializeField] private GameObject traning;
    public void Close()
    {
        traning.SetActive(false);
    }
}
