using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorldWhenAsleep : MonoBehaviour
{
    public WorldCycler worldCycler;
    public EnableDisableModels enableDisableModels;

    public GameObject destructableCars;
    public GameObject allLightingObjects;
    public GameObject client1;
    public GameObject client2;
    public GameObject client3;

    public bool isGarageParkingLotOccupied1 = false;
    public Vector3 garageParkingLotPosition1;
    public Vector3 garageParkingLotRotation1;

    public bool isGarageParkingLotOccupied2 = false;
    public Vector3 garageParkingLotPosition2;
    public Vector3 garageParkingLotRotation2;

    public bool isGarageParkingLotOccupied3 = false;
    public Vector3 garageParkingLotPosition3;
    public Vector3 garageParkingLotRotation3;

    public bool isGarageRepairLotOccupied1 = false;
    public Vector3 garageRepairLotPosition1;
    public Vector3 garageRepairLotRotation1;

    public bool isGarageRepairLotOccupied2 = false;
    public Vector3 garageRepairLotPosition2;
    public Vector3 garageRepairLotRotation2;

    public Vector3 initialPositionDestroyedCar1;
    public Vector3 initialRotationDestroyedCar1;
    public Vector3 initialPositionDestroyedCar2;
    public Vector3 initialRotationDestroyedCar2;
    public Vector3 initialPositionDestroyedCar3;
    public Vector3 initialRotationDestroyedCar3;

    public bool areAllCarsRepaired;

    public bool isClientsCar1Fixed = false;
    public bool isClientsCar2Fixed = false;
    public bool isClientsCar3Fixed = false;

    public void Start()
    {
        garageParkingLotPosition1 = new Vector3(14.46f, -0.15f, -22.02f);
        garageParkingLotRotation1 = new Vector3(0f, -2.7f, 0f);

        garageParkingLotPosition2 = new Vector3(11.59f, -0.15f, -22.16f);
        garageParkingLotRotation2 = new Vector3(0f, -2.9f, 0f);

        garageParkingLotPosition3 = new Vector3(8.58f, -0.15f, -22.02f);
        garageParkingLotRotation3 = new Vector3(0f, -2.7f, 0f);

        garageRepairLotPosition1 = new Vector3(-11.049f, 0.25f, -20.928f);
        garageRepairLotRotation1 = new Vector3(0f, 89.3f, 0f);

        garageRepairLotPosition2 = new Vector3(-11.15f, 0.25f, -12.62f);
        garageRepairLotRotation2 = new Vector3(0f, 89.3f, 0f);
        enableLights();
    }

    public void changeWorldWhenAsleep()
    {
        switch (worldCycler.dayCount)
        {
            case 0: //day 1 //executed when the game starts
                disableLights();
                teleportBrokenCarsToGarageParkingLot();
                letClientsLeave();
                enableDisableModels.enableModelsForDay(1);
                break;
            case 1: //night 1 //executed if it is day
                enableLights();
                teleportBrokenCarsToGarageParkingLot();
                letClientsShow();
                enableDisableModels.disableModelsForDay(1);
                enableDisableModels.enableModelsForNight(1);
                break;
            case 2: //day 2 //executed if it is night
                disableLights();
                telePortRepairedCarsBackToOriginalLocation();
                letClientsLeave();
                enableDisableModels.enableModelsForDay(2);
                enableDisableModels.disableModelsForNight(2);
                break;
            case 3: //night 2 //executed if it is day
                enableLights();
                teleportBrokenCarsToGarageParkingLot();
                letClientsShow();
                enableDisableModels.disableModelsForDay(2);
                enableDisableModels.enableModelsForNight(2);
                break;
            case 4: //day 3 //executed if it is night
                disableLights();
                telePortRepairedCarsBackToOriginalLocation();
                letClientsLeave();
                enableDisableModels.enableModelsForDay(3);
                enableDisableModels.disableModelsForNight(3);
                break;
            case 5: //night 3 //executed if it is day
                enableLights();
                teleportBrokenCarsToGarageParkingLot();
                letClientsShow();
                enableDisableModels.disableModelsForDay(3);
                enableDisableModels.enableModelsForNight(3);
                break;
            case 6: //day 4 //executed if it is night
                disableLights();
                telePortRepairedCarsBackToOriginalLocation();
                letClientsLeave();
                enableDisableModels.enableModelsForDay(4);
                enableDisableModels.disableModelsForNight(4);
                break;
            case 7: //night 4 //executed if it is day
                enableLights();
                teleportBrokenCarsToGarageParkingLot();
                letClientsShow();
                enableDisableModels.disableModelsForDay(4);
                enableDisableModels.enableModelsForNight(4);
                break;
            case 8: //day 5 //executed if it is night
                disableLights();
                telePortRepairedCarsBackToOriginalLocation();
                letClientsLeave();
                enableDisableModels.enableModelsForDay(5);
                enableDisableModels.disableModelsForNight(5);
                break;
            default:
                Debug.Log("The daycount is messed up or higher that availeble days. Daycount: " + worldCycler.dayCount);
                break;
        }
    }

    public void teleportBrokenCarsToGarageParkingLot()
    {
        int i = 0;
        foreach(Transform car in destructableCars.transform)
        {
            if (car.GetComponent<CarState>().isCarDestroyed == true)
            {
                i++;

                if (isGarageParkingLotOccupied1 == false)
                {
                    initialPositionDestroyedCar1 = new Vector3(car.transform.localPosition.x, car.transform.localPosition.y, car.transform.localPosition.z);
                    initialRotationDestroyedCar1 = new Vector3(car.transform.localRotation.eulerAngles.x, car.transform.localRotation.eulerAngles.y, car.transform.localRotation.eulerAngles.z);
                    car.transform.localPosition = garageParkingLotPosition1;
                    car.transform.localRotation = Quaternion.Euler(garageParkingLotRotation1);
                    isGarageParkingLotOccupied1 = true;
                    car.GetComponent<CarState>().isCarOnGarageParkingLot1 = true;
                }
                else if (isGarageParkingLotOccupied2 == false)
                {
                    initialPositionDestroyedCar2 = new Vector3(car.transform.localPosition.x, car.transform.localPosition.y, car.transform.localPosition.z);
                    initialRotationDestroyedCar2 = new Vector3(car.transform.localRotation.eulerAngles.x, car.transform.localRotation.eulerAngles.y, car.transform.localRotation.eulerAngles.z);
                    car.transform.localPosition = garageParkingLotPosition2;
                    car.transform.localRotation = Quaternion.Euler(garageParkingLotRotation2);
                    isGarageParkingLotOccupied2 = true;
                    car.GetComponent<CarState>().isCarOnGarageParkingLot2 = true;
                }
                else if (isGarageParkingLotOccupied3 == false)
                {
                    initialPositionDestroyedCar3 = new Vector3(car.transform.localPosition.x, car.transform.localPosition.y, car.transform.localPosition.z);
                    initialRotationDestroyedCar3 = new Vector3(car.transform.localRotation.eulerAngles.x, car.transform.localRotation.eulerAngles.y, car.transform.localRotation.eulerAngles.z);
                    car.transform.localPosition = garageParkingLotPosition3;
                    car.transform.localRotation = Quaternion.Euler(garageParkingLotRotation3);
                    isGarageParkingLotOccupied3 = true;
                    car.GetComponent<CarState>().isCarOnGarageParkingLot3 = true;
                }
                else
                {
                    Debug.Log("To many destroyed cars are being put in the garage parking lot: " + i);
                }
                //car.GetComponent<CarState>().repairCar(true);
            }
        }
    }

    public bool areAllCarsRepairedCheck()
    {
        areAllCarsRepaired = true;

        foreach (Transform car in destructableCars.transform)
        {
            //Debug.Log("Is car repaired: " + car.GetComponent<CarState>().isCarDestroyed);

            if (car.GetComponent<CarState>().isCarDestroyed == true)
            {
                areAllCarsRepaired = false;
            }
        }

        return areAllCarsRepaired;
    }

    public void telePortRepairedCarsBackToOriginalLocation()
    {
        Debug.Log("Are all cars repaired: " + areAllCarsRepairedCheck());
        if (areAllCarsRepairedCheck() == true)
        {
            foreach (Transform car in destructableCars.transform)
            {
                if (car.GetComponent<CarState>().isCarOnGarageParkingLot1 == true)
                {
                    car.transform.localPosition = initialPositionDestroyedCar1;
                    car.transform.localRotation = Quaternion.Euler(initialRotationDestroyedCar1);
                    isGarageParkingLotOccupied1 = false;
                    car.GetComponent<CarState>().isCarOnGarageParkingLot1 = false;
                }
                else if (car.GetComponent<CarState>().isCarOnGarageParkingLot2 == true)
                {
                    car.transform.localPosition = initialPositionDestroyedCar2;
                    car.transform.localRotation = Quaternion.Euler(initialRotationDestroyedCar2);
                    isGarageParkingLotOccupied2 = false;
                    car.GetComponent<CarState>().isCarOnGarageParkingLot2 = false;
                }
                else if (car.GetComponent<CarState>().isCarOnGarageParkingLot3 == true)
                {
                    car.transform.localPosition = initialPositionDestroyedCar3;
                    car.transform.localRotation = Quaternion.Euler(initialRotationDestroyedCar3);
                    isGarageParkingLotOccupied3 = false;
                    car.GetComponent<CarState>().isCarOnGarageParkingLot1 = false;
                }
            }
        }
    }

    public void letClientsShow()
    {
        client1.gameObject.GetComponent<Cliënt>().isClientHelped = false;
        client2.gameObject.GetComponent<Cliënt>().isClientHelped = false;
        client3.gameObject.GetComponent<Cliënt>().isClientHelped = false;

        switch (worldCycler.amountOfDestroyedCars)
        {
            case 1:
                client1.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.GetComponent<BoxCollider>().enabled = true;
                client1.gameObject.GetComponent<Cliënt>().isClientVisible = true;
                break;
            case 2:
                client1.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client2.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client2.gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client2.gameObject.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client2.gameObject.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client2.gameObject.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client2.gameObject.transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.GetComponent<BoxCollider>().enabled = true;
                client2.gameObject.GetComponent<BoxCollider>().enabled = true;
                client1.gameObject.GetComponent<Cliënt>().isClientVisible = true;
                client2.gameObject.GetComponent<Cliënt>().isClientVisible = true;
                break;
            case 3:
                client1.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client2.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client2.gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client2.gameObject.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client2.gameObject.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client2.gameObject.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client2.gameObject.transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client3.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client3.gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client3.gameObject.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client3.gameObject.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client3.gameObject.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client3.gameObject.transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled = true;
                client1.gameObject.GetComponent<BoxCollider>().enabled = true;
                client2.gameObject.GetComponent<BoxCollider>().enabled = true;
                client3.gameObject.GetComponent<BoxCollider>().enabled = true;
                client1.gameObject.GetComponent<Cliënt>().isClientVisible = true;
                client2.gameObject.GetComponent<Cliënt>().isClientVisible = true;
                client3.gameObject.GetComponent<Cliënt>().isClientVisible = true;
                break;
            default:
                Debug.Log("No cars are destroyed so no clients spawn");
                break;
        }
    }

    public void letClientsLeave()
    {
        client1.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client1.gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client1.gameObject.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client1.gameObject.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client1.gameObject.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client1.gameObject.transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client1.GetComponent<Cliënt>().isClientHelped = false;
        isClientsCar1Fixed = false;
        client2.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client2.gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client2.gameObject.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client2.gameObject.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client2.gameObject.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client2.gameObject.transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client2.GetComponent<Cliënt>().isClientHelped = false;
        isClientsCar2Fixed = false;
        client3.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client3.gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client3.gameObject.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client3.gameObject.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client3.gameObject.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client3.gameObject.transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled = false;
        client3.GetComponent<Cliënt>().isClientHelped = false;
        isClientsCar3Fixed = false;

    }

    public bool areAllClientsInvisible()
    {
        if (client1.gameObject.GetComponent<Cliënt>().isClientVisible == false && client2.gameObject.GetComponent<Cliënt>().isClientVisible == false && client3.gameObject.GetComponent<Cliënt>().isClientVisible == false)
        {
            return true;
        }
        return false;
    }

    public void disableLights()
    {
        foreach (Transform model in allLightingObjects.transform)
        {
            model.GetChild(0).gameObject.GetComponent<Light>().enabled = true;
        }
    }

    public void enableLights()
    {
        foreach (Transform model in allLightingObjects.transform)
        {
            model.GetChild(0).gameObject.GetComponent<Light>().enabled = false;
        }
    }
}
