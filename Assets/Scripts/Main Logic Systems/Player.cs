using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Player : MonoBehaviour
{
    public CursorState cursorState;
    public Inventory inventory;

    public bool hasWrenchSelected = false;
    public bool hasHammerSelected = false;

    public int selectedItemCounter = 0;

    public GameObject inventoryUI;

    public int highLighted_1 = 2;
    public int highLighted_2 = 5;

    public KeyCode tab = KeyCode.Tab;
    float lastStep, timeBetweenSteps = 0.2f; //waits 0.2 seconds before pressing the button again

    void Update()
    {
        if (cursorState.cursorVisible == false)
        {
            selectItemInUIBar();
        }
    }

    public void selectItemInUIBar()
    {
        if (Time.time - lastStep > timeBetweenSteps) //waits 0.2 seconds before pressing the button again
        {
            lastStep = Time.time;
            //Selecting items
            if (Input.GetKey(tab))
            {
                Debug.Log("Pressed TAB to try switch items");

                if (inventory.inventoryList.Count > 0)
                {

                    lastStep = Time.time;
                    Debug.Log("Amount of items in inventoryList: " + inventory.inventoryList.Count);

                    switch (selectedItemCounter) //the amount of switch cases are based on the amount of items
                    {
                        case 0:
                            disableAllSelected();
                            inventoryUI.transform.GetChild(highLighted_1).GetComponent<Image>().enabled = true;
                            enableItemInHand(selectedItemCounter);
                            selectedItemCounter++;
                            break;
                        case 1:
                            if (inventory.inventoryList.Count > 1)
                            {
                                disableAllSelected();
                                inventoryUI.transform.GetChild(highLighted_2).GetComponent<Image>().enabled = true;
                                enableItemInHand(selectedItemCounter);
                                selectedItemCounter = 0;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Debug.Log("Inventory still empty, inventory  " + inventory.inventoryList.Count);
                }
            }
        }
    }

    public void enableItemInHand(int itemInlist)
    {
        Debug.Log("Selected item: " + inventory.inventoryList[itemInlist]);
        switch (inventory.inventoryList[itemInlist])
        {
            case "wrench":
                disableAllSelectedItems();
                hasWrenchSelected = true;
                break;
            case "hammer":
                disableAllSelectedItems();
                hasHammerSelected = true;
                break;
            default:
                disableAllSelectedItems();
                break;
        }
    }

    public void disableAllSelectedItems()
    {
        hasWrenchSelected = false;
        hasHammerSelected = false;
    }

    public void disableAllSelected()
    {
        inventoryUI.transform.GetChild(highLighted_1).GetComponent<Image>().enabled = false;
        inventoryUI.transform.GetChild(highLighted_2).GetComponent<Image>().enabled = false;
    }
}
