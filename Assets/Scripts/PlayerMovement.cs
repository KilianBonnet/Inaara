using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] public bool inversed;
    [SerializeField] public bool reverse;

    

    [Tooltip("Maximum angle of slope the player can climb")]
    [SerializeField] private float maxSlopeAngle = 5f;
    private Terrain terrain;
    private bool hasTerrain = true;
    private Vector3 lastValidPosition;
    private Quaternion lastValidRotation;
    
    private Animator animator;
    private bool hasAnimator = true;
    
    private PlayerStateManager playerStateManager;
    private bool hasPlayerStateManager = true;
    
    private Vector3 movement;
    private int isRunningHash;

    public AudioSource footStep;
    private bool hasAudioSource = true;


    // Start is called before the first frame update
    void Start()
    {
        // Find the Player State Manager
        if ((playerStateManager = FindObjectOfType<PlayerStateManager>()) == null)
        {
            Debug.LogWarning("Cannot find object of type PlayerStateManager!");
            hasPlayerStateManager = false;
        }
        
        // Find the Terrain
        if ((terrain = FindObjectOfType<Terrain>()) == null)
        {
            Debug.LogWarning("Cannot find object of type Terrain!");
            hasTerrain = false;
            Transform t = transform;
            lastValidPosition = t.position;
            lastValidRotation = t.rotation;
        }
        
        // Find the Animator
        if ((animator = GetComponent<Animator>()) == null)
        {
            Debug.LogWarning("Cannot find object of type Animator!");
            hasAnimator = false;
        }
        
        // Find the audioSource
        if ((footStep = GetComponent<AudioSource>()) == null)
        {
            Debug.LogWarning("Cannot find object of type AudioSource!");
            hasAudioSource = false;
        }
        

        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        if (inversed)
        {
            movement.x = -Input.GetAxisRaw("Vertical");
            movement.z = Input.GetAxisRaw("Horizontal");
        }
        else if(reverse)
        {
            movement.x = Input.GetAxisRaw("Vertical");
            movement.z = -Input.GetAxisRaw("Horizontal");
        }
        else
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        // Prevent player movement during interactions
        if (hasPlayerStateManager && playerStateManager.PlayerState != PlayerState.PLAYING)
        {
            if(hasAnimator) animator.SetBool(isRunningHash, false);
            if(hasAudioSource) footStep.enabled = false;
            return;
        }

        // Prevent terrain climbing
        if (hasTerrain)
        {
            // Normalize player coordinates
            Vector3 terrainPosition = terrain.transform.position;
            Vector3 playerPosition = transform.position;
            float normalizedX = Mathf.InverseLerp(terrainPosition.x, terrainPosition.x + terrain.terrainData.size.x, playerPosition.x);
            float normalizedY = Mathf.InverseLerp(terrainPosition.z, terrainPosition.z + terrain.terrainData.size.z, playerPosition.z);

            // Get slope angle at the given player position
            float slopeAngle = terrain.terrainData.GetSteepness(normalizedX, normalizedY);

            // Check if the slope is too sharp
            if (slopeAngle > maxSlopeAngle)
            {
                transform.position = lastValidPosition;
                transform.rotation = lastValidRotation;
                return;
            }
            
            lastValidPosition = transform.position;
            lastValidRotation = transform.rotation;
        }
        
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        if (!movement.Equals(Vector3.zero))
        {
            transform.rotation = Quaternion.LookRotation(movement);
            if(hasAnimator) animator.SetBool(isRunningHash, true);
            if(hasAudioSource) footStep.enabled = true;

        }
        else if (hasAnimator)
        {
            animator.SetBool(isRunningHash, false);
            if(hasAudioSource) footStep.enabled = false;
        }
    }
}
