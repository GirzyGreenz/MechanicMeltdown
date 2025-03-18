using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    public CursorState cursorState;

    void Start()
    {
        cursorState.makeCursorVisible();
    }
    
    void Update()
    {
        cursorState.makeCursorVisible();
    }

    public void startGame()
    {
        SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
    }

    public void quitGame()
    {
        Application.Quit();
    }


}
