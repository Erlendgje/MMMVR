using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WateringLogic : MonoBehaviour
{

	public UnityEvent onContainerInBox;
    [SerializeField] public int wantedValue;

    private int totalValue = 0;

	protected virtual void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name);

        int otherValue = 0;

        if (Int32.TryParse(other.name, out otherValue))
        {
            totalValue += otherValue;
            if (totalValue == wantedValue)
            {
                onContainerInBox.Invoke();
            }

            other.gameObject.SetActive(false);

            if (totalValue > wantedValue)
            {
                totalValue = 0;



            }

            Debug.Log(totalValue.ToString());
        }


    }

	public bool isCorrectContainer() {
		return true;
	}

    private void respawnShapes()
    {

    }

}