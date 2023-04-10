
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeSceneInteractable : Interactable
{
    // Start is called before the first frame update
    public override void Interact()
    {
        SceneManager.LoadScene("Museum");
    }
}
