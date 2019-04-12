using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWayPoint : MonoBehaviour
{
	private void OnTriggerExit(Collider other)
	{
		GameManager.gameManager.enableWayPoint();
	}
}
