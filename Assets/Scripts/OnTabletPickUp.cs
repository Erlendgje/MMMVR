using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class OnTabletPickUp : MonoBehaviour
{

	[SerializeField] private iTweenAnimation hover;

    public void onPickUp() {
		hover.enabled = false;
		GetComponent<Throwable>().currentHand.GetComponent<BoxCollider>().enabled = false;
	}

	public void onDrop() {
		hover.enabled = true;
		GetComponent<Throwable>().currentHand.GetComponent<BoxCollider>().enabled = true;
	}
}
