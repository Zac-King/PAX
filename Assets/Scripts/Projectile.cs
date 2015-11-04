using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    

    [SerializeField]
    private int speed = 5;
    [SerializeField]
    private float Timer = 100;

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
        Messenger.Broadcast("takedamage", other.name);
        KillProjectile();
    }

    void KillProjectile()
    {
        if (!gameObject.GetComponent<Rigidbody>())
            StopCoroutine("Forward");

        Destroy(gameObject);
    }


}
