using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
