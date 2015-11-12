using UnityEngine;
using System.Collections;

public class EnemyGuard : MonoBehaviour
{
    void Awake()
    {
        Messenger.AddListener<string>("entitydied", Die);	// Listens for the instance of its own death, _Stats
        Messenger.MarkAsPermanent("entitydied");

		fsm.AddState(STATES.INIT);
		fsm.AddState(STATES.IDLE);
		fsm.AddState(STATES.TRACKING);
		fsm.AddState(STATES.CHASING);
		fsm.AddState(STATES.DEAD);

		Callback<string> ToIdle;
		Callback<string> ToTracking;
		Callback<string> ToChasing;
		Callback<string> ToDead;
		ToIdle = Idle;
		ToTracking = Tracking;
		ToChasing = Chasing;

		fsm.AddTransition(STATES.INIT, 		STATES.IDLE, 		ToIdle);
		fsm.AddTransition(STATES.IDLE, 		STATES.TRACKING, 	ToTracking);
		fsm.AddTransition(STATES.IDLE, 		STATES.DEAD, 		ToIdle);
		fsm.AddTransition(STATES.TRACKING, 	STATES.IDLE, 		ToIdle);
		fsm.AddTransition(STATES.TRACKING, 	STATES.CHASING, 	ToChasing);
		fsm.AddTransition(STATES.TRACKING, 	STATES.DEAD, 		ToIdle);
		fsm.AddTransition(STATES.CHASING, 	STATES.IDLE, 		ToIdle);
		fsm.AddTransition(STATES.CHASING, 	STATES.TRACKING, 	ToTracking);
		fsm.AddTransition(STATES.CHASING, 	STATES.DEAD, 		ToIdle);

		fsm.m_currentState = STATES.INIT;
		fsm.MakeTransitionTo(STATES.IDLE);
    }

	void Update()
	{
		Debug.Log(fsm.m_currentState);
	}
	void Idle(string a_string)
	{
		target = null;                  // Set target to nothing
		rb = GetComponent<Rigidbody>(); // Get rigidbody component
		return;
	}
	void Tracking(string a_string)
	{
		StartCoroutine(TrackTarget());
	}
	void Chasing(string a_string)
	{
		StartCoroutine(ChaseTarget());
	}
    /// <summary>
    /// Coroutine for following a target
    /// </summary>
    IEnumerator TrackTarget()
    {
        RaycastHit hit;

        while (fsm.m_currentState == STATES.TRACKING)                                                                                          // As long as there is a valid target...
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);                                                         // Reset the velocity to prevent drifting
                                                                                                                    //
            Vector3 levelTarget =                                                                                   //
                new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);        // Bring the target position down to the current elevation to prevent flying 
            
			float dist = Vector3.Distance(transform.position, target.transform.position);         	        		// Get the distance from here to the target position                                                                                                    //
            Vector3 direction = (target.transform.position - transform.position).normalized + transform.position;   // Get the direction the target is in

            bool hasHit = Physics.Raycast(transform.position, direction, out hit, dist);	                        // Check to see if anything is between here and the target
            if (hasHit && hit.transform.gameObject == target)                                                       // If there is nothing between here and the target, but still a target
            {                                                                                                       //
				fsm.MakeTransitionTo(STATES.CHASING);
            }                                                                                                       //    
			else                                                                                                    // If there is something btween here and the target
            {                                                                                                       //
                rb.velocity = new Vector3(0, rb.velocity.y, 0);                                                         // Don't move
            }
            yield return null;  // Restarts the loop
        }
    }

	IEnumerator ChaseTarget()
	{
		RaycastHit hit;

		while(fsm.m_currentState == STATES.CHASING)
		{
			rb.velocity = new Vector3(0, rb.velocity.y, 0);

			Vector3 currentPos = new Vector3(transform.position.x, 0, transform.position.z);
			Vector3 heading = Vector3.Normalize(target.transform.position - currentPos);                                            // Get the direction to move it towards the target
			
			rb.AddForce(heading * speedConst * speed);                                                              // Move towards the target
			
			float yDist = target.transform.position.y - transform.position.y;
			
			if(yDist > 1f)
			{
				if(canJump)
				{
					rb.AddForce(transform.up * yDist);
					canJump = false;
				}
			}

			float dist = Vector3.Distance(transform.position, target.transform.position);         	        		
			Vector3 direction = (target.transform.position - transform.position).normalized + transform.position;                        	
			
			bool hasHit = Physics.Raycast(transform.position, direction, out hit, dist);	                       
			if (hasHit && hit.transform.gameObject != target)                                                      
			{                                                                                                       
				fsm.MakeTransitionTo(STATES.TRACKING);
			}                                                                                                       

			yield return null;
		}
	}
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && target == null)
        {
            target = other.gameObject;
			fsm.MakeTransitionTo(STATES.TRACKING);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
		{
            target = null;
			fsm.MakeTransitionTo(STATES.IDLE);
		}
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Messenger.Broadcast("modstat", other.gameObject.GetInstanceID().ToString(), "health", -1f);
        }
		if(other.contacts[0].point.y <= transform.position.y)
		{
			canJump = true;
		}
    }

    void Die(string a_instance)
    {
		if(a_instance == gameObject.GetInstanceID().ToString())
			Destroy(gameObject);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener<string>("entitydied", Die);
    }

////// VARIABLES // VARIABLES // VARIABLES // VARIABLES // VARIABLES 
    public float speed;

    public GameObject target;

	bool canJump;

    const float speedConst = 100;

    Vector3 nxtPos = new Vector3();
    Vector3 forward = new Vector3();

    Rigidbody rb;


	public enum STATES
	{
		INIT,
		IDLE,
		TRACKING,
		CHASING,
		DEAD,
	}
	
	_FSM<STATES> fsm = new _FSM<STATES>();
}
