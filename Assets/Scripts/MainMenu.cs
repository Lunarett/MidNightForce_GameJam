using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject dialogParent;

    [SerializeField] GameObject menuElementsParent;

    [SerializeField] Button continueButton;
    [SerializeField] Button startButton;
    [SerializeField] TMPro.TextMeshProUGUI introText;

    [SerializeField] string[] introDialogSection;

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        StartCoroutine(IntroSequence());


    }

    private IEnumerator IntroSequence()
    {
        menuElementsParent.SetActive(false);
        dialogParent.SetActive(true);

        bool clicked = false;
        bool start = false;

        continueButton.onClick.AddListener(delegate { clicked = true; });


        foreach (var section in introDialogSection)
        {
            introText.text = section;

            while (!clicked)
            {
                yield return null;
            }
            clicked = false;
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

}
