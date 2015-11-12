using UnityEngine;
using System.Collections;

public class PlayerChain : MonoBehaviour 
{

	[SerializeField]
	private float ChainLength;

	GameObject ChainAnchor;
	GameObject ChainTarget;

	void Awake()
	{
		Messenger.AddListener<GameObject, GameObject>("Chained", ChainSetUp);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void ChainSetUp(GameObject anchor, GameObject target)
	{
		ChainAnchor = anchor;
		ChainTarget = target;
	}
}
