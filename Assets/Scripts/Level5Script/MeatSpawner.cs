using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatSpawner : MonoBehaviour
{
    public GameObject Steak;
    public int i = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cow")
        {
            i++;
            Destroy(other.gameObject);
            if (i <= 4)
            {
                Instantiate(Steak, new Vector3(transform.position.x - 1 + (i-1) * 2.5f, transform.position.y, transform.position.z + 1), Quaternion.identity).transform.SetParent(this.transform);
            }
        }
    }
}
