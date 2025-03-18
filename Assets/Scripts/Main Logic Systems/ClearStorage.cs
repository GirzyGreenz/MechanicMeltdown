using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStorage : MonoBehaviour
{
    public Inventory inventory;

    public void clearStorage()
    {
        inventory.clearInventoryDatabase();
    }
}
