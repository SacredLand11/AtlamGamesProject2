using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectTheMeatMoney : MonoBehaviour
{
    public GameObject player;
    public GameObject slaughterHouse;

    public Text MeatGainText;

    int j = 0;

    private void Update()
    {
        j = slaughterHouse.transform.childCount - 7;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerController>().dollar += 1500 * j;
            int dollarmeatincrease = j * 1500;
            MeatGainText.text = dollarmeatincrease + "$";
            MeatGainText.GetComponent<Animator>().SetTrigger("CollectTheMeatTrig");
            slaughterHouse.GetComponent<MeatSpawner>().i = 0;
            if (j > 0)
            {
                for (int i = 0; i < j; i++)
                {
                    Object.Destroy(slaughterHouse.transform.GetChild(7 + i).gameObject);
                }
            }
        }
    }
}
