using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeInteract : MonoBehaviour
{
    public GameObject firstTimeE;
    public bool isTriggerd1 = false;

    void OnTriggerEnter()
    {
        if (isTriggerd1 == false)
        {
            Debug.Log("Trigger activated");
            firstTimeE.SetActive(true);
            isTriggerd1 = true;
            StartCoroutine(disableFirstTimeUseE());
        }
    }

    public IEnumerator disableFirstTimeUseE()
    {
        yield return new WaitForSeconds(3);
        firstTimeE.SetActive(false);
    }
}
