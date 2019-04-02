using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	void OnTriggerEnter(Collider other) {

		if (other.transform.name == "sciFiTablet_redWhite") {
			other.transform.GetComponent<OnTabletPickUp> ().enabled = true;
			Destroy (gameObject);
		}

	}
}
