using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Follower : MonoBehaviour
{
    /// <summary>
    /// Chui's follower!
    /// 
    /// The Idea is like dungeon defender followers.
    /// </summary>

	public Transform overlord;
	public Vector3 overlordOffSet;
	public float maxSpeed = 0.5f;
    
	void Update()
	{
		follower();
	}
	/// <summary>
	/// So the follower will follow the overlord, and the overlordOffSet is where the follower
	/// will be relative to the overlord.
	/// 
	/// So the follower will find the point to fly by, using the overlordOffset position 
	/// relative to the master.
	/// 
	/// maxSpeed = how fast the follower it follow.
	/// </summary>
	public void follower()
	{
		Vector3 worldSpaceTarget = overlord.TransformPoint (overlordOffSet);
		transform.position = Vector3.Lerp(transform.position, worldSpaceTarget, maxSpeed);
	}


}
