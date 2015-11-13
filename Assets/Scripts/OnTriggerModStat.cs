using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnTriggerModStat : MonoBehaviour
{
	void Awake()
	{
		switch(statToMod)
		{
			case STATS.HEALTH: 		m_stat = "health"; 		break;
			case STATS.MANA:		m_stat = "mana"; 		break;
			case STATS.SPEED:		m_stat = "speed"; 		break;
			case STATS.STRENGTH:	m_stat = "strength"; 	break;
		}
	}

	protected IEnumerator Broadcast (GameObject other)
	{
		while (other && other.activeSelf == true && m_dangerZone.Contains(other.gameObject))
		{
			Messenger.Broadcast<string, string, float>("modstat", other.GetInstanceID().ToString(), m_stat, ammountToModBy);
			print (other.name);
			yield return new WaitForSeconds(timer);
		}
	}

	protected virtual void OnTriggerEnter(Collider other)
	{
		if(!other.isTrigger)
		{
			m_dangerZone.Add (other.gameObject);
			StartCoroutine("Broadcast", other.gameObject);
		}
	}
	
	protected virtual void OnTriggerExit(Collider other)
	{
		m_dangerZone.Remove(other.gameObject);
		StopCoroutine(Broadcast(other.gameObject));
	}

	public enum STATS
	{
		HEALTH,
		MANA,
		SPEED,
		STRENGTH,
	}

	public STATS statToMod;

	[SerializeField] private float ammountToModBy;
	[SerializeField] private float timer;

	private string m_stat;

	private List<GameObject> m_dangerZone = new List<GameObject>();
}

