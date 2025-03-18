using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToHospital : MonoBehaviour
{
    public Player player;
    public GameObject hospitalDoorsClosed;
    Vector3 hospitalRoom = new Vector3(95.796f, -19.45f, 27.113f);

    void OnTriggerEnter()
    {
        Debug.Log("Teleported player to hospitalroom");
        player.transform.localPosition = hospitalRoom;
        hospitalDoorsClosed.SetActive(true);
    }
}
