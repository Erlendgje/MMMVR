using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prism : MonoBehaviour {

	GeneratePrism myPrism;
	[SerializeField] GameObject prism;
	// Use this for initialization
	void Start () {
		myPrism = new GeneratePrism(30, 1, 2);

		foreach(Vector3[] v in myPrism.vertices) {
			GameObject myGameObject = Instantiate(prism, this.transform);
			Mesh mesh = new Mesh();
			myGameObject.GetComponent<MeshFilter>().mesh = mesh;
			mesh.vertices = v;
			mesh.triangles = myPrism.indices;
			MeshCollider mc = myGameObject.AddComponent<MeshCollider>();
			mc.convex = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
