using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float dollar;

    public bool canBuy;
    public bool trimGrass = false;
    public bool trimharvest;
    public bool tomatoDollar = false;
    public bool cabbageDollar = false;
    public bool soilBool = false;
    public bool isStopped;

    public GameObject Controller;

    public Text dollarText;
    public Text tomatoGain;
    public Text cabbageGain;
    public Text FruitLoss;
    public Button harvestButton;

    public GameObject plant;
    public GameObject harvest;
    public LayerMask planeLayer;

    public int i;
    void Start()
    {
        i = -2;
        trimharvest = false;
        dollar = 150f;
    }
    void Update()
    {
        dollarText.text = "Dollar:" + dollar;
        if (trimGrass)
        {
            Invoke("isGrassTrim", .1f);
            Invoke("MuteAudio", .7f);
        }
        PurchasingPower();




        // Increase the money to present the game quickly
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dollar += 100;
        }
    }
    private void LateUpdate()
    {
        if (Input.GetMouseButton(0) && isStopped)
        {
            UserController(5f);
        }
    }
    // Check the player's money whether he/she can seed the plant or not
    private void PurchasingPower()
    {
        if (dollar >= 100)
        {
            canBuy = true;
        }
        else
        {
            canBuy = false;
        }
    }
    // The definition of player movement ability
    public void UserController(float VelScale) 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit, planeLayer);
        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
        GetComponent<NavMeshAgent>().speed = VelScale;
    }
    // Soil Options
    public void isPurchased()
    {
        FruitLoss.GetComponent<Animator>().SetTrigger("FruitMoneyLossTrig");
        dollar -= 100f;
        trimGrass = true;
        plant.GetComponent<AudioSource>().enabled = true;
        if (Controller.GetComponent<GameControllerScript>().LEVEL_3 && GameObject.Find("WaterTank(Clone)/BigBottle").GetComponent<DrainWater>().waterOption)
        {
            if (i > 0)
            {
                soilBool = true;
                GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.transform.GetChild(i-1).gameObject.SetActive(false);
                i--;
                Debug.Log(i);
            }
            if (i == 0)
            {
                GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(2).gameObject.SetActive(false);
                GameObject.Find("WaterTank(Clone)/BigBottle").GetComponent<DrainWater>().waterOption = false;
            }
        }
        if(Controller.GetComponent<GameControllerScript>().LEVEL_3 && !GameObject.Find("WaterTank(Clone)/BigBottle").GetComponent<DrainWater>().waterOption)
        {
            if (soilBool)
            {
                soilBool = false;
            }
            if (!soilBool)
            {
                i--;
            }
        }
    }
    void isGrassTrim()
    {
        trimGrass = false;
    }
    void MuteAudio()
    {
        plant.GetComponent<AudioSource>().enabled = false;
        harvest.GetComponent<AudioSource>().enabled = false;
    }
    // Harvest Options
    public void getDollar()
    {
        harvest.GetComponent<AudioSource>().enabled = true;
        Invoke("MuteAudio", 1f);
        trimharvest = true;
        if (tomatoDollar)
        {
            tomatoGain.GetComponent<Animator>().SetTrigger("TomatoTrig");
            dollar += 125f;
        }
        if (cabbageDollar)
        {
            cabbageGain.GetComponent<Animator>().SetTrigger("CabbageTrig");
            dollar += 200f;
        }
        dollarText.text = "Total $:" + dollar;
    }
}
