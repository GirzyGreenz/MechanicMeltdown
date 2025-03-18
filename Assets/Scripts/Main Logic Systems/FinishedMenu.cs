using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedMenu : MonoBehaviour
{
    public GameObject finishedMenuUI;
    public GameObject failMenuUI;
    public GameObject inGameUI;
    public CursorState cursorState;
    public WorldCycler worldCycler;

    void Start()
    {
        worldCycler = FindObjectOfType<WorldCycler>();
    }

    public void isGameFinished() 
    {
        checkIfGameFinished();

        if (worldCycler.gameIsFinished == true)
        {
            StartCoroutine(finishGame());
        }
    }

    public void checkIfGameFinished()
    {
        if (worldCycler.moneyCountnr >= worldCycler.moneyGoalCount)
        {
            worldCycler.gameIsFinished = true;
        }
        else if (worldCycler.moneyCountnr < worldCycler.moneyGoalCount && worldCycler.day >= worldCycler.amountOfDaysToAchiveGoal)
        {
            worldCycler.gameIsFinished = true;
            StartCoroutine(failGame());
        }
        else
        {
            worldCycler.gameIsFinished = false;
        }
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    IEnumerator finishGame()
    {
        yield return new WaitForSeconds(3);

        finishedMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        cursorState.makeCursorVisible();
    }

    IEnumerator failGame()
    {
        yield return new WaitForSeconds(3);
        failMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        worldCycler.gameIsFinished = false;
        cursorState.makeCursorVisible();
    }
}
