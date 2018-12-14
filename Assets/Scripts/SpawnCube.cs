using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour {

	[SerializeField] GameObject cube;
	[SerializeField] int x, y, z;

	// Use this for initialization
	void Start () {
		
		for(int i = 0; i < x; i++) {
			for(int k = 0; k < y; k++) {
				for(int l = 0; l < z; l++) {
					Instantiate(cube, new Vector3(this.transform.position.x + i * 0.1f, this.transform.position.y + k * 0.1f, this.transform.position.z + l * 0.1f), Quaternion.Euler(0, 0, 0), this.transform);
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
