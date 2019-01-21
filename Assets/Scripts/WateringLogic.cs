using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WateringLogic : MonoBehaviour
{

	public UnityEvent onContainerInBox;

	protected virtual void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name);
        if (other.name.Equals("Cube"))
        {
            onContainerInBox.Invoke();
        }
		

	}

	public bool isCorrectContainer() {
		return true;
	}

}