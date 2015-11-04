using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (canAttack)
        {
            StartCoroutine("TakeDamage", other);
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        StopCoroutine("TakeDamage");
    }

    protected virtual IEnumerator TakeDamage(Collider other)
    {
        while (other)
        {
            Messenger.Broadcast("takedamage", other.name);
            yield return new WaitForSeconds(timer);
        }
    }

    [SerializeField]
    float timer = 1;

    public bool canAttack = true;
}

/// Eric Mouledoux