using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillTheMilkScript : MonoBehaviour
{
    int cowNo;
    public GameObject Plane;
    public GameObject MilkBox;
    public GameObject Cows;
    void Update()
    {
        BottleUpdate();
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        cowNo = Cows.transform.childCount;
        if (cowNo == 0)
        {
            this.GetComponent<Animator>().ResetTrigger("1cow");
            this.GetComponent<Animator>().ResetTrigger("2cow");
            this.GetComponent<Animator>().ResetTrigger("3cow");
            this.GetComponent<Animator>().ResetTrigger("4cow");
            this.GetComponent<Animator>().ResetTrigger("5cow");
        }
        if (cowNo == 1)
        {
            this.GetComponent<Animator>().SetTrigger("1cow");
            this.GetComponent<Animator>().ResetTrigger("2cow");
            this.GetComponent<Animator>().ResetTrigger("3cow");
            this.GetComponent<Animator>().ResetTrigger("4cow");
            this.GetComponent<Animator>().ResetTrigger("5cow");
        }
        if (cowNo == 2)
        {
            this.GetComponent<Animator>().ResetTrigger("1cow");
            this.GetComponent<Animator>().SetTrigger("2cow");
            this.GetComponent<Animator>().ResetTrigger("3cow");
            this.GetComponent<Animator>().ResetTrigger("4cow");
            this.GetComponent<Animator>().ResetTrigger("5cow");
        }
        if (cowNo == 3)
        {
            this.GetComponent<Animator>().ResetTrigger("1cow");
            this.GetComponent<Animator>().ResetTrigger("2cow");
            this.GetComponent<Animator>().SetTrigger("3cow");
            this.GetComponent<Animator>().ResetTrigger("4cow");
            this.GetComponent<Animator>().ResetTrigger("5cow");
        }
        if (cowNo == 4)
        {
            this.GetComponent<Animator>().ResetTrigger("1cow");
            this.GetComponent<Animator>().ResetTrigger("2cow");
            this.GetComponent<Animator>().ResetTrigger("3cow");
            this.GetComponent<Animator>().SetTrigger("4cow");
            this.GetComponent<Animator>().ResetTrigger("5cow");
        }
        if (cowNo == 5)
        {
            this.GetComponent<Animator>().ResetTrigger("1cow");
            this.GetComponent<Animator>().ResetTrigger("2cow");
            this.GetComponent<Animator>().ResetTrigger("3cow");
            this.GetComponent<Animator>().ResetTrigger("4cow");
            this.GetComponent<Animator>().SetTrigger("5cow");
        }
    }

    private void BottleUpdate()
    {
        float distance = this.transform.position.y - Plane.transform.position.y;
        if (distance > 1.485f)
        {
            MilkBox.SetActive(true);
        }
        else
        {
            MilkBox.SetActive(false);
        }
    }
}
