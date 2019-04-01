using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

	private Vector3 startPosition;
	private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
		startPosition = this.transform.position;
		startRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(startPosition, this.transform.position) > 7) {
			this.transform.position = startPosition;
			this.transform.rotation = startRotation;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
    }
}
