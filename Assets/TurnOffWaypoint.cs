using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffWaypoint : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		GetComponent<ParticleSystem>().Stop();
	}
}
