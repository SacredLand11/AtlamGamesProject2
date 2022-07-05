using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour
{
    public bool CowSpawn = false;
    public GameObject cow;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && GameObject.Find("Player").GetComponent<PlayerController>().dollar > 1000 && cow.GetComponent<Cows>().cowNo < 5)
        {
            CowSpawn = true;
            cow.GetComponent<Cows>().cowNo++;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(5).gameObject.transform.GetChild(5).GetComponent<Animator>().SetTrigger("CowMoneyLossTrig");
            GameObject.Find("Player").GetComponent<PlayerController>().dollar -= 3000;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        CowSpawn = false;
    }
}
