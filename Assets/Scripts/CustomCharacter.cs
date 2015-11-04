using UnityEngine;
using System.Collections;

public class CustomCharacter : MonoBehaviour {
    [SerializeField]
    private Vector3 curPos, prevPos;

    public UnityEngine.UI.Text spd;
    public UnityEngine.UI.Text h;
    public UnityEngine.UI.Text v;
    [SerializeField]
    private float speed;
    void Awake()
    {
        curPos = Vector3.zero;
        prevPos = curPos;
    }
	// Update is called once per frame
	void FixedUpdate ()
    {
        h.text = Input.GetAxis("Horizontal").ToString();
        v.text = Input.GetAxis("Vertical").ToString();
        prevPos = curPos;

        curPos = transform.position;

        speed = (prevPos - curPos).magnitude/Time.deltaTime;
        spd.text = speed.ToString();
        

	}

    
}
