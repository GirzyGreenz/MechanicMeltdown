using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Inventory : MonoBehaviour
{
    public bool hasWrench = false;
    public bool hasHammer = false;

    public bool isInventorySlot1Full = false;
    public bool isInventorySlot2Full = false;

    public GameObject inventorySlot1;
    public GameObject inventorySlot2;

    public string filePathInventory = @"..\Delta2X\Assets\Database\Inventory.txt";
    //public string filePathHammerImg = @"..\Delta2X\Assets\UI\Inventory\hammer.png";
    //public string filePathWrenchImg = @"..\Delta2X\Assets\UI\Inventory\wrench.png";
    public Sprite hammerSprite;
    public Sprite wrenchSprite;


    public string[] inventoryLines;
    public List<string> inventoryList;

    void Start()
    {
        inventoryList = new List<string>();
    }

    public void addItemsToDatabase(string itemName)
    {
        //readInventoryData();

        inventoryList.Add(itemName);

        /*
        if (File.Exists(filePathInventory))
        {
            File.WriteAllLines(filePathInventory, inventoryList);
        }*/
    }

    public void clearInventoryDatabase()
    {
        if (File.Exists(filePathInventory))
        {
            File.WriteAllText(filePathInventory, string.Empty);
        }
    }

    public void loadItemInInventory(string loadedItem)
    {
        switch (loadedItem)
        {
            case "wrench":
                loadImageInInventory(wrenchSprite);
                break;
            case "hammer":
                loadImageInInventory(hammerSprite);
                break;
            default:

                break;
        }
    }

    public void loadImageInInventory(Sprite img)
    {
        if (isInventorySlot1Full == false)
        {
            inventorySlot1.GetComponent<Image>().sprite = img;
            inventorySlot1.GetComponent<Image>().enabled = true;
            isInventorySlot1Full = true;
        }
        else if (isInventorySlot2Full == false)
        {
            inventorySlot2.GetComponent<Image>().sprite = img;
            inventorySlot2.GetComponent<Image>().enabled = true;
            isInventorySlot2Full = true;
        }
        else
        {
            Debug.Log("All inventory slots are full");
        }
    }

    /*
    public void readInventoryData()
    {
        //inventoryLines.Clear();

        if (File.Exists(filePathInventory))
        {
            inventoryLines = File.ReadAllLines(filePathInventory);
        }
    }*/
}
