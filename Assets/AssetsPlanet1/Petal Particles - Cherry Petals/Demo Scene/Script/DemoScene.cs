using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoScene : MonoBehaviour {

    public GameObject[] prefabs;
    public Text txtLabel;

    public void ShowEffect1()
    {
        prefabs[0].SetActive(true);
        prefabs[1].SetActive(false);
        txtLabel.text = "Petals Prefab 1";
    }


    public void ShowEffect2()
    {
        prefabs[0].SetActive(false);
        prefabs[1].SetActive(true);
        txtLabel.text = "Petals Prefab 2";
    }

    public void ShowEffect3()
    {
        prefabs[0].SetActive(true);
        prefabs[1].SetActive(true);
        txtLabel.text = "Petals Prefab 1+2";
    }
}
