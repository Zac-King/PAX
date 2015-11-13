using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			Messenger.Broadcast("modstat", other.gameObject.GetInstanceID().ToString(), "health", -1f);
		}
	}
}
