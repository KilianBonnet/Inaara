using System;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    
    private Vector3 marginFromPlayer;

    private void Start()
    {
        marginFromPlayer = transform.position - player.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + marginFromPlayer;
    }
}
