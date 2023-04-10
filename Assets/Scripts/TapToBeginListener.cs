using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToBeginListener : MonoBehaviour
{
    private TakeoffEstoult takeoff;
    private GameObject tapToBeginText;

    private void Start() {
        takeoff = FindObjectOfType<TakeoffEstoult>();
        tapToBeginText = GameObject.Find("Tap To Begin Panel");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            takeoff.Interact();
            tapToBeginText.SetActive(false);
        }
    }
}
