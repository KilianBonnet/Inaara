using UnityEngine;

public class TricolorLights : MonoBehaviour
{
    public MeshRenderer firstLight;
    public MeshRenderer secondLight;
    public MeshRenderer thirdLight;

    public Color offColor = Color.black;
    public Color onColor = Color.red;
    public Color goColor = Color.green;

    private void Start()
    {
        SetAllLightsOff();
    }

    public void SetAllLightsOff()
    {
        SetAllLights(offColor);
    }

    public void SetProgress(int number)
    {
        // Shut off all lights first
        SetAllLightsOff();
        if (number == 1) firstLight.materials[1].color = onColor;
        else if (number == 2)
        {
            firstLight.materials[1].color = onColor;
            secondLight.materials[1].color = onColor;
        }
        else if (number == 3) SetAllLights(onColor);
        else if (number == 4) SetAllLights(goColor);
    }

    public void SetAllLights(Color color)
    {
        // We need to get the second material on the mesh renderer because 2 materials are applied to it
        // and we want to change the color of the light bulb, not the ring
        firstLight.materials[1].color = color;
        secondLight.materials[1].color = color;
        thirdLight.materials[1].color = color;
    }
}
