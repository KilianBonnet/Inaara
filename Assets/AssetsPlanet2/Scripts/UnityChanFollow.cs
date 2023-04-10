using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum FollowState {
    FIRST_MOVE,
    MID_DIALOG,
    SECOND_MOVE,
    LAST_DIALOG
}

public class UnityChanFollow : MonoBehaviour
{
     // Global configuration
    [SerializeField] private GameObject[] toDisable;
    [SerializeField] private Transform pathRootOne;
    [SerializeField] private Transform pathRootTwo;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotationSpeed = 5f;

    private FollowState followState;

    // Follow behavior
    private List<Vector3> waypoints;
    private Vector3 target;
    private int nextWaypoint;
    private bool isMoving;
    private bool isEnable;
    private Animator animator;

    // Mid Dialog
    [SerializeField] DialogueManager midDialog;
    [SerializeField] BoxCollider trashCollider;

    // Second Dialog
    [SerializeField] DialogueManager lastDialog;
    private Vector3 arcadeMachinePosition;

    void Start()
    {
        followState = FollowState.FIRST_MOVE;
        animator = GetComponent<Animator>();
        waypoints = new List<Vector3>();
        arcadeMachinePosition = GameObject.Find("To Look At").transform.position;
        foreach (Transform child in pathRootOne.transform)
            waypoints.Add(child.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if(!isEnable) return;
        if(!other.CompareTag("Player")) return;             // If the object collides with other things that the player
        if(isMoving) return;                                // If the object is already moving
        if(followState == FollowState.MID_DIALOG) return;   // If the state is not MID_DIALOG
        if(followState == FollowState.LAST_DIALOG) return;  // If the state is not LAST_DIALOG
        MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        isMoving = true;
        animator.SetFloat("Speed", speed);

        if(nextWaypoint == waypoints.Count - 1 && followState == FollowState.FIRST_MOVE) GetComponent<SphereCollider>().radius = 1.2f;
        if(nextWaypoint < waypoints.Count) target = waypoints[nextWaypoint];
        else if (followState == FollowState.FIRST_MOVE) MidDialogue();
        else if (followState == FollowState.SECOND_MOVE) LastDialogue();
    }

    private void FixedUpdate()
    {
        if(!isEnable) return;
        if(!isMoving) return;
        if (followState != FollowState.LAST_DIALOG && Vector3.Distance(target, transform.position) <= .5f)
        {
            animator.SetFloat("Speed", 0);
            isMoving = false;
            nextWaypoint++;
            return;
        }


        // Calculate the direction to the target
        Vector3 direction = ((followState != FollowState.LAST_DIALOG ? target : arcadeMachinePosition) - transform.position).normalized;

        // Calculate the target rotation around the Y axis
        float yRotation = Quaternion.LookRotation(direction).eulerAngles.y;
        if(followState == FollowState.LAST_DIALOG && yRotation <= .2) {
            isEnable = false;
            return;
        }
        Quaternion targetRotation = Quaternion.Euler(0, yRotation, 0);

        // Rotate towards the target around the Y axis only
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if(followState != FollowState.LAST_DIALOG)
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    public void Interact()
    {
        isEnable = true;
        foreach (var gameObject in toDisable) gameObject.SetActive(false);
    }

    private void MidDialogue() {
        followState = FollowState.MID_DIALOG;
        midDialog.Interact();
        trashCollider.enabled = false;
        animator.SetFloat("Speed", 0);
    }

    private void LastDialogue() {
        followState = FollowState.LAST_DIALOG;
        animator.SetFloat("Speed", 0);
        lastDialog.Interact();
        FindObjectOfType<RacePreparationQuest>().EndQUest();
    }

    public void StartSecondPath() {
        followState = FollowState.SECOND_MOVE;
        waypoints = new List<Vector3>();
        foreach (Transform child in pathRootTwo.transform)
            waypoints.Add(child.position);
        nextWaypoint = 0;
        GetComponent<SphereCollider>().radius = 3;
    }
}
