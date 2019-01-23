using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WateringLogic : MonoBehaviour
{

	public UnityEvent onContainerInBox;
    [SerializeField] public int wantedValue;


	private List<Vector3> tankPositions;
    private int totalValue = 0;


	void Start()
	{
		for (var i = 0; i < transform.childCount; i++) {
			tankPositions.Add (transform.GetChild (i).localPosition);
		}
	}


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
				respawnShapes ();
            }

            Debug.Log(totalValue.ToString());
        }


    }

	public bool isCorrectContainer() {
		return true;
	}

    private void respawnShapes()
    {
		for (var i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).localPosition = tankPositions[i];
			transform.GetChild (i).gameObject.SetActive (true);
		}
    }

}