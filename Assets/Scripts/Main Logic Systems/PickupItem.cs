using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PickupItem : MonoBehaviour
{
    public Inventory inventory;
    public Subtitles subtitles;
    public WorldCycler worldCycler;
    public AudioClips audioClips;

    public AudioSource audioSource;

    public int subNrWrenchUsefull = 21;
    public int subDurWrenchUsefull = 3;
    public int subNrHammerUsefull = 22;
    public int subDurHammerUsefull = 3;

    public GameObject firstTimeTAB;

    void Start()
    {
        subtitles = FindObjectOfType<Subtitles>();
        worldCycler = FindObjectOfType<WorldCycler>();
        inventory = FindObjectOfType<Inventory>();
        audioClips = FindObjectOfType<AudioClips>();
    }

    public void pickUpWrench()
    {
        triggerPopup();
        audioSource.PlayOneShot(audioClips.pickUpItem);
        inventory.loadItemInInventory("wrench");
        inventory.addItemsToDatabase("wrench");
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        subtitles.activateSubtitlesAndSetDuration(subNrWrenchUsefull, subDurWrenchUsefull);
    }

    public void pickUpHammer()
    {
        triggerPopup();
        audioSource.PlayOneShot(audioClips.pickUpItem);
        inventory.loadItemInInventory("hammer");
        inventory.addItemsToDatabase("hammer");
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        subtitles.activateSubtitlesAndSetDuration(subNrHammerUsefull, subDurHammerUsefull);
    }

    public void triggerPopup()
    {
        Debug.Log(worldCycler.isTABpopUpTriggerd);
        if (worldCycler.isTABpopUpTriggerd == false)
        {
            Debug.Log("Trigger activated");
            firstTimeTAB.SetActive(true);
            worldCycler.isTABpopUpTriggerd = true;
            StartCoroutine(disableFirstTimeUseTAB());
        }
    }

    public IEnumerator disableFirstTimeUseTAB()
    {
        yield return new WaitForSeconds(3);
        firstTimeTAB.SetActive(false);
    }
}
