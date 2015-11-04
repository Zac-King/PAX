using UnityEngine;
using System.Collections;

public class Obstacle : HealthStats
{

    protected override void OnDead()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        float yoda = 5000f;
        GetComponent<Rigidbody>().AddForce(yoda * Vector3.up);
        //gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GetComponent<Rigidbody>().isKinematic = false;
            float yoda = 5000f;
            GetComponent<Rigidbody>().AddForce(yoda * Vector3.up);
        }
    }


}
/// Eric Mouledoux