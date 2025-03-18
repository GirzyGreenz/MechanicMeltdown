using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Objectives : MonoBehaviour
{   
    //variables for subtitles
    public GameObject objectiveText;
    private string filePathObjectives = @"..\Delta2X\Assets\Database\Objectives.txt";
    private string filePathActiveObjectives = @"..\Delta2X\Assets\Database\ActiveObjectives.txt";
    public string[] allObjectiveLines;
    public string[] activeObjectiveLines;
    public string objectiveTextTask0;
    public string objectiveTextTask1;
    public string objectiveTextTask2;
    public string objectiveTextTask3;
    public string objectiveTextTask4;
    public string objectiveTextTask5;
    public string objectiveTextTask6;
    public string objectiveTextTask7;
    public string objectiveTextTask8;
    public string objectiveTextTask9;
    public List<string> currentObjectivesList;
    public List<int> completedObjectivesList;
    public int amountOfActiveObjectives;
    public int amountOfCompletedObjectives;

    //Methods that update the strings for objectives after you interacted with anything

    public void startDayOrNight(int task0, int task1, int task2, int task3, int task4, int task5, int task6, int task7, int task8, int task9)
    {
        objectiveText = GameObject.FindWithTag("Objectives");
        currentObjectivesList = new List<string>();
        completedObjectivesList = new List<int>();
        readFileAllObjectives();
        completedObjectivesList.Clear();
        currentObjectivesList.Clear();
        addObjectivesToList(task0, task1, task2, task3, task4, task5, task6, task7, task8, task9);
        creatFileWithCurrentObjectives();
        readFileCurrentObjectives();
        activateObjectiveList();
    }

    public void readFileAllObjectives()
    {
        if (File.Exists(filePathObjectives))
        {
            allObjectiveLines = File.ReadAllLines(filePathObjectives);
        }
    }

    public void addObjectivesToList(int task0, int task1, int task2, int task3, int task4, int task5, int task6, int task7, int task8, int task9) //you can add a maximum of 10 tasks to the list
    {
        if (task0 >= 15)
        {
            clearObjectiveDatabase();

            if (string.IsNullOrWhiteSpace(allObjectiveLines[task0]) == false)
            {
                objectiveTextTask0 = allObjectiveLines[task0];
                currentObjectivesList.Add(objectiveTextTask0);
            }

            if (string.IsNullOrWhiteSpace(allObjectiveLines[task1]) == false)
            {
                objectiveTextTask1 = allObjectiveLines[task1];
                currentObjectivesList.Add(objectiveTextTask1);
            }

            if (string.IsNullOrWhiteSpace(allObjectiveLines[task2]) == false)
            {
                objectiveTextTask2 = allObjectiveLines[task2];
                currentObjectivesList.Add(objectiveTextTask2);
            }

            if (string.IsNullOrWhiteSpace(allObjectiveLines[task3]) == false)
            {
                objectiveTextTask3 = allObjectiveLines[task3];
                currentObjectivesList.Add(objectiveTextTask3);
            }

            if (string.IsNullOrWhiteSpace(allObjectiveLines[task4]) == false)
            {
                objectiveTextTask4 = allObjectiveLines[task4];
                currentObjectivesList.Add(objectiveTextTask4);
            }

            if (string.IsNullOrWhiteSpace(allObjectiveLines[task5]) == false)
            {
                objectiveTextTask5 = allObjectiveLines[task5];
                currentObjectivesList.Add(objectiveTextTask5);
            }

            if (string.IsNullOrWhiteSpace(allObjectiveLines[task6]) == false)
            {
                objectiveTextTask6 = allObjectiveLines[task6];
                currentObjectivesList.Add(objectiveTextTask6);
            }

            if (string.IsNullOrWhiteSpace(allObjectiveLines[task7]) == false)
            {
                objectiveTextTask7 = allObjectiveLines[task7];
                currentObjectivesList.Add(objectiveTextTask7);
            }

            if (string.IsNullOrWhiteSpace(allObjectiveLines[task8]) == false)
            {
                objectiveTextTask8 = allObjectiveLines[task8];
                currentObjectivesList.Add(objectiveTextTask8);
            }

            if (string.IsNullOrWhiteSpace(allObjectiveLines[task9]) == false)
            {
                objectiveTextTask9 = allObjectiveLines[task9];
                currentObjectivesList.Add(objectiveTextTask9);
            }
        } 
        else
        {
            Debug.Log("No objectives assigned from file or objective is negative");
        }
    }

    public void creatFileWithCurrentObjectives()
    {
        if (File.Exists(filePathActiveObjectives))
        {
            File.WriteAllLines(filePathActiveObjectives, currentObjectivesList);
        }
    }

    public void readFileCurrentObjectives()
    {
        if (File.Exists(filePathActiveObjectives))
        {
            activeObjectiveLines = File.ReadAllLines(filePathActiveObjectives);
        }
    }

    public void activateObjectiveList()
    {
        objectiveText.GetComponent<TextMeshProUGUI>().enabled = true;
        objectiveText.GetComponent<TextMeshProUGUI>().text = "";
        foreach (string ln in activeObjectiveLines) {
            objectiveText.GetComponent<TextMeshProUGUI>().text += ln + "\n";
        }
    }

    public void updateObjectiveList(int taskThatIsCompleted)
    {
        if (taskThatIsCompleted >= 10)
        {
            Debug.Log("This interaction does not complete an objective");
        }
        else
        {
            readFileAllObjectives();
            readFileCurrentObjectives();

            if (completedObjectivesList.Contains(taskThatIsCompleted) == false && activeObjectiveLines.Length > taskThatIsCompleted)
            {
                activeObjectiveLines[taskThatIsCompleted] += allObjectiveLines[3];  //adds " (completed)" to the completed tasks in the list and adds it to the activeObjectives file
                completedObjectivesList.Add(taskThatIsCompleted);

                amountOfCompletedObjectives++;
            } else
            {
                Debug.Log("This is allready completed or interaction tries to complete an objective that does not exist. If so check if all objectives are correctly assigned");
            }

            if (File.Exists(filePathActiveObjectives))
            {
                File.WriteAllLines(filePathActiveObjectives, activeObjectiveLines);
            }

            activateObjectiveList();
        }
    }

    public void deactivateObjectiveList()
    {
        objectiveText.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    public bool checkIfAllObjectivesAreComplete()
    {
        readFileCurrentObjectives();
        amountOfActiveObjectives = activeObjectiveLines.Length; //counts the amount of active objectives in the objectives file

        if (amountOfCompletedObjectives == amountOfActiveObjectives)
        {
            //Debug.Log("All objectives are complete");
            Debug.Log("Amount of objectives: " + amountOfActiveObjectives + " Completed objectives nr: " + amountOfCompletedObjectives);
            return true;
        } else
        {
            Debug.Log("Amount of objectives: " + amountOfActiveObjectives + " Completed objectives nr: " + amountOfCompletedObjectives);
            Debug.Log("Not all objectives are completed or counting went wrong");
            return false;
        }
    }

    public void clearObjectiveDatabase()
    {
        amountOfCompletedObjectives = 0;
        amountOfActiveObjectives = 0;
    }
}
