using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerChain : MonoBehaviour 
{
	[SerializeField]
	float ChainLenght;

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

		ChainLenght = CalcDis(ChainAnchor.transform.position, ChainTarget.transform.position);

		Debug.Log(ChainAnchor.transform.position + LinkPrefab.transform.lossyScale);

		DrawChain();
	}

	void DrawChain()
	{
		GameObject l = Instantiate(LinkPrefab, new Vector3(ChainAnchor.transform.position.x + LinkPrefab.transform.lossyScale.x, 1, ChainAnchor.transform.position.z + LinkPrefab.transform.lossyScale.z)
		                           					, Quaternion.identity) as GameObject;
	}

	float CalcDis(Vector3 pos1, Vector3 pos2)
	{
		float dis;
		dis = ((pos2.y - pos1.y) * (pos2.y - pos1.y)) + ((pos2.x - pos1.x) * (pos2.x - pos1.x)) + ((pos2.z - pos1.z) * (pos2.z - pos1.z));
		return Mathf.Sqrt(dis) + ChainSlack;
	}

	// Update is called once per frame
	void Update () 
	{
			
	}
}
