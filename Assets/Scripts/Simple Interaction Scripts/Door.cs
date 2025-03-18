using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;

    public AudioClips audioClips;

    public bool isDoorAccesable;
    public bool isDoorAllreadyOpen;

    void Start()
    {
        animator = transform.parent.gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioClips = FindObjectOfType<AudioClips>();
        isDoorAllreadyOpen = false;
    }

    public void doorAcces()
    {
        if (isDoorAccesable)
        {
            if (isDoorAllreadyOpen)
            {
                animator.SetTrigger("Door closed");
                audioSource.PlayOneShot(audioClips.doorClosing);
                isDoorAllreadyOpen = false;                          
            } 
            else
            {
                animator.SetTrigger("Door open");
                audioSource.PlayOneShot(audioClips.doorOpening);
                isDoorAllreadyOpen = true;
            }
        } 
        else
        {
            animator.SetTrigger("Door handle");
            audioSource.PlayOneShot(audioClips.doorLocked);
        }
    }
}
