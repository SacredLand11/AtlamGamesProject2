using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainMilk : MonoBehaviour
{
    public GameObject Milk;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Milk.GetComponent<Animator>().ResetTrigger("1cow");
            Milk.GetComponent<Animator>().ResetTrigger("2cow");
            Milk.GetComponent<Animator>().ResetTrigger("3cow");
            Milk.GetComponent<Animator>().ResetTrigger("4cow");
            Milk.GetComponent<Animator>().ResetTrigger("5cow");
            Milk.GetComponent<Animator>().SetTrigger("TakeMilk");
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(5).gameObject.transform.GetChild(6).GetComponent<Animator>().SetTrigger("MilkGainTrig");
            GameObject.Find("Player").GetComponent<PlayerController>().dollar += 500;
        }
    }
}
