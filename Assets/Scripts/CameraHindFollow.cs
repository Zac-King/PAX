using UnityEngine;
using System.Collections;

public class CameraHindFollow : MonoBehaviour
{
    Transform pivot;
    Transform cam;
    public Transform lookAtTarget;
    public Transform followTarget;

    public float yOffset = 0f;
    public float followTargetDist = 3f;
    public float pivotOffsetY;
    //public float playerDistanceToCamera = 2.2f;
    public float minDistance = 3f;
    public float maxDistance = 10f;
    public float followSpeed = 1f;
    public float smoothing = 0.1f;
    private float lookAtDistance;
    private float followDistance;

    //bool isOccluded = false;
    Vector3 offset;
    Vector3 cameraLookDirection;
    //Vector3 playerMoveDirection;
    //Vector3 clipPos = new Vector3(0, 0, 0);
    //Vector3 preOccludedPos;

    Vector3 aboveClipPlane = new Vector3(0, -1, 0);
    Vector3 bottomClipPlane = new Vector3(0, 1, 0);

    //set lookAtTarget and followTarget in editor
    [ContextMenu("Set Camera Targets")]
    void SetTargets(string camTarget)
    {
        GameObject player1 = GameObject.Find(camTarget);

        //set lookAt target
        if (GameObject.Find("lookAtTarget") != null)
        {
            if (lookAtTarget == null)
                lookAtTarget = GameObject.Find("lookAtTarget").transform;
        }
        else
        {
            GameObject g = new GameObject();
            g.name = "lookAtTarget";
            g.transform.parent = player1.transform;
            g.transform.position = player1.transform.position;
            lookAtTarget = g.transform;
        }
        //set follow target
        if (GameObject.Find("followTarget") != null)
        {
            if (followTarget == null)
                followTarget = GameObject.Find("followTarget").transform;
        }
        else
        {
            GameObject g = new GameObject();
            g.name = "followTarget";
            g.transform.parent = player1.transform;
            g.transform.position = new Vector3(lookAtTarget.position.x, 0, 
                                   lookAtTarget.position.z + followTargetDist);
            followTarget = g.transform;
        }
    }

    void Start()
    {
        cam = GetComponentInChildren<Camera>().transform;
        pivot = cam.parent;

        offset = new Vector3(0, yOffset, 0);
        pivotOffsetY = pivot.position.y;

        SetTargets("Player1");

        ////set initial camera position and orientation
        //transform.position = followTarget.position + (-followTarget.forward * distance) + 
        //                     new Vector3(0, 3, 0);
        //transform.LookAt(followTarget);
        //cameraLookDirection = transform.forward;

        //Reset();
        lookAtDistance = Vector3.Distance(lookAtTarget.position, pivot.transform.position);
        followDistance = Vector3.Distance(followTarget.position, pivot.transform.position);
    }

    void Update()
    {
        Vector3 v = followTarget.position - pivot.transform.position;
        //designed to always set behind player

        if ((v.x * v.x + v.z * v.z) <= minDistance * minDistance ||
            (v.x * v.x + v.z * v.z) >= maxDistance * maxDistance)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position +
                                (-lookAtTarget.forward * followDistance), Time.deltaTime * followSpeed);
        }
        else if ((v.x * v.x + v.z * v.z) <= lookAtDistance * lookAtDistance ||
                 (v.x * v.x + v.z * v.z) >= lookAtDistance * lookAtDistance)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position +
                                (-lookAtTarget.forward * followDistance), Time.deltaTime * smoothing);
        }

        HandleRotation();
        transform.LookAt(lookAtTarget.position /*+ offset*/);
        //if(isOccluded == false)
        //{
        //    preOccludedPos = pivot.position;
        //}
    }

    void Clip()
    {

    }

    void HandleRotation()
    {
        //shoot a ray from the followTarget to the camera pivot position
        cameraLookDirection = (followTarget.position + offset) - pivot.transform.position;
        RaycastHit hit;
        Ray r = new Ray(followTarget.position + offset, -cameraLookDirection);
        //ray from followTarget to pivot
        Physics.Raycast(r, out hit, followDistance);
        //ray from lookAtTarget to pivot
        //Physics.Raycast(new Ray(lookAtTarget.position + offset, -cameraLookDirection), out hit, followDistance);
        Debug.DrawRay(followTarget.position + offset, -cameraLookDirection, Color.red);
        //if the ray hit an obstacle blocking the view of the lookAtTarget, the camera should pan behind the followTarget
        if (hit.collider != null /*&& hit.distance <= followDistance*/)
        {
            //if (hit.normal == aboveClipPlane)
            //{
            //    Vector3 clipAmount = new Vector3(0, Time.deltaTime * followSpeed, 0);
            //    clipPos -= clipAmount;
            //    Debug.Log("clipPos: " + clipPos);
            //    pivot.position -= clipAmount;
            //}
            //transform.position = Vector3.Lerp(transform.position, lookAtTarget.position + 
            //                     (-lookAtTarget.forward * followDistance), Time.deltaTime * followSpeed);
        }
        //else
        //{
        //    pivot.position -= clipPos;// + new Vector3(0, pivotOffsetY, 0);
        //    Debug.Log("clipPos: " + clipPos);
        //    clipPos = Vector3.zero;
        //    Debug.Log("clipPos: " + clipPos);
        //}
        transform.position = Vector3.Lerp(transform.position, lookAtTarget.position + (-lookAtTarget.forward * followDistance), Time.deltaTime * followSpeed);
    }

    void Reset()
    {
        //transform.position = Vector3.Lerp(transform.position, lookAtTarget.position + 
        //                    (-lookAtTarget.forward * playerDistanceToCamera), Time.deltaTime * smoothing);
    }
}