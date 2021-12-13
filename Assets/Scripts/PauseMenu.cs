using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenuPanel;
    bool gamePaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gamePaused == false)
        {
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0;
            gamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && gamePaused == true)
        {
           resumeGame();
        }
    }

    public void resumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
