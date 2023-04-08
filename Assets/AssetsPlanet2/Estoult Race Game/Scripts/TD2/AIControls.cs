using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class AIControls : MonoBehaviour
{
    private Vector2 input;
    public UnityEvent<Vector2> onInput;

    public Transform waypointsHolder;
    private List<Transform> waypoints;
    private Transform nextWaypoint;
    private Vector3 nextWaypointPosition;

    public float maxDistanceToTarget = 5f;
    public float maxDistanceToReverse = 10f;

    public float randomJitterOnPosition = .5f;

    void Awake()
    {
        waypoints = new List<Transform>();
        foreach (Transform child in waypointsHolder.transform)
            waypoints.Add(child);
    }

    void Start()
    {
        // Start with first waypoint
        SelectWaypoint(waypoints[0]);
    }

    void Update()
    {
        // Change to next waypoint if reached current waypoint
        float distanceToTarget = Vector3.Distance(transform.position, nextWaypointPosition);
        if (distanceToTarget < maxDistanceToTarget)
        {
            int nextIndex = waypoints.IndexOf(nextWaypoint) + 1;
            SelectWaypoint(nextIndex < waypoints.Count ? waypoints[nextIndex] : waypoints[0]);
        }

        // Compute Vector2 input based on distances in Right and Forward axis
        Vector3 diff = nextWaypointPosition - transform.position;
        float componentForward = Vector3.Dot(diff, transform.forward.normalized);
        float componentRight = Vector3.Dot(diff, transform.right.normalized);
        input = new Vector2(componentRight, componentForward).normalized;

        // If target behind but too far, turn around
        if (componentForward < 0 && distanceToTarget > maxDistanceToReverse)
        {
            input.y = 1f;
            input.x = Mathf.Sign(componentRight) * 1f;
        }
        onInput?.Invoke(input);
    }

    void SelectWaypoint(Transform waypoint)
    {
        nextWaypoint = waypoint;
        // Totally optional : 
        // This "jitter" add a little randomness around the waypoint to make the AI slightly more human 
        nextWaypointPosition = nextWaypoint.position + new Vector3(Random.Range(-randomJitterOnPosition, randomJitterOnPosition), 0, Random.Range(-randomJitterOnPosition, randomJitterOnPosition));
    }
}
