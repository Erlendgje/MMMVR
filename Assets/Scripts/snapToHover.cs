using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapToHover : MonoBehaviour
{

	private bool inHand = false;

	public float speed = 1;
	private Rigidbody rgdb;

	void Start() {
		rgdb = this.GetComponent<Rigidbody>();
	}

	void OnTriggerStay(Collider other) {
		if (other.transform.tag == "Pillar" && !inHand) {

			rgdb.velocity = Vector3.zero;
			rgdb.useGravity = false;
			
			if(this.transform.position != new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z)) {
				this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), speed * Time.deltaTime);
			}

            transform.Rotate (0, Time.deltaTime*8, 0, UnityEngine.Space.World);
		}

	}

	public void OnPickUp() {
		inHand = true;
        rgdb.useGravity = true;
    }

    public void OnDetach()
    {
        rgdb.useGravity = true;
        inHand = false;
    }

}
