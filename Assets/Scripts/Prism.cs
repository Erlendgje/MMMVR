using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Prism : MonoBehaviour {

	GeneratePrism myPrism;
	[SerializeField] GameObject prism;
    [SerializeField] int number;
    [SerializeField] float radius;
    [SerializeField] float height;
	[SerializeField] LinearMapping lm;
	private float currentLM;
	// Use this for initialization
	void Start () {
		createPrism(number, radius, height);
		currentLM = lm.value;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(currentLM != System.Math.Round(lm.value, 2)) {
			currentLM = (float)System.Math.Round(lm.value, 2);

			foreach(Transform t in transform) {
				Destroy(t.gameObject);
			}

			if(Mathf.Round(lm.value * 100) >= 3) {
				createPrism((int)Mathf.Round(lm.value * 100), radius, height);
			}
			else {
				createPrism(3, radius, height);
			}
		}

	}

	private void createPrism(int number, float radius, float height) {
		myPrism = new GeneratePrism(number, radius, height);

		foreach(Vector3[] v in myPrism.vertices) {
			GameObject myGameObject = Instantiate(prism, this.transform);
			myGameObject.transform.localPosition = new Vector3(0, 0, 0);
			Mesh mesh = new Mesh();
			myGameObject.GetComponent<MeshFilter>().mesh = mesh;
			mesh.vertices = v;
			mesh.triangles = myPrism.indices;
			MeshCollider mc = myGameObject.AddComponent<MeshCollider>();
			mc.convex = true;
		}
	}
}
