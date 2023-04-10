using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerComponent : Interactable
{
    public Transform target;
    NavMeshAgent nav;
    private Animator mAnimator;
    public bool follow = false;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!follow) return;
        if (!PositionsProches(transform.position,target.position))
        
            mAnimator.SetTrigger("run");
        else
            mAnimator.SetTrigger("stop");
        
        nav.SetDestination(target.position);

    }
    bool PositionsProches(Vector3 pos1, Vector3 pos2) {
        float distance = Vector3.Distance(pos1, pos2);
        return distance <= 2;
    }

    public override void Interact()
    {
        IsTerminated = true;
        follow = true;
    }
}
