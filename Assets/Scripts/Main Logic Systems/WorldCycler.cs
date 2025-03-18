using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class WorldCycler : MonoBehaviour
{
    public Objectives objectives;
    public ChangeDay changeDay;
    public Subtitles subtitles;
    public CursorState cursorState;
    public ClearStorage clearStorage;
    public ChangeWorldWhenAsleep changeWorldWhenAsleep;
    public FinishedMenu finishedMenu;

    public GameObject moneyGoal;
    public GameObject moneyCount;
    public GameObject daysLeft;
    public GameObject dailyModels;

    public AudioSource audioSource;
    public AudioClips audioClips;

    public int amountOfDaysToAchiveGoal;
    public int amountOfDaysToAchiveGoalTimer;
    public int dayCount; //the first day starts at 0. Even (0, 2, 4, 6 ...) numbers mean it is day uneven numbers means it is night (1, 3, 5 ...)
    public int amountOfDestroyedCars;
    public int moneyGoalCount;
    public int moneyCountnr;
    public int moneyPerCarRepair;
    public bool itIsDay;
    public int day;
    public bool isTABpopUpTriggerd;
    public bool gameIsPaused;
    public bool gameIsFinished;

    public int subNrNotAllCarsRepaired = 17;
    public int subDurNotAllCarsRepaired = 3;
    public int subNrNotAllObjectivesCompleted = 15;
    public int subDurNotAllObjectivesCompleted = 3;
    public int subNrNotAllClientsAreHelped = 19;
    public int subDurNotAllClientsAreHelped = 3;
    public int subNrStillCarsInGarage = 26;
    public int subDurStillCarsInGarage = 5;


    float lastStep, timeBetweenSteps = 0.2f; //waits 0.2 seconds before pressing the bed again

    List<int> usedDayCount = new List<int>();

    public void Awake()
    { 
        objectives = FindObjectOfType<Objectives>();
        changeDay = FindObjectOfType<ChangeDay>();
        subtitles = FindObjectOfType<Subtitles>();
        clearStorage.clearStorage();
        audioClips = FindObjectOfType<AudioClips>();
    }

    public void Start()
    {
        dayCount = 0;
        amountOfDaysToAchiveGoal = 4;
        amountOfDaysToAchiveGoalTimer = 3;
        moneyGoalCount = 600;
        moneyPerCarRepair = 70;
        moneyGoal.GetComponent<TextMeshProUGUI>().text = "Goal €" + moneyGoalCount;
        daysLeft.GetComponent<TextMeshProUGUI>().text = "Days left " + amountOfDaysToAchiveGoalTimer;
        amountOfDestroyedCars = 0;
        moneyCountnr = 0;
        startNewDayOrNight(); //starts a new day the moment a player joins the game
        lastStep = Time.time;
        day = 1;
        isTABpopUpTriggerd = false;
        gameIsPaused = false;
        gameIsFinished = false;
}

    public void Update()
    {
        moneyCount.GetComponent<TextMeshProUGUI>().text = "Wallet €" + moneyCountnr;
    }

    public void cycle()
    {
        if (Time.time - lastStep > timeBetweenSteps) //waits 0.2 seconds before pressing the button again
        {
            lastStep = Time.time;
            Debug.Log("Are all objectives completed: " + objectives.checkIfAllObjectivesAreComplete());

            if (objectives.checkIfAllObjectivesAreComplete() == true)
            {
                if (changeWorldWhenAsleep.isGarageRepairLotOccupied1 == false && changeWorldWhenAsleep.isGarageRepairLotOccupied2 == false)
                {
                    startNewDayOrNight();
                }
                else
                {
                    subtitles.activateSubtitlesAndSetDuration(subNrStillCarsInGarage, subDurStillCarsInGarage);
                }
            }
            else
            {
                Debug.Log("Not all tasks are completed");
                subtitles.activateSubtitlesAndSetDuration(subNrNotAllObjectivesCompleted, subDurNotAllObjectivesCompleted);
            }
        }
    }



    public void startNewDayOrNight() //start new day or night activates when the player goes to sleep and restarts a new cyle of task and resets the world
    {
        changeDay.isItDayOrNight();
        if (usedDayCount.Contains(dayCount))
        {
            Debug.Log("This day or night has allready begun/happened");
        }
        else
        {
            switch (dayCount)
            {
                case 0: //day 1 //if there are less then 10 objectives use number 1 for a blank objective
                        //objectives.startDayOrNight(15, 1, 17, 18, 19, 20, 21, 22, 23, 24); //this is were we decide which tasks from the file with all tasks, will be added to the objective list based on the day/night timing/counter
                    wakeUpFirstDay(27, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
                case 1: //night 1 //executed if it is day
                    sleepForNight(15, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
                case 2: //day 2 //executed if it is night
                    sleepForDay(28, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
                case 3: //night 2 //executed if it is day
                    sleepForNight(15, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
                case 4: //day 3 //executed if it is night
                    sleepForDay(28, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
                case 5: //night 3 //executed if it is day
                    sleepForNight(15, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
                case 6: //day 4 //executed if it is night
                    sleepForDay(28, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
                case 7: //night 4 //executed if it is day
                    sleepForNight(15, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
                case 8: //day 5 //executed if it is night
                    sleepForDay(28, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
                default:
                    Debug.Log("The daycount is messed up or higher that availeble days. Daycount: " + dayCount);
                    break;
            }
        }
    }

    public void wakeUpFirstDay(int Task0, int Task1, int Task2, int Task3, int Task4, int Task5, int Task6, int Task7, int Task8, int Task9)
    {
        audioSource.PlayOneShot(audioClips.daySound);
        dailyModels.SetActive(true);
        itIsDay = true;
        cursorState.cursorVisible = false;
        changeDay.changeSkybox(changeDay.isItDay);
        objectives.startDayOrNight(Task0, Task1, Task2, Task3, Task4, Task5, Task6, Task7, Task8, Task9);
        usedDayCount.Add(dayCount);
        increaseHalfADays();
        day++;
        Debug.Log("Day " + day);
    }

    public void sleepForDay(int Task0, int Task1, int Task2, int Task3, int Task4, int Task5, int Task6, int Task7, int Task8, int Task9)
    {
        itIsDay = true;
        cursorState.cursorVisible = true;
        changeDay.sleep();
        StartCoroutine(wakeUp(Task0, Task1, Task2, Task3, Task4, Task5, Task6, Task7, Task8, Task9));
        usedDayCount.Add(dayCount);
        increaseHalfADays();
        day++;
        Debug.Log("Day " + day);
    }

    public void sleepForNight(int Task0, int Task1, int Task2, int Task3, int Task4, int Task5, int Task6, int Task7, int Task8, int Task9)
    {
        Debug.Log("Are all clients helped: " + changeWorldWhenAsleep.areAllClientsInvisible());

        if (changeWorldWhenAsleep.areAllClientsInvisible() == true && changeWorldWhenAsleep.areAllCarsRepairedCheck() == true)
        {
            Debug.Log("Are all cars repaired: " + changeWorldWhenAsleep.areAllCarsRepairedCheck());

            if (changeWorldWhenAsleep.areAllCarsRepairedCheck() == true)
            {
                amountOfDaysToAchiveGoalTimer--;
                itIsDay = false;
                cursorState.cursorVisible = true;
                changeDay.sleep();
                StartCoroutine(wakeUp(Task0, Task1, Task2, Task3, Task4, Task5, Task6, Task7, Task8, Task9));
                usedDayCount.Add(dayCount);
                increaseHalfADays();
                Debug.Log("Day " + day);
                finishedMenu.isGameFinished();
            }
            else
            {
                Debug.Log("Not all cars are repaired");
                subtitles.activateSubtitlesAndSetDuration(subNrNotAllCarsRepaired, subDurNotAllCarsRepaired);
            }
        }
        else
        {
            Debug.Log("Not all clients are helped");
            subtitles.activateSubtitlesAndSetDuration(subNrNotAllClientsAreHelped, subDurNotAllClientsAreHelped);
        }
    }

    IEnumerator wakeUp(int Task0, int Task1, int Task2, int Task3, int Task4, int Task5, int Task6, int Task7, int Task8, int Task9)
    {
        yield return new WaitForSeconds(3);
        daysLeft.GetComponent<TextMeshProUGUI>().text = "Days left: " + amountOfDaysToAchiveGoalTimer;
        changeDay.changeSkybox(changeDay.isItDay);
        if(changeDay.isItDay == true)
        {
            dailyModels.SetActive(true);
            audioSource.PlayOneShot(audioClips.daySound);
        }
        else
        {
            dailyModels.SetActive(false);
            audioSource.PlayOneShot(audioClips.nightSound);
        }
        changeWorldWhenAsleep.changeWorldWhenAsleep();
        objectives.startDayOrNight(Task0, Task1, Task2, Task3, Task4, Task5, Task6, Task7, Task8, Task9);
        cursorState.cursorVisible = false;
        changeDay.wakeUp();
    }

    public void increaseHalfADays()
    {
        dayCount++;
        Debug.Log("It is now halfdaycount: " + dayCount);
        Debug.Log("Is it day: " + itIsDay);
    }

    
}
