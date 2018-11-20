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
	// Use this for initialization
	void Start () {
		myPrism = new GeneratePrism(number, radius, height);

		foreach(Vector3[] v in myPrism.vertices) {
			GameObject myGameObject = Instantiate(prism, this.transform);
			Mesh mesh = new Mesh();
			myGameObject.GetComponent<MeshFilter>().mesh = mesh;
			mesh.vertices = v;
			mesh.triangles = myPrism.indices;
			MeshCollider mc = myGameObject.AddComponent<MeshCollider>();
			mc.convex = true;
            myGameObject.AddComponent<VelocityEstimator>();
            myGameObject.AddComponent<Throwable>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
