using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI lapText;

    public void UpdateLapText(string message)
    {
        lapText.text = message;
    }
}
