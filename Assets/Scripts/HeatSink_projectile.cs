﻿using UnityEngine;
using System.Collections;

public class HeatSink_projectile : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ProjectedMovement());
    }

    IEnumerator ProjectedMovement()
    {
        float timePassed = 0f;

        while (timePassed < _traveltime)
        {
            Vector3 pf = transform.position;
            pf += new Vector3(0, 0, 2);

            transform.position = Vector3.Lerp(transform.position, pf, _speed * Time.deltaTime);
            timePassed += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shootable")
        {
            Destroy(gameObject);
            Messenger.Broadcast("HeatSink_Hit", other.gameObject);
        }
    }

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _traveltime;      // In Seconds 
}
