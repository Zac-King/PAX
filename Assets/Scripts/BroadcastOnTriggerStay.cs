using UnityEngine;
using System.Collections;

/// <summary>
/// Will boradcast a message as long as a Collider is within the trigger
/// Start the broadcast on Enter
/// End the boradcast on Exit
/// </summary>
public class BroadcastOnTriggerStay : MonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(!other.isTrigger)
            StartCoroutine("Broadcast", other);
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        StopCoroutine("Broadcast");
    }

    protected virtual IEnumerator Broadcast(Collider other)
    {
        while (other)
        {
            Messenger.Broadcast(m_message.ToLower() + other.GetInstanceID(), other.name);
            yield return new WaitForSeconds(m_timer);
        }
    }


    [SerializeField] private string m_message;
    [SerializeField] private float m_timer = 1;
}

/// Eric Mouledoux and Q-Dog