using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public int sceneNumber;
    public Canvas gameCanvas;
    public Canvas storeCanvas;
    
    public void Transition()
    {
        if (sceneNumber == 1)
        {
            gameCanvas.enabled = false;
            storeCanvas.enabled = true;
        }
        else
        {
            gameCanvas.enabled = true;
            storeCanvas.enabled = false;
        }
    }
}
