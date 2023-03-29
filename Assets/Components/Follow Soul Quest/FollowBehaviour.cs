using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class FollowBehaviour : Interactable
{
    [SerializeField] private GameObject[] toDisable;
    [SerializeField] private Transform pathRoot;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotationSpeed = 5f;
    
    private List<Vector3> waypoints;
    private Vector3 target;
    private int nextWaypoint;
    private bool isMoving;
    
    private bool isEnable;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = new List<Vector3>();
        foreach (Transform child in pathRoot.transform)
            waypoints.Add(child.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if(!isEnable) return;
        if(!other.CompareTag("Player")) return; // If the object collides with other things that the player
        if(isMoving) return; // If the object is already moving
        MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        isMoving = true;
        target = waypoints[nextWaypoint];
    }

    private void FixedUpdate()
    {
        if(!isEnable) return;
        if(!isMoving) return;
        if (Vector3.Distance(target, transform.position) <= .1f)
        {
            isMoving = false;
            nextWaypoint++;
            return;
        }

        // Calculate the direction to the target
        Vector3 direction = (target - transform.position).normalized;

        // Rotate towards the target
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // Move forward
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    public override void Interact()
    {
        foreach (GameObject g in toDisable) g.SetActive(false);
        isEnable = true;
        IsTerminated = true;
    }
}
