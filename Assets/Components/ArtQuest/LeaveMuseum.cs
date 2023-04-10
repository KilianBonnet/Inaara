using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveMuseum : Interactable
{
    public bool canLeave;

    private void Start()
    {
        IsTerminated = false;
    }

    public override void Interact()
    {
        if(canLeave)
            SceneManager.LoadScene("Planet1_2");
        IsTerminated = true;
    }
}
