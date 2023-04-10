using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCLastInteraction : Interactable
{
    [SerializeField] private Transform teleportationPoint;
    private GameObject unityChan;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float rotationSpeed = 5f;
    
    private List<Vector3> waypoints;
    private Vector3 target;
    private int nextWaypoint;
    private bool isEnable;



    public override void Interact()
    {
        unityChan = GameObject.Find("unitychan");
        unityChan.transform.position = teleportationPoint.position;
        unityChan.transform.rotation = teleportationPoint.rotation;

        waypoints = new List<Vector3>();
        foreach (Transform child in teleportationPoint.transform)
            waypoints.Add(child.position);

        isEnable = true;
        target = waypoints[nextWaypoint];
        nextWaypoint++;
        unityChan.GetComponent<Animator>().SetFloat("Speed", speed);
    }

    private void FixedUpdate()
    {
        if(!isEnable) return;
        if (Vector3.Distance(target, unityChan.transform.position) <= 1f)
        {
            MoveToNextWaypoint();
            return;
        }

        // Calculate the direction to the target
        Vector3 direction =  (target - unityChan.transform.position).normalized;

        // Calculate the target rotation around the Y axis
        float yRotation = Quaternion.LookRotation(direction).eulerAngles.y;

        Quaternion targetRotation = Quaternion.Euler(0, yRotation, 0);

        // Rotate towards the target around the Y axis only
        unityChan.transform.rotation = Quaternion.Lerp(unityChan.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        unityChan.transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private void MoveToNextWaypoint()
    {
        Debug.Log(nextWaypoint);
        if(nextWaypoint >= waypoints.Count) {
            isEnable = false;
            IsTerminated = true;
            unityChan.GetComponent<Animator>().SetFloat("Speed", 0);
            return;
        }

        target = waypoints[nextWaypoint];
        nextWaypoint++;
    }
}
