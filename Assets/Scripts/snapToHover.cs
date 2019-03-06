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
        Debug.Log("before");
		if (other.transform.tag == "Pillar" && !inHand) {
            Debug.Log("after");

            rgdb.constraints = RigidbodyConstraints.FreezeRotation;
			rgdb.constraints = RigidbodyConstraints.FreezePosition;
   
            transform.position = new Vector3(other.transform.position.x, 1.7f, other.transform.position.z);
            
            transform.Rotate (0, Time.deltaTime*8, 0, UnityEngine.Space.World);
		}

	}

	public void OnPickUp() {
        Debug.Log("pickup");
        inHand = true;
		rgdb.constraints = RigidbodyConstraints.None;
	}

    public void OnDetach()
    {
        inHand = false;
    }

}
