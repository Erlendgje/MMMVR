using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffWaypoint : MonoBehaviour
{
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag.CompareTo("Player") == 0)
		{
			foreach(ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
			{
				ps.Stop();
			}
		}
	}
}
