using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmAreaScript : MonoBehaviour
{
    public GameObject player;
    public GameObject gameController;
    public Material wetSoil;
    public Material SoilMat;
    [SerializeField] bool waterBool;

    public Button purchaseButton;
    public Button harvestButton;
    public Button tomatoButton;
    public Button cabbageButton;

    public GameObject mudPrefab;
    public GameObject dollarPrefab;
    public GameObject soilPrefab;
    public GameObject tomatoSeedPrefab;
    public GameObject cabbageSeedPrefab;
    public GameObject ripeTomatoPrefab;
    public GameObject ripeCabbagePrefab;

    public bool readyToHarvest = false;
    public bool harvest = false;
    public bool onlyOnePurchase = false;
    public bool tomatoCheck = false;
    public bool cabbageCheck = false;
    private void Start()
    {
        waterBool = false;
    }
    private void Update()
    {
        WaterAndHarvestProcess();
    }
    // Harvest Options w or w/out Water
    private void WaterAndHarvestProcess()
    {
        // Feed the seed with water
        if (gameController.GetComponent<GameControllerScript>().LEVEL_3 && player.GetComponent<PlayerController>().i >= -1)
        {
            waterBool = true;
        }
        else
        {
            waterBool = false;
        }
        // The seeds grow without water
        if (readyToHarvest && !waterBool)
        {
            if (gameController.GetComponent<GameControllerScript>().tomato)
            {
                StartCoroutine(HarvestTimeForTomatos(30));
            }
            if (gameController.GetComponent<GameControllerScript>().cabbage)
            {
                StartCoroutine(HarvestTimeForCabbages(60));
            }
        }
        // The seeds grow with water
        if (readyToHarvest && waterBool)
        {
            if (gameController.GetComponent<GameControllerScript>().tomato)
            {
                StartCoroutine(HarvestTimeForTomatos(10));
            }
            if (gameController.GetComponent<GameControllerScript>().cabbage)
            {
                StartCoroutine(HarvestTimeForCabbages(20));
            }
        }
        // To prevent the bug
        if (!player.GetComponent<PlayerController>().trimharvest && !player.GetComponent<PlayerController>().tomatoDollar && !player.GetComponent<PlayerController>().cabbageDollar)
        {
            if (this.transform.childCount > 2)
            {
                Object.Destroy(this.transform.GetChild(0).gameObject);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        ButtonOptions(other);
        PlantOptions(other);
    }
    // Purchase & Harvest Button Options
    private void ButtonOptions(Collider other)
    {
        //Possible Sitautions
            //Purchase Button Activation
        if (other.gameObject.tag == "Player" && player.GetComponent<PlayerController>().canBuy && !onlyOnePurchase)
        {
            purchaseButton.GetComponent<Button>().interactable = true;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(0).gameObject.SetActive(true);
        }
            //Harvest and Fruit Selection Button Activation
        if (other.gameObject.tag == "Player" && harvest)
        {
            harvestButton.GetComponent<Button>().interactable = true;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(1).gameObject.SetActive(true);
            if (tomatoCheck)
            {
                player.GetComponent<PlayerController>().tomatoDollar = true;
                player.GetComponent<PlayerController>().cabbageDollar = false;
            }
            if (cabbageCheck)
            {
                player.GetComponent<PlayerController>().tomatoDollar = false;
                player.GetComponent<PlayerController>().cabbageDollar = true;
            }
        }
        //Not Possible Situations
            //Purchase Button Deactivation
        if (!player.GetComponent<PlayerController>().canBuy || onlyOnePurchase)
        {
            purchaseButton.GetComponent<Button>().interactable = false;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(0).gameObject.SetActive(false);
        }
            //Harvest Button Deactivation
        if (!harvest)
        {
            harvestButton.GetComponent<Button>().interactable = false;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    // Seed Plant Options w or w/out Water
    private void PlantOptions(Collider other)
    {
        // Seed Process
        if (player.GetComponent<PlayerController>().trimGrass)
        {
            // Soil color does not change because there is no water in the ground
            if (gameController.GetComponent<GameControllerScript>().tomato && !waterBool)
            {
                TomatoSeed();
                soilPrefab.GetComponent<MeshRenderer>().material = SoilMat;
            }
            if (gameController.GetComponent<GameControllerScript>().cabbage && !waterBool)
            {
                CabbageSeed();
                soilPrefab.GetComponent<MeshRenderer>().material = SoilMat;
            }
            // Soil color get darker due to plant process is happened by using water
            if (gameController.GetComponent<GameControllerScript>().tomato && waterBool)
            {
                TomatoSeed();
                soilPrefab.GetComponent<MeshRenderer>().material = wetSoil;
            }
            if (gameController.GetComponent<GameControllerScript>().cabbage && waterBool)
            {
                CabbageSeed();
                soilPrefab.GetComponent<MeshRenderer>().material = wetSoil;
            }
        }
        // Harvest Process
        if (player.GetComponent<PlayerController>().trimharvest && harvest)
        {
            refleshTheSoil(); //Again mud is occured.
        }
        // Fruit Option Process
        if (other.gameObject.tag == "Player" && gameController.GetComponent<GameControllerScript>().LEVEL_2)
        {
            tomatoButton.GetComponent<Image>().enabled = true;
            cabbageButton.GetComponent<Image>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        purchaseButton.interactable = false;
        GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(0).gameObject.SetActive(false);
        harvestButton.interactable = false;
        GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(1).gameObject.SetActive(false);
        tomatoButton.GetComponent<Image>().enabled = false;
        cabbageButton.GetComponent<Image>().enabled = false;
        player.GetComponent<PlayerController>().tomatoDollar = false;
        player.GetComponent<PlayerController>().cabbageDollar = false;
    }
    // Plant the seed according to its type
    private void TomatoSeed()
    {
        readyToHarvest = true;
        onlyOnePurchase = true;
        tomatoCheck = true;
        cabbageCheck = false;
        player.GetComponent<PlayerController>().tomatoDollar = true;
        player.GetComponent<PlayerController>().cabbageDollar = false;
        Object.Destroy(this.transform.GetChild(0).gameObject);
        Object.Destroy(this.transform.GetChild(1).gameObject);
        Instantiate(soilPrefab, transform.position, Quaternion.identity).transform.SetParent(this.transform);
        Instantiate(tomatoSeedPrefab, transform.position, Quaternion.identity).transform.SetParent(this.transform);
    }
    private void CabbageSeed()
    {
        readyToHarvest = true;
        onlyOnePurchase = true;
        tomatoCheck = false;
        cabbageCheck = true;
        player.GetComponent<PlayerController>().tomatoDollar = false;
        player.GetComponent<PlayerController>().cabbageDollar = true;
        Object.Destroy(this.transform.GetChild(0).gameObject);
        Object.Destroy(this.transform.GetChild(1).gameObject);
        Instantiate(soilPrefab, transform.position, Quaternion.identity).transform.SetParent(this.transform);
        Instantiate(cabbageSeedPrefab, transform.position, Quaternion.identity).transform.SetParent(this.transform);
    }

    // Ripen process for fruits
    IEnumerator HarvestTimeForTomatos(int tomatoTime)
    {
        readyToHarvest = false;
        yield return new WaitForSeconds(tomatoTime);
        Object.Destroy(this.transform.GetChild(1).gameObject);
        Instantiate(ripeTomatoPrefab, transform.position, Quaternion.identity).transform.SetParent(this.transform);
        harvest = true;
    }
    IEnumerator HarvestTimeForCabbages(int cabbageTime)
    {
        readyToHarvest = false;
        yield return new WaitForSeconds(cabbageTime);
        Object.Destroy(this.transform.GetChild(1).gameObject);
        Instantiate(ripeCabbagePrefab, transform.position, Quaternion.identity).transform.SetParent(this.transform);
        harvest = true;
    }

    // Turn the soil to its first position
    public void refleshTheSoil()
    {
        onlyOnePurchase = false;
        Object.Destroy(this.transform.GetChild(0).gameObject);
        Object.Destroy(this.transform.GetChild(1).gameObject);
        Instantiate(mudPrefab, transform.position, Quaternion.identity).transform.SetParent(this.transform);
        Instantiate(dollarPrefab, new Vector3(transform.position.x+0.1f,transform.position.y+1,transform.position.z-0.5f), Quaternion.Euler(new Vector3(70, 0, 0))).transform.SetParent(this.transform);
        harvest = false;
        player.GetComponent<PlayerController>().trimharvest = false;
        player.GetComponent<PlayerController>().tomatoDollar = false;
        player.GetComponent<PlayerController>().cabbageDollar = false;
    }
}
