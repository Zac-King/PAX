using UnityEngine;
using System.Collections;

public class CameraFreeFollow : MonoBehaviour
{
    Transform pivot;
    Transform cam;
    Transform lookAtTarget;
    Transform followTarget;
    private CameraManager cm;

    public float yOffset = 0f;
    public float followTargetDist = 3f;
    public float pivotOffsetY;
    //public float minDistance = 15f;
    //public float maxDistance = 20f;
    public float followSpeed = 1f;
    //public float smoothing = 0.1f;
    //private float lookAtDistance;
    //private float followDistance;
    
    Vector3 offset;
    Vector3 camOffset;
    Vector3 cameraLookDirection;
    Vector3 playerMoveDirection;
    Vector3 clipPos = new Vector3(0, 0, 0);

    Vector3 aboveClipPlane = new Vector3(0, -1, 0);
    Vector3 bottomClipPlane = new Vector3(0, 1, 0);

    //set lookAtTarget and followTarget in editor
    void SetTargets()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        ////set lookAt target
        //if (GameObject.FindGameObjectWithTag("lookAtTarget") != null)
        //{
        //    if (lookAtTarget == null)
        //        lookAtTarget = GameObject.Find("lookAtTarget").transform;
        //}
        //else
        //{
        //    GameObject g = new GameObject();
        //    g.name = "lookAtTarget";
        //    g.transform.parent = player.transform;
        //    g.transform.position = player.transform.position;
        //    lookAtTarget = g.transform;
        //}
        ////set follow target
        //if (GameObject.Find("followTarget") != null)
        //{
        //    if (followTarget == null)
        //        followTarget = GameObject.Find("followTarget").transform;
        //}
        //else
        //{
        //    GameObject g = new GameObject();
        //    g.name = "followTarget";
        //    g.transform.parent = player.transform;
        //    g.transform.position = new Vector3(lookAtTarget.position.x, 0,
        //                           lookAtTarget.position.z + followTargetDist);
        //    followTarget = g.transform;
        //}

        //try 2
        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        ////set lookAt target
        //if (cm.lookAtTarget != null)
        //{
        //    if (lookAtTarget == null)
        //        lookAtTarget = cm.lookAtTarget;
        //}
        //else
        //{
        //    cm.lookAtTarget = player.transform;
        //    cm.lookAtTarget.position = player.transform.position;
        //    lookAtTarget = cm.lookAtTarget;
        //}
        ////set follow target
        //if (cm.followTarget != null)
        //{
        //    if (followTarget == null)
        //        followTarget = cm.followTarget;
        //}
        //else
        //{
        //    cm.followTarget.parent = player.transform;
        //    cm.followTarget.position = new Vector3(lookAtTarget.position.x, 0,
        //                           lookAtTarget.position.z + followTargetDist);
        //    followTarget = cm.followTarget;
        //}

        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        ////set lookAt target        
        //cm.lookAtTarget = player.transform;
        //cm.lookAtTarget.position = player.transform.position;
        //lookAtTarget = cm.lookAtTarget;
        ////set follow target
        //cm.followTarget.parent = player.transform;
        //cm.followTarget.position = new Vector3(lookAtTarget.position.x, 0,
        //                           lookAtTarget.position.z + followTargetDist);
        //followTarget = cm.followTarget;
    }

    void Start()
    {
        cm = GetComponentInParent<CameraManager>();

        cam = GetComponentInChildren<Camera>().transform;
        pivot = cam.parent;

        offset = new Vector3(0, yOffset, 0);
        pivotOffsetY = pivot.position.y;

        //SetTargets();

        lookAtTarget = cm.lookAtTarget;
        followTarget = cm.followTarget;
        //Reset();
        //lookAtDistance = Vector3.Distance(lookAtTarget.position, pivot.transform.position);
        //followDistance = Vector3.Distance(followTarget.position, pivot.transform.position);
        camOffset = followTarget.position - transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, lookAtTarget.position -
                             camOffset, Time.deltaTime * followSpeed);


        cam.transform.LookAt(lookAtTarget.position + offset);
    }

}
