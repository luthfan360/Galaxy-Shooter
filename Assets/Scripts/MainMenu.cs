using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool hintsOpen = false;
    [SerializeField]
    GameObject hintsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenHints()
    {
        if (hintsOpen == false)
        {
            hintsPanel.gameObject.SetActive(true);
            hintsOpen = true;
        }
        else
        {
            hintsPanel.gameObject.SetActive(false);
            hintsOpen = false;
        }
    }
}
