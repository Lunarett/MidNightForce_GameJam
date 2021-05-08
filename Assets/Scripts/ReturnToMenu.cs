using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BeatHandler.Instance.SetMusicLayer(0);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

}
