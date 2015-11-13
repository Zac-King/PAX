using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerChain : MonoBehaviour 
{
	[SerializeField]
	Vector3 ChainLength;

	[SerializeField]
	float ChainSlack;

	Vector3 Seperation;

	public GameObject ChainAnchor;
	public GameObject ChainTarget;
	public GameObject LinkPrefab;
	public List<GameObject>Links = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		ChainAnchor = FindObjectOfType<PlayerManager>().GetComponent<PlayerManager>().Player1;
		ChainTarget = FindObjectOfType<PlayerManager>().GetComponent<PlayerManager>().Player2;

		ChainLength = new Vector3(CalcDis(ChainAnchor.transform.position, ChainTarget.transform.position) + ChainSlack, 
		                          CalcDis(ChainAnchor.transform.position, ChainTarget.transform.position) + ChainSlack,
		                          CalcDis(ChainAnchor.transform.position, ChainTarget.transform.position) + ChainSlack);
	}

	void DrawChain()
	{
		
	}

	float CalcDis(Vector3 pos1, Vector3 pos2)
	{
		float dis;
		dis = ((pos2.y - pos1.y) * (pos2.y - pos1.y)) + ((pos2.x - pos1.x) * (pos2.x - pos1.x)) + ((pos2.z - pos1.z) * (pos2.z - pos1.z));
		return Mathf.Sqrt(dis);
	}

//	Vector3 CheckDisplacment(GameObject a)
//	{
////		Vector3 a = Vector3.zero;
////		if(CalcDis(ChainAnchor.transform.position, ChainTarget.transform.position) > ChainLength.x)
////		{
////			a.x = CalcDis(ChainAnchor.transform.position, ChainTarget.transform.position) - ChainLength;
////		}
//	}

	// Update is called once per frame
	void Update () 
	{

	}
}
