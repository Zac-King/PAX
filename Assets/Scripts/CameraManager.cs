using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{    
    public Transform lookAtTarget;
    public Transform followTarget;

    void Awake()
    {
        lookAtTarget = new GameObject().transform;
        followTarget = new GameObject().transform;

        lookAtTarget.name = "lookAtTarget";
        followTarget.name = "followTarget";

        lookAtTarget.position = Vector3.zero;
        followTarget.position = Vector3.zero;

        SetTargets();
    }

    public void SetTargets()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            //set lookAt target        
            lookAtTarget.parent = player.transform;
            lookAtTarget.position = player.transform.position;
            //set follow target
            followTarget.parent = player.transform;
            followTarget.position = lookAtTarget.position;
        }
    }
}