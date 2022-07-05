using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillWaterScript : MonoBehaviour
{
    public GameObject Water;
    public GameObject Plane;
    public GameObject Bottle;
    private void Update()
    {
        BottleUpdate();
    }

    private void BottleUpdate()
    {
        float distance = Water.transform.position.y - Plane.transform.position.y;
        if (distance > 1.285f)
        {
            Bottle.GetComponent<BoxCollider>().enabled = true;
            Bottle.GetComponent<MeshRenderer>().enabled = true;
            Bottle.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            Bottle.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            Bottle.GetComponent<BoxCollider>().enabled = false;
            Bottle.GetComponent<MeshRenderer>().enabled = false;
            Bottle.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            Bottle.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && GameObject.Find("Player").GetComponent<PlayerController>().dollar > 50)
        {
            Water.GetComponent<Animator>().SetTrigger("FillTrig");
            Water.GetComponent<Animator>().ResetTrigger("FlushTrig");
            GameObject.Find("Player").GetComponent<PlayerController>().dollar -= 50;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(5).gameObject.transform.GetChild(4).GetComponent<Animator>().SetTrigger("WaterMoneyLossTrig");
        }
    }
}
