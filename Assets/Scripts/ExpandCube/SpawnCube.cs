using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour {

	[SerializeField] GameObject cube;
	[SerializeField] int x, y, z = 10;

	// Use this for initialization
	void Start () {
		
		for(int i = 0; i < x; i++) {
			for(int k = 0; k < y; k++) {
				for(int l = 0; l < z; l++) {
					Instantiate(cube, this.transform).transform.localPosition = new Vector3( i * 0.101f, k * 0.101f, l * 0.101f);
				}
			}
		}

	}


    public void activateGravity()
    {
        foreach(Rigidbody r in this.GetComponentsInChildren<Rigidbody>())
        {
            r.isKinematic = false;
        }
    }
}
