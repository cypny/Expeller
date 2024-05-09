using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int sceneNumber;
    public Canvas canvas;
    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas storeCanvas;
    
    public void Transition()
    {
        if (sceneNumber == 1)
        {
            canvas.enabled = false;
            canvas1.enabled = false;
            canvas2.enabled = false;
            storeCanvas.enabled = true;
        }
        else
        {
            canvas.enabled = true;
            canvas1.enabled = true;
            canvas2.enabled = true;
            storeCanvas.enabled = false;
        }
    }
}
