using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnJoin2_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DialogueManager>().Interact();
    }
}
