using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainWater : MonoBehaviour
{
    public GameObject Water;
    public GameObject player;
    public bool waterOption;
    private void Start()
    {
        waterOption = false;
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerController>().i = 10;
            Water.GetComponent<Animator>().ResetTrigger("FillTrig");
            Water.GetComponent<Animator>().SetTrigger("FlushTrig");
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(2).gameObject.SetActive(true);
            for (int a = 0; a < 9; a++)
            {
                GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.transform.GetChild(a).gameObject.SetActive(true);
            }
            waterOption = true;
        }
    }
}
