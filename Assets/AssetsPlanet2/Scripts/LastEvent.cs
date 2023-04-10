using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastEvent : MonoBehaviour
{
    [SerializeField] private GameObject[] toDisable;
    [SerializeField] private GameObject[] toEnable;

    private void OnTriggerEnter(Collider other) {
        if(!other.CompareTag("Player")) return;
        foreach (GameObject gameObject in toDisable) gameObject.SetActive(false);
        foreach (GameObject gameObject in toEnable) gameObject.SetActive(true);
        GetComponent<DialogueManager>().Interact();

        GameObject unityChan = GameObject.Find("unitychan");
        Destroy(unityChan.GetComponent<Interactor>());
        Destroy(unityChan.GetComponent<DialogueManager>());
        Destroy(unityChan.GetComponent<UnityChanFollow>());

        Destroy(GetComponent<BoxCollider>());
    }
}
