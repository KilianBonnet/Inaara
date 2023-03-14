using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool wantToMove = anArrowIsPressed();
        bool isRunning = animator.GetBool(isRunningHash);

        // if player presses an arrow key
        if(wantToMove && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }

        if (!wantToMove && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }

        if(concurrentArrowsArePressed())
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    private bool anArrowIsPressed()
    {
        return Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right");
    }

    private bool concurrentArrowsArePressed()
    {
        return (Input.GetKey("up") && Input.GetKey("down")) || (Input.GetKey("left") && Input.GetKey("right"));
    }
}
