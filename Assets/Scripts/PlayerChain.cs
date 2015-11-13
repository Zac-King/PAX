using UnityEngine;
using System.Collections;

public class PlayerChain : MonoBehaviour 
{

	[SerializeField]
	private float ChainLength;

	[SerializeField]
	private GameObject ChainTarget;


	// Use this for initialization
	void Start () 
	{
		ChainSetUp();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	[ContextMenu("Check Distance")]
	void CheckChainDistance()
	{
		Vector3 anchorPos = this.gameObject.transform.position;
		Vector3 targetPos = ChainTarget.transform.position;

		Vector3 DistanceBetween = anchorPos - targetPos;
		Debug.Log(DistanceBetween.x + DistanceBetween.z);
	}

	void ChainSetUp()
	{
		if(GameObject.FindGameObjectWithTag("Player") != this.gameObject)
		{
			ChainTarget = GameObject.FindGameObjectWithTag("Player");
		}
	}
}
