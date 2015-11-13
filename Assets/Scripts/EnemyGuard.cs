using UnityEngine;
using System.Collections;

public class EnemyGuard : MonoBehaviour
{
    void Awake()
    {
		rb = GetComponent<Rigidbody>();

        Messenger.AddListener<string>("entitydied", Die);	// Listens for the instance of its own death, _Stats
        Messenger.MarkAsPermanent("entitydied");			// Preents errors from switching scenes

		fsm.AddState(STATES.INIT);		// Adds states to  the list of possible states
		fsm.AddState(STATES.IDLE);		//
		fsm.AddState(STATES.CHASING);	//

		Callback<string> ToIdle;		// Creates delegates for state switch handlers
		Callback<string> ToChasing;		//
		ToIdle = Idle;					// Assignes new delegates to respective functions
		ToChasing = Chasing;			//

		fsm.AddTransition(STATES.INIT, 		STATES.IDLE, 		ToIdle);	// Adds the list of valid transitions and handlers to FSM
		fsm.AddTransition(STATES.IDLE,		STATES.CHASING,		ToChasing);	//
		fsm.AddTransition(STATES.CHASING, 	STATES.IDLE, 		ToIdle);	//

		fsm.m_currentState = STATES.INIT;	// Sets current state to INIT
		fsm.MakeTransitionTo(STATES.IDLE);	// Switches from INIT state to IDLE state
    }

	/// <summary>
	/// Trtansition to IDLE satate handler
	/// </summary>
	/// <param name="a_string">Not used but necesary.</param>
	void Idle(string a_string)
	{
		target = null;			// Set target to nothing
		StopAllCoroutines();	// Stops all running coroutines
	}

	/// <summary>
	/// Trtansition to CHASING satate handler
	/// </summary>
	/// <param name="a_string">Not used but necesary.</param>
	void Chasing(string a_string)
	{
		StartCoroutine(ChaseTarget());	// Starts the coroutine for chasing the target "player"
	}

	/// <summary>
	/// Chases the target.
	/// </summary>
	/// <returns>The target.</returns>
	IEnumerator ChaseTarget()
	{
		RaycastHit hit;		// Variable for raycasting and pathfinding

		while(fsm.m_currentState == STATES.CHASING)															// As long as the current state is CHASING
		{																									//
			yield return null;																					// Wait till next update cycle
			rb.velocity = new Vector3(0, rb.velocity.y, 0);														// Reset velocity to prevent drifting

			Vector3 currentPos = new Vector3(transform.position.x, 0, transform.position.z);					// The current position of the entity in 2D - X, Z
			Vector3 targetPos  = new Vector3(target.transform.position.x, 0, target.transform.position.z);		// The current position of the target in 2D - X, Z

			Vector3 heading = Vector3.Normalize(targetPos - currentPos); 										// The reletive direction of the target from the entity

			float yDist = target.transform.position.y - transform.position.y;									// The reletive height difference between the entity and the target

			float dist = Vector3.Distance(transform.position, target.transform.position);						// The distance between the entity and the target                        	

			bool hasHit = Physics.Raycast(transform.position, heading, out hit, dist);	                   		// TRUE or FALSE if the entity has a direct line-of sight to target

			if (hasHit)																							// If the entity does have a direct line-of-sight to something
			{																									//
				if(hit.transform.gameObject == target || hit.transform.CompareTag("Enemy"))							// And if that something is the target or another like entity                                                     
				{																									//
					rb.AddForce(heading * speedConst * speed);															// Move toward the target

					if(yDist > 1f)																						// If the target if above the entity
					{																									//
						if(canJump)																							// And if the entity can current jump / is on the ground
						{																									//
							rb.AddForce(transform.up * speed * yDist * 100);													// Jump
							canJump = false;																					// Prevent infinity jumping
						}																									//
					}																									//
				}																									//
			}																									//
	}																										//
		fsm.MakeTransitionTo(STATES.IDLE);	// Resets the state to IDLE at the end
	}

	/// <summary>
	/// Attack the specified target.
	/// </summary>
	/// <param name="other">Other.</param>
	IEnumerator Attack(Collision other)
	{
		while(attacking)	// As long as the entity is "attacking"
		{
			Messenger.Broadcast("modstat", other.gameObject.GetInstanceID().ToString(), "health", -1f);	// Broadcast the attacking of the target
			yield return new WaitForSeconds(1);															// Wait 1 seccond before  restarting thye loop
		}
	}

	/// <summary>
	/// As long as something is within the detection zone
	/// </summary>
	/// <param name="other">Other.</param>
    void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && target == null	)	// If the something within the detection zone is a "player"
        {																//
            target = other.gameObject;										// Eet the target to that object
			fsm.MakeTransitionTo(STATES.CHASING);							// Start chasing the new target
        }
    }

	/// <summary>
	/// Once something leaves the detection zone
	/// </summary>
	/// <param name="other">Other.</param>
    void OnTriggerExit(Collider other)
	{
		if (other.gameObject == target)			// If the something is the current target
		{										//
			fsm.MakeTransitionTo(STATES.IDLE);		// Reset the current state to IDLE
		}
    }

	/// <summary>
	/// Once the entity has collided with something
	/// </summary>
	/// <param name="other">Other.</param>
    void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))				// If that something is a "player"
        {														//
			attacking = true;										// Beging attacking it
			StartCoroutine(Attack(other));							// By starting the Attack coroutine
        }														//
		if(other.contacts[0].point.y <= transform.position.y)	// If that something is below the entity
		{														//
			canJump = true;											// Reset jump / is touching the ground
		}														//
    }

	/// <summary>
	/// Once the entity has stoped colliding with something
	/// </summary>
	/// <param name="other">Other.</param>
	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))	// If that something is a "player"
		{											//
			attacking = false;							// Stop attacking
			StopCoroutine(Attack(other));				// By stopping the Attack coroutine
		}											//
	}

////// VARIABLES // VARIABLES // VARIABLES // VARIABLES // VARIABLES 
    public float speed;

    public GameObject target;

	bool canJump;
	bool attacking;

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
	}
	
	_FSM<STATES> fsm = new _FSM<STATES>();
}
