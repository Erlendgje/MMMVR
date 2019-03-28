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
    private bool isThrowing = false;

    public void onPickUp() {
		hover.enabled = false;
        moveTo.enabled = false;
		GetComponent<Throwable>().currentHand.GetComponent<BoxCollider>().enabled = false;
	}

	public void onDrop() {
		
		GetComponent<Throwable>().currentHand.GetComponent<BoxCollider>().enabled = true;
		if(GetComponent<VelocityEstimator>().GetVelocityEstimate().magnitude > magnitudeThreshold) {
			StartCoroutine(disableKinematicForSeconds(secondsAfterThrow));
		}
        else
        {
            hover.enabled = true;
        }
	}

	private IEnumerator disableKinematicForSeconds(float seconds) {
        isThrowing = true;
		GetComponent<Rigidbody>().isKinematic = false;

		yield return new WaitForSeconds(seconds);

		GetComponent<Rigidbody>().isKinematic = true;
        isThrowing = false;
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
		if(Vector3.Distance(this.transform.position, Camera.main.transform.position) > distance && !moveTo.enabled && !isThrowing) {
			startMoveTo();
		}

        if(hover.enabled && moveTo.enabled)
        {
            moveTo.enabled = false;
        }
	}
}
