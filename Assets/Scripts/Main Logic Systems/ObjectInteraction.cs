/* 
 * OBJECT INTERACTION
 * Attach this to every object that needs to be interactible.
 * Here you can define:
 * - What is the object's name (used only for debugging)
 * - What is its icon (used as a crosshair)
 * - What function should it run upon interaction (make a separate script with a public function
 *   and connect it here)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ObjectInteraction : MonoBehaviour
{
    public string objectName;
    public Sprite cursor;
    public UnityEvent interactFunction;
    public WorldCycler worldCycler;
    public Objectives objectives;
    public int dayCompletedObjective = 10; //10 or higher means the interaction does not complete an objective
    public int nightCompletedObjective = 10; //10 or higher means the interaction does not complete an objective

    private void Awake()
    {
        // Automatically search for the Objectives script in the scene and get a reference
        objectives = FindObjectOfType<Objectives>();
        worldCycler = FindObjectOfType<WorldCycler>();
    }

    public void OnInteract() {
      Debug.Log("Interacted with " + objectName);
        if (interactFunction != null) 
        {
            if (worldCycler.itIsDay == true)
            {
                objectives.updateObjectiveList(dayCompletedObjective);
            }

            if (worldCycler.itIsDay == false)
            {
                objectives.updateObjectiveList(nightCompletedObjective);
            }
        
            interactFunction.Invoke();
        }
        else
        {
            Debug.Log("Does nothing");
        }
    }
}
