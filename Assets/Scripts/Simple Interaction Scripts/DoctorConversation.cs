using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorConversation : MonoBehaviour
{

    public Player player;
    public WorldCycler worldCycler;
    public Subtitles subtitles;
    public AudioSource audioSource;
    public AudioClips audioClips;
    Vector3 hospitalParkingLot = new Vector3(84.73f, 0.5f, 26.56f);
    bool beganTalking = false;
    bool isTalking = true;

    public int[] subtitlesDoctorConversationNumbers;
    public int[] subtitlesAfterDoctorNumbers;
    private int currentIndex = 0;
    private int currentIndex2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        worldCycler = FindObjectOfType<WorldCycler>();
        subtitles = FindObjectOfType<Subtitles>();
        audioClips = FindObjectOfType<AudioClips>();

        //subtitlesDoctorConversationNumbers = new int[] { 32, 33 };
        subtitlesDoctorConversationNumbers = new int[] { 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47 };
        subtitlesAfterDoctorNumbers = new int[] { 48, 49, 50, 51 };
    }

    public void talkWithFather()
    {

    }

    

    public void talkWithDoctor()
    {
        if (beganTalking == false)
        {
            beganTalking = true;

            InvokeRepeating("DisplayNextSubtitle", 0f, 5f);
        }
    }

    private void DisplayNextSubtitle()
    {
        if (currentIndex < subtitlesDoctorConversationNumbers.Length)
        {
            audioSource.PlayOneShot(audioClips.peopleTalkingVoice1);
            subtitles.activateSubtitlesForConversation(subtitlesDoctorConversationNumbers[currentIndex]);
            currentIndex++;
        }
        else
        {
            //All subtitles have been displayed, so stop the repeating method
            CancelInvoke("DisplayNextSubtitle");
            StartCoroutine(teleportPlayer(3));
        }
    }

    IEnumerator teleportPlayer(int duration)
    {
        yield return new WaitForSeconds(duration);
        Debug.Log("Teleported player to outside");
        worldCycler.daysLeft.SetActive(true);
        worldCycler.moneyGoal.SetActive(true);
        subtitles.activateSubtitles(1);
        player.transform.localPosition = hospitalParkingLot;
        InvokeRepeating("startTalkToSelf", 0f, 5f);
    }

    private void startTalkToSelf()
    {
        if (currentIndex2 < subtitlesAfterDoctorNumbers.Length)
        {
            subtitles.activateSubtitlesForConversation(subtitlesAfterDoctorNumbers[currentIndex2]);
            currentIndex2++;
        }
        else
        {
            //All subtitles have been displayed, so stop the repeating method
            CancelInvoke("startTalkToSelf");
            StartCoroutine(stopConversation(3));
        }
    }

    IEnumerator stopConversation(int duration)
    {
        yield return new WaitForSeconds(duration);
        Debug.Log("Starts talking to hisself");
        subtitles.activateSubtitles(1);
    }
}
