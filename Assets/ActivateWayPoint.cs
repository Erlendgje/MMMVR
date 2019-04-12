using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWayPoint : MonoBehaviour
{
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag.CompareTo("Player") == 0)
		{
			GameManager.gameManager.enableWayPoint(transform.parent.gameObject);
		}
	}
}
