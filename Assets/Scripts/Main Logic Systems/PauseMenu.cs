using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject inGameUI;
    public GameObject controlsMenuUI;
    public CursorState cursorState;
    public FinishedMenu finishedMenu;
    public WorldCycler worldCycler;

    void Start()
    {
        worldCycler = FindObjectOfType<WorldCycler>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && worldCycler.gameIsFinished == false)
        {
            if (worldCycler.gameIsPaused == true)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    public void resumeGame()
    {
        cursorState.makeCursorInvisible();
        controlsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        inGameUI.SetActive(true);
        worldCycler.gameIsPaused = false;
    }

    public void pauseGame()
    {
        worldCycler.gameIsPaused = true;
        cursorState.makeCursorVisible();
        pauseMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        controlsMenuUI.SetActive(false);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void controlsMenu()
    {
        pauseMenuUI.SetActive(false);
        inGameUI.SetActive(false);
        worldCycler.gameIsPaused = true;
        controlsMenuUI.SetActive(true);
    }
}
