using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoor : MonoBehaviour
{
    public Animator animatorGarageDoor;
    public Animator animatorButton;
    public AudioSource audioSourceButton;
    public AudioSource audioSourceGarageDoor;

    public GameObject garageDoor;

    public AudioClips audioClips;

    public bool isDoorAccesable;
    public bool isDoorAllreadyOpen;

    float lastStep, timeBetweenSteps = 8f; //waits 0.2 seconds before pressing the bed again

    void Start()
    {
        animatorGarageDoor = garageDoor.GetComponent<Animator>();
        animatorButton = GetComponent<Animator>();
        audioSourceButton = GetComponent<AudioSource>();
        audioSourceGarageDoor = garageDoor.GetComponent<AudioSource>();
        audioClips = FindObjectOfType<AudioClips>();
        isDoorAllreadyOpen = false;
    }

    public void doorAcces()
    {
        if (isDoorAccesable)
        {
            if (Time.time - lastStep > timeBetweenSteps) //waits 0.2 seconds before pressing the button again
            {
                lastStep = Time.time;
                if (isDoorAllreadyOpen)
                {
                    animatorButton.SetTrigger("Push button");
                    animatorGarageDoor.SetTrigger("Door closed");
                    audioSourceButton.PlayOneShot(audioClips.buttonGarageDoor);
                    audioSourceGarageDoor.PlayOneShot(audioClips.garageDoorMoving);
                    isDoorAllreadyOpen = false;
                }
                else
                {
                    animatorButton.SetTrigger("Push button");
                    animatorGarageDoor.SetTrigger("Door open");
                    audioSourceButton.PlayOneShot(audioClips.buttonGarageDoor);
                    audioSourceGarageDoor.PlayOneShot(audioClips.garageDoorMoving);
                    isDoorAllreadyOpen = true;
                }
            }
        }
        else
        {
            Debug.Log("Door not accesable");
        }


    }
}