using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class OnTabletPickUp : MonoBehaviour
{

    [SerializeField] private GameObject tabletMovePoint;
	[SerializeField] private iTweenAnimation hover;
	[SerializeField] private iTweenAnimation moveTo;
	[SerializeField] private float distance;
	[SerializeField] private float magnitudeThreshold;
	[SerializeField] private float secondsAfterThrow;
    private bool isThrowing = false;


	void Start(){

		GameManager.gameManager.unlockNextTask();
		startMoveTo();
	}


    public void onPickUp() {
		hover.enabled = false;
        moveTo.enabled = false;
		GetComponentInChildren<ParticleSystem>().Stop();
        StopAllCoroutines();
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
            isThrowing = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
	}

	private IEnumerator disableKinematicForSeconds(float seconds) {
        isThrowing = true;
		GetComponent<Rigidbody>().isKinematic = false;
		GetComponentInChildren<ParticleSystem>().Play();

		yield return new WaitForSeconds(seconds);

		GetComponent<Rigidbody>().isKinematic = true;
        isThrowing = false;
		GetComponentInChildren<ParticleSystem>().Stop();
	}


	public void stopMoveTo() {
		GetComponentInChildren<ParticleSystem>().Stop();
		StartCoroutine(changeAnimation(hover, moveTo));
	}

	public void startMoveTo() {
		tabletMovePoint.transform.position = this.transform.position;
		tabletMovePoint.transform.rotation = this.transform.rotation;
		GetComponentInChildren<ParticleSystem>().Play();
        StartCoroutine(changeAnimation(moveTo, hover));
        StartCoroutine(follow());
	}


    private IEnumerator follow()
    {
        yield return new WaitUntil(() => moveTo.enabled);
        while (moveTo.enabled)
        {
            this.transform.position = tabletMovePoint.transform.position;
            this.transform.rotation = tabletMovePoint.transform.rotation;

            yield return null;
        }
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
