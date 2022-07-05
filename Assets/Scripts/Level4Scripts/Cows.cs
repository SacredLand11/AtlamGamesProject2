using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cows : MonoBehaviour
{
    public int cowNo;
    public GameObject cowPrefab;
    public GameObject cowInit;
    private void Start()
    {
        cowNo = 0;
    }
    private void Update()
    {
        cowNo = this.transform.childCount;
        if (cowInit.GetComponent<CowSpawner>().CowSpawn)
        {
            Instantiate(cowPrefab, transform.position, Quaternion.identity).transform.SetParent(this.transform);
            cowInit.GetComponent<CowSpawner>().CowSpawn = false;
        }
    }
}
