using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableModels : MonoBehaviour
{
    //public GameObject = ...;

    public void enableModelsForDay(int day)
    {
        switch (day)
        {
            case 0: //day 1
                //...GetComponent<MeshRenderen>().enable = true;
                // ...GetComponent<BoxCollider>().enabled = false;
                break;
            case 1: //day 2 

                break;
            case 2: //day 3 
                
                break;
            case 3: //day 4

                break;
            case 4: //day 5
                
                break;
            case 5: //day 6 

                break;
            case 6: //day 7 
              
                break;
            case 7: //day 8

                break;
            case 8: //day 9 
               
                break;
            default:
                Debug.Log("Tried to enable something on a non existing day");
                break;
        }
    }

    public void disableModelsForNight(int night)
    {
        switch (night)
        {
            case 0: //night 1

                break;
            case 1: //night 2 

                break;
            case 2: //night 3 

                break;
            case 3: //night 4

                break;
            case 4: //night 5

                break;
            case 5: //night 6 

                break;
            case 6: //night 7 

                break;
            case 7: //night 8

                break;
            case 8: //night 9 

                break;
            default:
                Debug.Log("Tried to enable something on a non existing night");
                break;
        }
    }

    public void enableModelsForNight(int night)
    {
        switch (night)
        {
            case 0: //night 1

                break;
            case 1: //night 2 

                break;
            case 2: //night 3 

                break;
            case 3: //night 4

                break;
            case 4: //night 5

                break;
            case 5: //night 6 

                break;
            case 6: //night 7 

                break;
            case 7: //night 8

                break;
            case 8: //night 9 

                break;
            default:
                Debug.Log("Tried to enable something on a non existing night");
                break;
        }
    }

    public void disableModelsForDay(int day)
    {
        switch (day)
        {
            case 0: //day 1
                //...GetComponent<CarState>().enable = true;
                break;
            case 1: //day 2 

                break;
            case 2: //day 3 

                break;
            case 3: //day 4

                break;
            case 4: //day 5

                break;
            case 5: //day 6 

                break;
            case 6: //day 7 

                break;
            case 7: //day 8

                break;
            case 8: //day 9 

                break;
            default:
                Debug.Log("Tried to enable something on a non existing day");
                break;
        }
    }
}
