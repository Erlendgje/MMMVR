using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapToHover : MonoBehaviour
{
	private bool inHand = false;
	private bool detached = false;

	public float speed = 1;

	void Start() {
	}

	void OnTriggerStay(Collider other) {
		if (other.transform.tag == "Pillar" && !inHand) {
            if (detached)
            {
                this.transform.SetParent(other.transform);
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                this.GetComponent<Rigidbody>().useGravity = false;
                detached = false;
            }

			if(this.transform.position != new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z)) {
				this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), speed * Time.deltaTime);
			}

            transform.Rotate (0, Time.deltaTime*8, 0, UnityEngine.Space.World);
		}

	}

	public void OnPickUp() {
		inHand = true;
        this.GetComponent<Rigidbody>().useGravity = true;

		foreach(GameObject go in GameObject.FindGameObjectsWithTag("GhostPyramid")) {
			if(go.transform.parent.GetComponentInChildren<AnswerCube>() == null) {
				go.GetComponent<MeshRenderer>().enabled = true;
			}
		}
    }

    public void OnDetach()
    {
        detached = true;
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("GhostPyramid")) {
			go.GetComponent<MeshRenderer>().enabled = false;
		}

        this.GetComponent<Rigidbody>().useGravity = true;
        inHand = false;
    }

}
