using UnityEngine;
using System.Collections;

public class EnemyGuard : MonoBehaviour
{
    void Awake()
    {
        Messenger.AddListener<string>("entitydied", Die);// Listens for the instance of its own death
        Messenger.MarkAsPermanent("entitydied");
    }

    void Start()
    {
        target = null;                  // Set target to nothing
        rb = GetComponent<Rigidbody>(); // Get rigidbody component
    }

    /// <summary>
    /// Coroutine for following a target
    /// </summary>
    IEnumerator Persue()
    {
        RaycastHit hit;

        while (target)                                                                                          // As long as there is a valid target...
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);                                                         // Reset the velocity to prevent drifting
                                                                                                                    //
            Vector3 levelTarget =                                                                                   //
                new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);        // Bring the target position down to the current elevation to prevent flying 
            float dist = Vector3.Distance(transform.position, levelTarget);                                         // Get the distance from here to the target position
                                                                                                                    //
            Vector3 direction = (levelTarget - transform.position).normalized;                                      // Get the direction the target is in
            bool hasHit = Physics.Raycast(transform.position, direction, out hit, dist);                            // Check to see if anything is between here and the target
                                                                                                                    //
            if (hasHit && hit.transform.gameObject == target)                                                       // If there is nothing between here and the target, but still a target
            {                                                                                                       //
                Vector3 targetPos = new Vector3(target.transform.position.x, 0, target.transform.position.z);           // Get the target position minus elevation
                Vector3 currentPos = new Vector3(transform.position.x, 0, transform.position.z);                        // Get the current position minus the elevation
                Vector3 heading = Vector3.Normalize(targetPos - currentPos);                                            // Get the direction to move it towards the target
                rb.AddForce(heading * speedConst * speed);                                                              // Move towards the target
            }                                                                                                       //    
            else                                                                                                    // If there is something btween here and the target
            {                                                                                                       //
                rb.velocity = new Vector3(0, rb.velocity.y, 0);                                                         // Don't move
            }

            // DEBUGGING // DEBUGGING // DEBUGGING // DEBUGGING // DEBUGGING // DEBUGGING  // DEBUGGING // DEBUGGING // DEBUGGING // DEBUGGING // DEBUGGING // DEBUGGING 
            Debug.DrawLine(transform.position, levelTarget, Color.red);
            // DEBUGGING // DEBUGGING // DEBUGGING // DEBUGGING // DEBUGGING // DEBUGGING  // DEBUGGING // DEBUGGING // DEBUGGING // DEBUGGING // DEBUGGING // DEBUGGING 

            yield return null;  // Restarts the loop
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && target == null)
        {
            target = other.gameObject;
            StartCoroutine(Persue());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
            target = null;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Messenger.Broadcast("takedamage", name);
        }
    }

    void Die(string a)
    {

        if (a == name)
        {
          //  Messenger.RemoveListener<string>("entitydied", Die);
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        Messenger.RemoveListener<string>("entitydied", Die);
    }

    public float speed;

    public GameObject target;

    const float speedConst = 100;

    Vector3 nxtPos = new Vector3();
    Vector3 forward = new Vector3();

    Rigidbody rb;
}
