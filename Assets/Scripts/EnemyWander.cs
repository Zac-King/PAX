using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class EnemyWander : MonoBehaviour
{
    void Start()
    {
        target = null;
        origin = transform.position;
        rb = GetComponent<Rigidbody>();
        SetNextPosition();
    }

    void Update()
    {
        rb.velocity = Vector3.zero;

        if (target)
        {
            Vector3 targetPos = new Vector3(target.transform.position.x, 0, target.transform.position.z);
            Vector3 currentPos = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 heading = Vector3.Normalize(targetPos - currentPos);
            rb.AddForce(heading * speedConst * speed * 2f);
            
            Debug.DrawLine(transform.position, target.transform.position, Color.red);
        }
        else
        {
            Vector3 targetPos = new Vector3(nxtPos.x, 0, nxtPos.z);
            Vector3 currentPos = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 heading = Vector3.Normalize(targetPos - currentPos);
            rb.AddForce(heading * speedConst * speed);

            Debug.DrawLine(transform.position, nxtPos, Color.red);
        }

        if (Vector3.Distance(transform.position, nxtPos) < 1f)
        {
            SetNextPosition();
        }
    }

    void SetNextPosition()
    {
        StartCoroutine(NextPosition());
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<UnityChanControlScriptWithRgidBody>() && target == null)
            target = other.gameObject;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
            target = null;
    }
    
    IEnumerator NextPosition()
    {
        do
        {
            Vector2 t = (Random.insideUnitCircle * range);
            nxtPos = new Vector3(t.x, 0, t.y) + origin;
            yield return null;
        } while (Physics.Raycast(transform.position, nxtPos, Vector3.Distance(transform.position, nxtPos))) ;
    }

    public float speed;
    public float range;

    public GameObject target;

    bool canMove;

    const float speedConst = 100;

    Vector3 nxtPos = new Vector3();
    Vector3 origin = new Vector3();
    Vector3 forward = new Vector3();

    Rigidbody rb;
}
