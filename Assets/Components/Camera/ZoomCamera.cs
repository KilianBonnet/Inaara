using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomCamera : Interactable
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float cameraDistance;
    [SerializeField] float cameraAngle;
    [SerializeField] bool turnAroundTarget;
    public GameObject target;
    CinemachineComponentBase componentBase;

    private bool doRotation;

    private void Start()
    {
        doRotation = false;
    }

    private void Update()
    {
       if(doRotation && turnAroundTarget && target != null)
        {
            virtualCamera.transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        if (componentBase is CinemachineFramingTransposer)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance = cameraDistance;
            doRotation = true;
            virtualCamera.m_Follow = target.transform;
            virtualCamera.transform.eulerAngles = new Vector3(
                cameraAngle,
                virtualCamera.transform.eulerAngles.y,
                virtualCamera.transform.eulerAngles.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        if (componentBase is CinemachineFramingTransposer)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance = 10;
            doRotation = false;
            virtualCamera.transform.eulerAngles = new Vector3(
                45,
                0,
                virtualCamera.transform.eulerAngles.z);
            virtualCamera.m_Follow = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public override void Interact()
    {

    }
}
