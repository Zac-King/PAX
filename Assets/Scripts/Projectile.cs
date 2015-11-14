using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    


    bool alive = true;
    void Start()
    {
        if (gameObject.GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        
        else StartCoroutine("Forward");
    }

    IEnumerator Forward()
    {   while (true)
        {
            transform.position += transform.forward * speed;

            yield return null;
        }
    }

    void Update()
    {
       
        Timer -= Time.deltaTime;
        if (Timer < 0)
            KillProjectile();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            KillProjectile();
            Messenger.Broadcast("takedamage", other.name);
        }
    }

    void KillProjectile()
    {
        if (!gameObject.GetComponent<Rigidbody>())
            StopCoroutine("Forward");

        Destroy(gameObject);
    }

    [SerializeField]
    private int speed = 5;
    [SerializeField]
    private float Timer = 100;

}
