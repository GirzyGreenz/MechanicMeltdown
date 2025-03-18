using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarState : MonoBehaviour
{
    public AudioSource audioSource;

    public ChangeDay changeDay;
    public Player player;
    public Subtitles subtitles;
    public WorldCycler worldCycler;
    public ChangeWorldWhenAsleep changeWorldWhenAsleep;
    public Objectives objectives;
    public FinishedMenu finishedMenu;
    public AudioClips audioClips;

    public GameObject topParentCarObject;

    [SerializeField] public int carState = 0; //0 means repaired / 1 means damaged / 2 means broken
    public bool isCarDestroyed = false;
    public bool isCarOnGarageParkingLot1 = false;
    public bool isCarOnGarageParkingLot2 = false;
    public bool isCarOnGarageParkingLot3 = false;
    public bool isCarOnGarageRepairLot1 = false;
    public bool isCarOnGarageRepairLot2 = false;
    public bool isCarIsInGarage = false;

    public int carModelBroken = 0;
    public int carModelBrokenChild1 = 0;
    public int carModelBrokenChild2 = 1;
    public int carModelBrokenChild3 = 2;
    public int carModelBrokenChild4 = 3;
    public int carModelBrokenChild5 = 4;
    public int carModelBrokenChild6 = 5;
    public int carModelDamaged = 1;
    public int carModelDamagedChild1 = 0;
    public int carModelDamagedChild2 = 1;
    public int carModelDamagedChild3 = 2;
    public int carModelDamagedChild4 = 3;
    public int carModelDamagedChild5 = 4;
    public int carModelDamagedChild6 = 5;
    public int carModelRepaired = 2;
    public int carModelRepairedChild1 = 0;
    public int carModelRepairedChild2 = 1;
    public int carModelRepairedChild3 = 2;
    public int carModelRepairedChild4 = 3;
    public int carModelRepairedChild5 = 4;

    public int subNrCarDestroyTooManyCars;
    public int subDurCarDestroyTooManyCars;
    public int subNrNothingToUse;
    public int subDurNothingToUse;
    public int subNrPutCarInGarage;
    public int subDurPutCarInGarage;
    public int subNrAllGarageSpacesOccupied;
    public int subDurAllGarageSpacesOccupied;
    public int subNrPutCarInParkingLot;
    public int subDurPutCarInParkingLot;
    public int subNrCantUseWrenchToDestroyOrRepair;
    public int subDurCantUseWrenchToDestroyOrRepair;
    public int subNrUseHammerFromGarage;
    public int subDursubNrUseHammerFromGarage;

    void Start()
    {
        subNrCarDestroyTooManyCars = 28;
        subDurCarDestroyTooManyCars = 3;
        subNrNothingToUse = 29;
        subDurNothingToUse = 3;
        subNrPutCarInGarage = 27;
        subDurPutCarInGarage = 3;
        subNrPutCarInParkingLot = 30;
        subDurPutCarInParkingLot = 3;
        subNrCantUseWrenchToDestroyOrRepair = 31;
        subDurCantUseWrenchToDestroyOrRepair = 3;
        subNrUseHammerFromGarage = 54;
        subDursubNrUseHammerFromGarage = 3;

        player = FindObjectOfType<Player>();
        subtitles = GameObject.FindWithTag("WorldLogic").GetComponent<Subtitles>();
        changeDay = FindObjectOfType<ChangeDay>();
        worldCycler = FindObjectOfType<WorldCycler>();
        changeWorldWhenAsleep = FindObjectOfType<ChangeWorldWhenAsleep>();
        finishedMenu = FindObjectOfType<FinishedMenu>();
        audioClips = FindObjectOfType<AudioClips>();
        objectives = FindObjectOfType<Objectives>();
    }

    public void interactWithCar()
    {
        if (isCarOnGarageParkingLot1 == false && changeWorldWhenAsleep.isGarageParkingLotOccupied1 == false && isCarIsInGarage == true && isCarDestroyed == false)
        {
            teleportCarBackToParkingLot(1);
            subtitles.activateSubtitlesAndSetDuration(subNrPutCarInParkingLot, subDurPutCarInParkingLot);
        }
        else if (isCarOnGarageParkingLot2 == false && changeWorldWhenAsleep.isGarageParkingLotOccupied2 == false && isCarIsInGarage == true && isCarDestroyed == false)
        {
            teleportCarBackToParkingLot(2);
            subtitles.activateSubtitlesAndSetDuration(subNrPutCarInParkingLot, subDurPutCarInParkingLot);
        }
        else if (isCarOnGarageParkingLot3 == false && changeWorldWhenAsleep.isGarageParkingLotOccupied3 == false && isCarIsInGarage == true && isCarDestroyed == false)
        {
            teleportCarBackToParkingLot(3);
            subtitles.activateSubtitlesAndSetDuration(subNrPutCarInParkingLot, subDurPutCarInParkingLot);
        }

        Debug.Log("Is wrench selected: " + player.hasWrenchSelected + " Is car destroyed: " + isCarDestroyed + " Is it day: " + worldCycler.itIsDay);

        if (player.hasHammerSelected == true && worldCycler.itIsDay == false)
        {
            wreckCar();
        }
        else if (player.hasWrenchSelected == true && isCarDestroyed == true && worldCycler.itIsDay == true)
        {
            if (isCarOnGarageRepairLot1 == true || isCarOnGarageRepairLot2 == true)
            {
                repairCar();
            }
            else
            {
                subtitles.activateSubtitlesAndSetDuration(subNrCantUseWrenchToDestroyOrRepair, subDurCantUseWrenchToDestroyOrRepair);
            }
        } else if (player.hasHammerSelected == false && worldCycler.itIsDay == false)
        {
            subtitles.activateSubtitlesAndSetDuration(subNrUseHammerFromGarage, subDursubNrUseHammerFromGarage);
        }

        if (isCarOnGarageRepairLot1 == false && changeWorldWhenAsleep.isGarageRepairLotOccupied1 == false && isCarIsInGarage == false && isCarDestroyed == true && worldCycler.itIsDay == true)
        {
            teleportCarIntoGarage(1);
            subtitles.activateSubtitlesAndSetDuration(subNrPutCarInGarage, subDurPutCarInGarage);
        }
        else if (isCarOnGarageRepairLot2 == false && changeWorldWhenAsleep.isGarageRepairLotOccupied2 == false && isCarIsInGarage == false && isCarDestroyed == true && worldCycler.itIsDay == true)
        {
            teleportCarIntoGarage(2);
            subtitles.activateSubtitlesAndSetDuration(subNrPutCarInGarage, subDurPutCarInGarage);
        }
    }

    public void wreckCar()
    {
        if (carState == 1)
        {
            //broken
            carState++;
            audioSource.PlayOneShot(audioClips.destroyCar);
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild1).gameObject.GetComponent<MeshRenderer>().enabled = true; //Car
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild2).gameObject.GetComponent<MeshRenderer>().enabled = true; //Cylinder
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild3).gameObject.GetComponent<MeshRenderer>().enabled = true; //Cylinder.001
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild4).gameObject.GetComponent<MeshRenderer>().enabled = true; //Headlights
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild5).gameObject.GetComponent<MeshRenderer>().enabled = true; //Vooruit kapot
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild6).gameObject.GetComponent<MeshRenderer>().enabled = true; //wheels
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild1).gameObject.GetComponent<MeshRenderer>().enabled = false; //Achteruit kapot
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild2).gameObject.GetComponent<MeshRenderer>().enabled = false; //Car
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild3).gameObject.GetComponent<MeshRenderer>().enabled = false; //Cylinder
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild4).gameObject.GetComponent<MeshRenderer>().enabled = false; //Cylinder.001
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild5).gameObject.GetComponent<MeshRenderer>().enabled = false; //Headlights
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild6).gameObject.GetComponent<MeshRenderer>().enabled = false; //wheels
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild1).gameObject.GetComponent<MeshRenderer>().enabled = false; //car
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild2).gameObject.GetComponent<MeshRenderer>().enabled = false; //cylinder
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild3).gameObject.GetComponent<MeshRenderer>().enabled = false; //cylinder.001
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild4).gameObject.GetComponent<MeshRenderer>().enabled = false; //headlights
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild5).gameObject.GetComponent<MeshRenderer>().enabled = false; // wheels
            isCarDestroyed = true;
        }
        else if (worldCycler.amountOfDestroyedCars <= 2 && carState == 0)
        {
            //damaged
            carState++;
            objectives.updateObjectiveList(0);
            Debug.Log(audioClips.breakCarGlass);
            Debug.Log(audioSource);
            audioSource.PlayOneShot(audioClips.breakCarGlass);
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild1).gameObject.GetComponent<MeshRenderer>().enabled = false; //Car
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild2).gameObject.GetComponent<MeshRenderer>().enabled = false; //Cylinder
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild3).gameObject.GetComponent<MeshRenderer>().enabled = false; //Cylinder.001
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild4).gameObject.GetComponent<MeshRenderer>().enabled = false; //Headlights
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild5).gameObject.GetComponent<MeshRenderer>().enabled = false; //Vooruit kapot
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild6).gameObject.GetComponent<MeshRenderer>().enabled = false; //wheels
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild1).gameObject.GetComponent<MeshRenderer>().enabled = true; //Achteruit kapot
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild2).gameObject.GetComponent<MeshRenderer>().enabled = true; //Car
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild3).gameObject.GetComponent<MeshRenderer>().enabled = true; //Cylinder
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild4).gameObject.GetComponent<MeshRenderer>().enabled = true; //Cylinder.001
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild5).gameObject.GetComponent<MeshRenderer>().enabled = true; //Headlights
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild6).gameObject.GetComponent<MeshRenderer>().enabled = true; //wheels
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild1).gameObject.GetComponent<MeshRenderer>().enabled = false; //car
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild2).gameObject.GetComponent<MeshRenderer>().enabled = false; //cylinder
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild3).gameObject.GetComponent<MeshRenderer>().enabled = false; //cylinder.001
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild4).gameObject.GetComponent<MeshRenderer>().enabled = false; //headlights
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild5).gameObject.GetComponent<MeshRenderer>().enabled = false; // wheels
            isCarDestroyed = true;
            worldCycler.amountOfDestroyedCars++;
        }
        else
        {
            subtitles.activateSubtitlesAndSetDuration(subNrCarDestroyTooManyCars, subDurCarDestroyTooManyCars);
        }

        Debug.Log("Carstate: " + carState);
        Debug.Log("Is car destroyed: " + isCarDestroyed);
        Debug.Log("Amount Of Destroyed Cars: " + worldCycler.amountOfDestroyedCars);

    }

    public void repairCar()
    {
        if (carState == 2)
        {
            //damaged
            carState--;
            audioSource.PlayOneShot(audioClips.repairCar);
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild1).gameObject.GetComponent<MeshRenderer>().enabled = false; //Car
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild2).gameObject.GetComponent<MeshRenderer>().enabled = false; //Cylinder
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild3).gameObject.GetComponent<MeshRenderer>().enabled = false; //Cylinder.001
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild4).gameObject.GetComponent<MeshRenderer>().enabled = false; //Headlights
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild5).gameObject.GetComponent<MeshRenderer>().enabled = false; //Vooruit kapot
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild6).gameObject.GetComponent<MeshRenderer>().enabled = false; //wheels
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild1).gameObject.GetComponent<MeshRenderer>().enabled = true; //Achteruit kapot
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild2).gameObject.GetComponent<MeshRenderer>().enabled = true; //Car
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild3).gameObject.GetComponent<MeshRenderer>().enabled = true; //Cylinder
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild4).gameObject.GetComponent<MeshRenderer>().enabled = true; //Cylinder.001
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild5).gameObject.GetComponent<MeshRenderer>().enabled = true; //Headlights
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild6).gameObject.GetComponent<MeshRenderer>().enabled = true; //wheels
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild1).gameObject.GetComponent<MeshRenderer>().enabled = false; //car
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild2).gameObject.GetComponent<MeshRenderer>().enabled = false; //cylinder
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild3).gameObject.GetComponent<MeshRenderer>().enabled = false; //cylinder.001
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild4).gameObject.GetComponent<MeshRenderer>().enabled = false; //headlights
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild5).gameObject.GetComponent<MeshRenderer>().enabled = false; // wheels
            isCarDestroyed = true;
        }
        else if (carState == 1)
        {
            //repaired
            carState--;
            audioSource.PlayOneShot(audioClips.repairCar);
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild1).gameObject.GetComponent<MeshRenderer>().enabled = false; //Car
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild2).gameObject.GetComponent<MeshRenderer>().enabled = false; //Cylinder
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild3).gameObject.GetComponent<MeshRenderer>().enabled = false; //Cylinder.001
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild4).gameObject.GetComponent<MeshRenderer>().enabled = false; //Headlights
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild5).gameObject.GetComponent<MeshRenderer>().enabled = false; //Vooruit kapot
            topParentCarObject.transform.GetChild(carModelBroken).gameObject.transform.GetChild(carModelBrokenChild6).gameObject.GetComponent<MeshRenderer>().enabled = false; //wheels
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild1).gameObject.GetComponent<MeshRenderer>().enabled = false; //Achteruit kapot
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild2).gameObject.GetComponent<MeshRenderer>().enabled = false; //Car
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild3).gameObject.GetComponent<MeshRenderer>().enabled = false; //Cylinder
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild4).gameObject.GetComponent<MeshRenderer>().enabled = false; //Cylinder.001
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild5).gameObject.GetComponent<MeshRenderer>().enabled = false; //Headlights
            topParentCarObject.transform.GetChild(carModelDamaged).gameObject.transform.GetChild(carModelDamagedChild6).gameObject.GetComponent<MeshRenderer>().enabled = false; //wheels
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild1).gameObject.GetComponent<MeshRenderer>().enabled = true; //car
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild2).gameObject.GetComponent<MeshRenderer>().enabled = true; //cylinder
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild3).gameObject.GetComponent<MeshRenderer>().enabled = true; //cylinder.001
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild4).gameObject.GetComponent<MeshRenderer>().enabled = true; //headlights
            topParentCarObject.transform.GetChild(carModelRepaired).gameObject.transform.GetChild(carModelRepairedChild5).gameObject.GetComponent<MeshRenderer>().enabled = true; // wheels

            checkClientForRepairedCar();
            isCarDestroyed = false;
            worldCycler.amountOfDestroyedCars--;
        }

        Debug.Log("Carstate: " + carState);
        Debug.Log("Is car destroyed: " + isCarDestroyed);
        Debug.Log("Amount Of Destroyed Cars: " + worldCycler.amountOfDestroyedCars);
    }

    public void checkClientForRepairedCar()
    {
        if (changeWorldWhenAsleep.isClientsCar1Fixed == false)
        {
            changeWorldWhenAsleep.isClientsCar1Fixed = true;
        }
        else if (changeWorldWhenAsleep.isClientsCar2Fixed == false)
        {
            changeWorldWhenAsleep.isClientsCar2Fixed = true;
        }
        else if (changeWorldWhenAsleep.isClientsCar3Fixed == false)
        {
            changeWorldWhenAsleep.isClientsCar3Fixed = true;
        }
        else
        {
            Debug.Log("No clients cars left to repair");
        }
    }

    public void teleportCarIntoGarage(int garageNr)
    {
        freeParkingSpace();

        switch (garageNr)
        {
            case 1:
                transform.localPosition = changeWorldWhenAsleep.garageRepairLotPosition1;
                transform.localRotation = Quaternion.Euler(changeWorldWhenAsleep.garageRepairLotRotation1);
                changeWorldWhenAsleep.isGarageRepairLotOccupied1 = true;
                isCarOnGarageRepairLot1 = true;
                break;
            case 2:
                transform.localPosition = changeWorldWhenAsleep.garageRepairLotPosition2;
                transform.localRotation = Quaternion.Euler(changeWorldWhenAsleep.garageRepairLotRotation2);
                changeWorldWhenAsleep.isGarageRepairLotOccupied2 = true;
                isCarOnGarageRepairLot2 = true;
                break;
            default:
                Debug.Log("wrong garage nr");
                break;
        }

        audioSource.PlayOneShot(audioClips.placeCarInGarageOrParkingLot);
        isCarIsInGarage = true;
    }    

    public void teleportCarBackToParkingLot(int parkingNr)
    {
        Debug.Log("Ïs car destroyed?: " + isCarDestroyed);

        freeGarageSpace();
        
        switch (parkingNr)
        {
            case 1:
                transform.localPosition = changeWorldWhenAsleep.garageParkingLotPosition1;
                transform.localRotation = Quaternion.Euler(changeWorldWhenAsleep.garageParkingLotRotation1);
                changeWorldWhenAsleep.isGarageParkingLotOccupied1 = true;
                isCarOnGarageParkingLot1 = true;
                break;
            case 2:
                transform.localPosition = changeWorldWhenAsleep.garageParkingLotPosition2;
                transform.localRotation = Quaternion.Euler(changeWorldWhenAsleep.garageParkingLotRotation2);
                changeWorldWhenAsleep.isGarageParkingLotOccupied2 = true;
                isCarOnGarageParkingLot2 = true;
                break;
            case 3:
                transform.localPosition = changeWorldWhenAsleep.garageParkingLotPosition3;
                transform.localRotation = Quaternion.Euler(changeWorldWhenAsleep.garageParkingLotRotation3);
                changeWorldWhenAsleep.isGarageParkingLotOccupied3 = true;
                isCarOnGarageParkingLot3 = true;
                break;
            default:
                subtitles.activateSubtitlesAndSetDuration(subNrAllGarageSpacesOccupied, subDurAllGarageSpacesOccupied);
                Debug.Log("wrong parking nr");
                break;
        }

        audioSource.PlayOneShot(audioClips.placeCarInGarageOrParkingLot);
        isCarIsInGarage = false;
    }

    public void freeParkingSpace()
    {

        if (isCarOnGarageParkingLot1 == true)
        {
            changeWorldWhenAsleep.isGarageParkingLotOccupied1 = false;
            isCarOnGarageParkingLot1 = false;
        }
        else if (isCarOnGarageParkingLot2 == true)
        {
            changeWorldWhenAsleep.isGarageParkingLotOccupied2 = false;
            isCarOnGarageParkingLot2 = false;
        }
        else if (isCarOnGarageParkingLot3 == true)
        {
            changeWorldWhenAsleep.isGarageParkingLotOccupied3 = false;
            isCarOnGarageParkingLot3 = false;
        }
        else
        {
            Debug.Log("Can't free parkinglot");
        }
    }

    public void freeGarageSpace()
    {
        if (isCarOnGarageRepairLot1 == true)
        {
            changeWorldWhenAsleep.isGarageRepairLotOccupied1 = false;
            isCarOnGarageRepairLot1 = false;
        }
        else if (isCarOnGarageRepairLot2 == true)
        {
            changeWorldWhenAsleep.isGarageRepairLotOccupied2 = false;
            isCarOnGarageRepairLot2 = false;
        }
        else
        {
            Debug.Log("Can't free garagelot");
        }
    }
}
