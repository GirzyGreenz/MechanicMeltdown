using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDay : MonoBehaviour
{
    public Material skyboxDay;
    public Material skyboxNight;

    public Animator fadeScreenAnimator;
    public GameObject fadeImage;

    public WorldCycler worldCycler;

    public bool isItDay;

    public void Start()
    {
        fadeScreenAnimator = fadeImage.GetComponent<Animator>();
    }

    public void changeSkybox(bool isItDayTime)
    {
        if (isItDayTime == false)
        {
            RenderSettings.skybox = skyboxNight;
        }
        else
        {
            RenderSettings.skybox = skyboxDay;
        }
    }

    public void sleep()
    {
        fadeImage.GetComponent<Image>().enabled = true;
        fadeScreenAnimator.SetTrigger("TriggerFadeIn");
    }

    public void wakeUp()
    {
        fadeImage.GetComponent<Image>().enabled = true;
        fadeScreenAnimator.SetTrigger("TriggerFadeOut");
    }

    public void isItDayOrNight()
    {
        if (worldCycler.dayCount % 2 == 0)
        {
            isItDay = true;
        }
        else
        {
            isItDay = false;
        }
    }
}
