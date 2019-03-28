using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class OnTabletPickUp : MonoBehaviour
{

	[SerializeField] private iTweenAnimation hover;
	[SerializeField] private iTweenAnimation moveTo;
	[SerializeField] private float distance;
	[SerializeField] private float magnitudeThreshold;
	[SerializeField] private float secondsAfterThrow;

    public void onPickUp() {
		hover.enabled = false;
		GetComponent<Throwable>().currentHand.GetComponent<BoxCollider>().enabled = false;
	}

	public void onDrop() {
		hover.enabled = true;
		GetComponent<Throwable>().currentHand.GetComponent<BoxCollider>().enabled = true;
		if(GetComponent<VelocityEstimator>().GetVelocityEstimate().magnitude > magnitudeThreshold) {
			StartCoroutine(disableKinematicForSeconds(secondsAfterThrow));
		} 
	}

	private IEnumerator disableKinematicForSeconds(float seconds) {

		GetComponent<Rigidbody>().isKinematic = false;

		yield return new WaitForSeconds(seconds);

		GetComponent<Rigidbody>().isKinematic = true;

	}


	public void stopMoveTo() {
		StartCoroutine(changeAnimation(hover, moveTo));
	}

	public void startMoveTo() {
		StartCoroutine(changeAnimation(moveTo, hover));
	}

	private IEnumerator changeAnimation(iTweenAnimation start, iTweenAnimation stop) {
		stop.enabled = false;
		yield return new WaitForEndOfFrame();
		start.enabled = true;
	}

	private void Update() {
		if(Vector3.Distance(this.transform.position, Camera.main.transform.position) > distance && !moveTo.enabled) {
			startMoveTo();
		}
	}
}
