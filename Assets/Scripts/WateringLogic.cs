using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WateringLogic : MonoBehaviour
{

	public UnityEvent onContainerInBox;

	protected virtual void OnTriggerStay(Collider other)
	{
			Debug.Log("Enter");
			onContainerInBox.Invoke ();
	}

	public bool isCorrectContainer() {
		return true;
	}

}