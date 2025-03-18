using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliënt : MonoBehaviour
{
    public AudioSource audioSource;

    public WorldCycler worldCycler;
    public Subtitles subtitles;
    public FinishedMenu finishedMenu;
    public ChangeWorldWhenAsleep changeWorldWhenAsleep;
    public AudioClips audioClips;
    public Objectives objectives;

    public bool isClientHelped = false;
    public bool isClientVisible = false;

    public int subNrCanYouRepairMyCar = 18;
    public int subDurCanYouRepairMyCar = 3;
    public int subNrAllreadyRepairedMyCar = 24;
    public int subDurAllreadyRepairedMyCar = 3;
    public int subNrThanksForRepairing = 25;
    public int subDurThanksForRepairing = 3;

    void Start()
    {
        worldCycler = FindObjectOfType<WorldCycler>();
        subtitles = FindObjectOfType<Subtitles>();
        objectives = FindObjectOfType<Objectives>();
        finishedMenu = FindObjectOfType<FinishedMenu>();
        changeWorldWhenAsleep = FindObjectOfType<ChangeWorldWhenAsleep>();
        audioClips = FindObjectOfType<AudioClips>();
    }

    public void giveMoneyForCar1()
    {
        if (isClientHelped == false)
        {
            if (changeWorldWhenAsleep.isClientsCar1Fixed == true)
            {
                objectives.updateObjectiveList(0);
                audioSource.PlayOneShot(audioClips.peopleTalkingVoice1);
                worldCycler.moneyCountnr += worldCycler.moneyPerCarRepair; //adds money to counter if car is repaired
                isClientVisible = false;
                isClientHelped = true;
                subtitles.activateSubtitlesAndSetDuration(subNrThanksForRepairing, subDurThanksForRepairing);
                StartCoroutine(letAClientLeave());
            }
            else
            {
                audioSource.PlayOneShot(audioClips.peopleTalkingVoice1);
                subtitles.activateSubtitlesAndSetDuration(subNrCanYouRepairMyCar, subDurCanYouRepairMyCar);
            }
        }
        else
        {
            audioSource.PlayOneShot(audioClips.peopleTalkingVoice1);
            subtitles.activateSubtitlesAndSetDuration(subNrAllreadyRepairedMyCar, subDurAllreadyRepairedMyCar);
        }
    }

    public void giveMoneyForCar2()
    {
        if (isClientHelped == false)
        {
            if (changeWorldWhenAsleep.isClientsCar2Fixed == true)
            {
                audioSource.PlayOneShot(audioClips.peopleTalkingVoice2);
                worldCycler.moneyCountnr += worldCycler.moneyPerCarRepair; //adds money to counter if car is repaired
                isClientVisible = false;
                isClientHelped = true;
                subtitles.activateSubtitlesAndSetDuration(subNrThanksForRepairing, subDurThanksForRepairing);
                StartCoroutine(letAClientLeave());
            }
            else
            {
                audioSource.PlayOneShot(audioClips.peopleTalkingVoice2);
                subtitles.activateSubtitlesAndSetDuration(subNrCanYouRepairMyCar, subDurCanYouRepairMyCar);
            }
        }
        else
        {
            audioSource.PlayOneShot(audioClips.peopleTalkingVoice2);
            subtitles.activateSubtitlesAndSetDuration(subNrAllreadyRepairedMyCar, subDurAllreadyRepairedMyCar);
        }
    }

    public void giveMoneyForCar3()
    {
        if (isClientHelped == false)
        {
            if (changeWorldWhenAsleep.isClientsCar3Fixed == true)
            {
                audioSource.PlayOneShot(audioClips.peopleTalkingVoice1);
                worldCycler.moneyCountnr += worldCycler.moneyPerCarRepair; //adds money to counter if car is repaired
                isClientVisible = false;
                isClientHelped = true;
                subtitles.activateSubtitlesAndSetDuration(subNrThanksForRepairing, subDurThanksForRepairing);
                StartCoroutine(letAClientLeave());
            }
            else
            {
                audioSource.PlayOneShot(audioClips.peopleTalkingVoice1);
                subtitles.activateSubtitlesAndSetDuration(subNrCanYouRepairMyCar, subDurCanYouRepairMyCar);
            }
        }
        else
        {
            audioSource.PlayOneShot(audioClips.peopleTalkingVoice1);
            subtitles.activateSubtitlesAndSetDuration(subNrAllreadyRepairedMyCar, subDurAllreadyRepairedMyCar);
        }
    }

    IEnumerator letAClientLeave()
    {
        yield return new WaitForSeconds(3);
        gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
}
