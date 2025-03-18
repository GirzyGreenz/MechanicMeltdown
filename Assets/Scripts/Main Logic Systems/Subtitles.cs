using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour
{
    //variables for subtitles
    public GameObject subtitleText;
    string filePathSubtitles = @"..\Delta2X\Assets\Database\Subtitles.txt";
    string[] subtitleLines;
    int subDuration = 4;

    //Activates directly when game starts and creates transfers subtitles and objectives texts to sepparate string arrays

    private void Awake()
    {
        subtitleText = GameObject.FindWithTag("Subtitle");
    }

    public void readAllSubtitles()
    {
        if (File.Exists(filePathSubtitles))
        {
            subtitleLines = File.ReadAllLines(filePathSubtitles);

            /*foreach (string ln in subtitleLines) {
                Debug.Log(ln);
            }*/
        }
    }

    //Methods that show, hide and imput the subtitles strings into something vissible
    //The unity editor only gives you the option to give a method a maximum of 1 perameter, that is why you need to create two interact functions with the "activateSubtitles" and "subtitleDuration"


    public void activateSubtitlesAndSetDuration(int subtitleLineNumber, int subtitleDurationTime)
    {
        subtitleDuration(subtitleDurationTime);
        activateSubtitles(subtitleLineNumber);
    }

    public void activateSubtitles(int subtitleLineNumber)
    {
        readAllSubtitles();

        if (checkIfSubtitleExists(subtitleLineNumber) == true)
        {
            inputSubtitles(subtitleLineNumber);
            subtitleText.GetComponent<TextMeshProUGUI>().enabled = true;
            StartCoroutine(disableSubtitles());
        }
    }

    public void activateSubtitlesForConversation(int subtitleLineNumber)
    {
        readAllSubtitles();

        if (checkIfSubtitleExists(subtitleLineNumber) == true)
        {
            inputSubtitles(subtitleLineNumber);
            subtitleText.GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }

    public void subtitleDuration(int subtitleDurationTime)
    {
        if (subtitleDurationTime <= 4)
        {
            subDuration = 4;
        } else
        {
            subDuration = subtitleDurationTime;
        }
    }

    public bool checkIfSubtitleExists(int subtitleLineNumber)
    {
        if (subtitleLineNumber <= subtitleLines.Length)
        {
            return true;
        }
        else
        {
            return false;
            Debug.Log("Trying to activat a subtitle nr that doens't exist.");
        }
    }

    public IEnumerator disableSubtitles()
    {
        yield return new WaitForSeconds(subDuration);
        subtitleText.GetComponent<TextMeshProUGUI>().enabled = false;
        inputSubtitles(0); //0 is the first line of the subtitles txt file and item nr 0 in the array and says subtitles shouln't be visible
    }

    public void inputSubtitles(int subtitleLineNumber)
    {
        string subtitleTextInput = subtitleLines[subtitleLineNumber];
        subtitleText.GetComponent<TextMeshProUGUI>().text = subtitleTextInput;
    }
}
