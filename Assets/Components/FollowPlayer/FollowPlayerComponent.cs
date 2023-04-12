using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerComponent : Interactable
{
    public Transform target;
    public NavMeshAgent nav;
    public Animator mAnimator;
    public bool follow = false;
    public bool isRunning = false;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!follow) return;
        if (!PositionsProches(transform.position, target.position))
        {
            if (!isRunning)
            {
                mAnimator.SetTrigger("run");
                isRunning = true;
            }
        }
        else if (isRunning)
        {
            mAnimator.SetTrigger("stop");
            isRunning = false;
        }
        
        nav.SetDestination(target.position);

    }
    bool PositionsProches(Vector3 pos1, Vector3 pos2)
    {
        Vector3 pos1_2D = new Vector3(pos1.x, 0f, pos1.z); // ignore y-axis
        Vector3 pos2_2D = new Vector3(pos2.x, 0f, pos2.z); // ignore y-axis
        float distance = Vector3.Distance(pos1_2D, pos2_2D);
        return distance <= 2f;
    }

    public override void Interact()
    {
        IsTerminated = true;
        follow = true;
    }
}
