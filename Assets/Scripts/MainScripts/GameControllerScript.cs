using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;

    public GameObject level3UpgradePrefab;
    public GameObject level4UpgradePrefab;
    public GameObject level5UpgradePrefab;
    public GameObject waterTankPrefab;
    public GameObject husbandryPrefab;
    public GameObject slaughterhousePrefab;

    public bool tomato = true;
    public bool cabbage = false;

    public bool LEVEL_1;
    public bool LEVEL_2;
    public bool LEVEL_3;
    public bool LEVEL_4;
    public bool LEVEL_5;

    int i = 0;
    public int j = 0;
    int k = 0;
    private void Start()
    {
        StartProcess();
    }

    private void StartProcess()
    {
        LEVEL_1 = true;
        LEVEL_2 = false;
        LEVEL_3 = false;
        LEVEL_4 = false;
        LEVEL_5 = false;
        level1.GetComponent<Image>().enabled = true;
        level2.GetComponent<Image>().enabled = false;
        level3.GetComponent<Image>().enabled = false;
        level4.GetComponent<Image>().enabled = false;
        level5.GetComponent<Image>().enabled = false;
        if (k == 0)
        {
            HelpButton();
            k++;
        }
    }

    private void Update()
    {
        levelUp();
        imageUP();
    }
    void imageUP()
    {
        if (LEVEL_2)
        {
            level1.GetComponent<Image>().enabled = false;
            level2.GetComponent<Image>().enabled = true;
            if (k == 1)
            {
                HelpButton();
                k++;
            }
        }
        if (LEVEL_3)
        {
            level2.GetComponent<Image>().enabled = false;
            level3.GetComponent<Image>().enabled = true;
            if (k == 2)
            {
                HelpButton();
                k++;
            }
        }
        if (LEVEL_4)
        {
            level3.GetComponent<Image>().enabled = false;
            level4.GetComponent<Image>().enabled = true;
            if (k == 3)
            {
                HelpButton();
                k++;
            }
        }
        if (LEVEL_5)
        {
            level4.GetComponent<Image>().enabled = false;
            level5.GetComponent<Image>().enabled = true;
            if (k == 4)
            {
                HelpButton();
                k++;
            }
        }
    }
    public void levelUp()
    {
        if (player.GetComponent<PlayerController>().dollar > 300 && player.GetComponent<PlayerController>().dollar < 1000)
        {
            LEVEL_2 = true;
        }
        if (player.GetComponent<PlayerController>().dollar >= 1000 && player.GetComponent<PlayerController>().dollar < 5000)
        {
            LEVEL_3 = true;
            Destroy(level3UpgradePrefab);
            if (i < 1)
            {
                Instantiate(waterTankPrefab, new Vector3(20f, 0f, 30f), Quaternion.identity);
                i++;
            }
            
        }
        if (player.GetComponent<PlayerController>().dollar >= 5000 && player.GetComponent<PlayerController>().dollar < 15000)
        {
            LEVEL_4 = true;
            Destroy(level4UpgradePrefab);
            husbandryPrefab.gameObject.SetActive(true);
        }
        if (player.GetComponent<PlayerController>().dollar >= 15000 && player.GetComponent<PlayerController>().dollar < 35000)
        {
            LEVEL_5 = true;
            Destroy(level5UpgradePrefab);
            slaughterhousePrefab.gameObject.SetActive(true);
        }
    }
    // Tomato Selection
    public void isTomato()
    {
        tomato = true;
        cabbage = false;
    }
    // Cabbage Selection
    public void isCabbage()
    {
        tomato = false;
        cabbage = true;
    }
    // Help Button
    public void HelpButton()
    {
        
        Time.timeScale = 0;
        player.GetComponent<PlayerController>().isStopped = false;
        if (level1.GetComponent<Image>().enabled)
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(7).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(7).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(7).gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
        if (level2.GetComponent<Image>().enabled)
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(8).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(8).gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
        if (level3.GetComponent<Image>().enabled)
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(9).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(9).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(9).gameObject.transform.GetChild(4).gameObject.SetActive(true);
        }
        if (level4.GetComponent<Image>().enabled)
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(10).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(10).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(10).gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
        if (level5.GetComponent<Image>().enabled)
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(11).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(11).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(11).gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
    }
    public void ExitHelpButton()
    {
        Time.timeScale = 1;
        player.GetComponent<PlayerController>().isStopped = true; ;
        GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(7).gameObject.SetActive(false);
        for (int i = 0; i < GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(7).transform.childCount; i++)
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(7).gameObject.transform.GetChild(i).transform.gameObject.SetActive(false);
        }
        for (int i = 0; i < GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(8).transform.childCount; i++)
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(8).gameObject.transform.GetChild(i).transform.gameObject.SetActive(false);
        }
        for (int i = 0; i < GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(9).transform.childCount; i++)
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(9).gameObject.transform.GetChild(i).transform.gameObject.SetActive(false);
        }
        for (int i = 0; i < GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(10).transform.childCount; i++)
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(10).gameObject.transform.GetChild(i).transform.gameObject.SetActive(false);
        }
        for (int i = 0; i < GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(11).transform.childCount; i++)
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(11).gameObject.transform.GetChild(i).transform.gameObject.SetActive(false);
        }
        j = 0;
    }
    public void NextPageL1()
    {
        if (level1.GetComponent<Image>().enabled && j < GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(7).transform.childCount - 2)
        {
            j++;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(7).gameObject.transform.GetChild(j - 1).gameObject.SetActive(false);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(7).gameObject.transform.GetChild(j).gameObject.SetActive(true);
        }
        if (level2.GetComponent<Image>().enabled && j < GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(8).transform.childCount - 2)
        {
            j++;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(8).gameObject.transform.GetChild(j - 1).gameObject.SetActive(false);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(8).gameObject.transform.GetChild(j).gameObject.SetActive(true);
        }
        if (level3.GetComponent<Image>().enabled && j < GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(9).transform.childCount - 2)
        {
            j++;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(9).gameObject.transform.GetChild(j - 1).gameObject.SetActive(false);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(9).gameObject.transform.GetChild(j).gameObject.SetActive(true);
        }
        if (level4.GetComponent<Image>().enabled && j < GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(10).transform.childCount - 2)
        {
            j++;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(10).gameObject.transform.GetChild(j - 1).gameObject.SetActive(false);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(10).gameObject.transform.GetChild(j).gameObject.SetActive(true);
        }
        if (level5.GetComponent<Image>().enabled && j < GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(11).transform.childCount - 2)
        {
            j++;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(11).gameObject.transform.GetChild(j - 1).gameObject.SetActive(false);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(11).gameObject.transform.GetChild(j).gameObject.SetActive(true);
        }
    }
    public void PrevPageL1()
    {
        if (level1.GetComponent<Image>().enabled && j > 0)
        {
            j--;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(7).gameObject.transform.GetChild(j).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(7).gameObject.transform.GetChild(j+1).gameObject.SetActive(false);
        }
        if (level2.GetComponent<Image>().enabled && j > 0)
        {
            j--;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(8).gameObject.transform.GetChild(j).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(8).gameObject.transform.GetChild(j + 1).gameObject.SetActive(false);
        }
        if (level3.GetComponent<Image>().enabled && j > 0)
        {
            j--;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(9).gameObject.transform.GetChild(j).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(9).gameObject.transform.GetChild(j + 1).gameObject.SetActive(false);
        }
        if (level4.GetComponent<Image>().enabled && j > 0)
        {
            j--;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(10).gameObject.transform.GetChild(j).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(10).gameObject.transform.GetChild(j + 1).gameObject.SetActive(false);
        }
        if (level5.GetComponent<Image>().enabled && j > 0)
        {
            j--;
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(11).gameObject.transform.GetChild(j).gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(11).gameObject.transform.GetChild(j + 1).gameObject.SetActive(false);
        }
    }
}
