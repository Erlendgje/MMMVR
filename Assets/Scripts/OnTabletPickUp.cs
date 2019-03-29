using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class OnTabletPickUp : MonoBehaviour
{

    [SerializeField] private GameObject tabletMesh;
	[SerializeField] private iTweenAnimation hover;
	[SerializeField] private iTweenAnimation moveTo;
	[SerializeField] private float distance;
	[SerializeField] private float magnitudeThreshold;
	[SerializeField] private float secondsAfterThrow;
    private bool isThrowing = false;

    public void onPickUp() {
		hover.enabled = false;
        moveTo.enabled = false;
        tabletMesh.SetActive(false);
        GetComponent<MeshRenderer>().enabled = true;
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
        tabletMesh.SetActive(false);
        GetComponent<MeshRenderer>().enabled = true;
		StartCoroutine(changeAnimation(hover, moveTo));
	}

	public void startMoveTo() {
        tabletMesh.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(changeAnimation(moveTo, hover));
        StartCoroutine(follow());
	}


    private IEnumerator follow()
    {
        yield return new WaitUntil(() => moveTo.enabled);
        while (moveTo.enabled)
        {
            Debug.Log("KJØRER");
            this.transform.position = tabletMesh.transform.position;
            tabletMesh.transform.position = Vector3.zero;
            this.transform.rotation = tabletMesh.transform.rotation;
            tabletMesh.transform.rotation = Quaternion.Euler(Vector3.zero);

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
