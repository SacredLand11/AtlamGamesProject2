using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTheCow : MonoBehaviour
{
    public GameObject cowPrefab;
    public GameObject Meatspawner;
    private void Update()
    {
        cowPrefab = GameObject.Find("Environment/Husbandry/Cows");
        Meatspawner = GameObject.Find("Environment/Slaughterhouse");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" )
        {
            if (Meatspawner.GetComponent<MeatSpawner>().i <= 4 && cowPrefab.transform.childCount > 0)
            Instantiate(cowPrefab.transform.GetChild(0), new Vector3(9, 0.12f , -8), Quaternion.Euler(0, 180, 0));
            cowPrefab.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
            Object.Destroy(cowPrefab.transform.GetChild(0).gameObject);
        }
    }
}
