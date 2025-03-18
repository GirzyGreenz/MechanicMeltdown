using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeUseTab : MonoBehaviour
{
    public GameObject firstTimeTAB;
    public bool isTriggerd1 = false;

    void OnTriggerEnter()
    {
        if (isTriggerd1 == false)
        {
            Debug.Log("Trigger activated");
            firstTimeTAB.SetActive(true);
            isTriggerd1 = true;
            StartCoroutine(disableFirstTimeUseTAB());
        }
    }

    public IEnumerator disableFirstTimeUseTAB()
    {
        yield return new WaitForSeconds(3);
        firstTimeTAB.SetActive(false);
    }
}
