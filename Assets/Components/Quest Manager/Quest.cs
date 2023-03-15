using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    public string questName;
    public string questDescription;

    public abstract void BeginQuest();
}