using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapToHover : MonoBehaviour
{

	private bool inHand = false;

	private Vector3 startPosition;
	private Rigidbody rgdb;

	void Start() {
		startPosition = transform.position;
		rgdb = this.GetComponent<Rigidbody>();
	}

	void OnTriggerStay(Collider other) {

		if (other.transform.tag == "Pillar" && !inHand) {

			rgdb.constraints = RigidbodyConstraints.FreezeRotation;
			rgdb.constraints = RigidbodyConstraints.FreezePosition;
			transform.position = startPosition;
			transform.Rotate (0, Time.deltaTime*8, 0, Space.World);
		}

	}

	void onPickUp() {
		inHand = true;
		rgdb.constraints = RigidbodyConstraints.None;
	}

}
