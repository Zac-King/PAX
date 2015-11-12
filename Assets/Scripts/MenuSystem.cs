using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSystem : MonoBehaviour
{

	public void selfActivate(GameObject self)
	{
		self.SetActive (true);
	}

	public void selfDeactivate(GameObject self)
	{
		self.SetActive(false);
	}
}
