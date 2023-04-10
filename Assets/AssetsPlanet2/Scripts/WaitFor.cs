using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitFor : Interactable
{
    [SerializeField] private float duration;

    public override void Interact()
    {
        Invoke("Enable", duration);
    }

    private void Enable() {
        IsTerminated = true;
    }
}
