using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class ExpandPyramid : MonoBehaviour {
	
	[SerializeField] private GameObject text;
	[SerializeField] private LinearMapping lm;
	[SerializeField] private Transform handle1;
	[SerializeField] private Transform handle2;
	[SerializeField] private Transform pyramid;
	[SerializeField] private bool x, y, z;

	private Vector3 starPosition;
	private MeshRenderer mr;

	// Use this for initialization
	void Start () {
		starPosition = text.transform.localPosition;

	}

	// Update is called once per frame
	void Update () {
		if(x) {

			pyramid.localScale = new Vector3(lm.value + 0.5f , pyramid.localScale.y,pyramid.localScale.z);
			text.transform.localPosition = new Vector3(starPosition.x, starPosition.y, starPosition.z);
			handle1.localPosition = new Vector3(text.transform.localPosition.x, handle1.localPosition.y, handle1.localPosition.z);
			handle2.localPosition = new Vector3(text.transform.localPosition.x, handle2.localPosition.y, handle2.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Floor((lm.value * 2 * 10)) + "dm";
		}

		if(y) {
			pyramid.localScale = new Vector3(pyramid.localScale.x, lm.value + 0.5f ,pyramid.localScale.z);
			text.transform.localPosition = new Vector3(starPosition.x, starPosition.y, starPosition.z);
			handle1.localPosition = new Vector3(handle1.localPosition.x, text.transform.localPosition.y, handle1.localPosition.z);
			handle2.localPosition = new Vector3(handle2.localPosition.x, text.transform.localPosition.y, handle2.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Floor(lm.value * 2 * 10) + "dm";
		}

		if(z) {
			pyramid.localScale = new Vector3(pyramid.localScale.x , pyramid.localScale.y, lm.value + 0.5f);
			text.transform.localPosition = new Vector3(starPosition.x, starPosition.y, starPosition.z);
			handle1.localPosition = new Vector3(handle1.localPosition.x, handle1.localPosition.y, text.transform.localPosition.z);
			handle2.localPosition = new Vector3(handle2.localPosition.x, handle2.localPosition.y, text.transform.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Floor(lm.value * 2 * 10) + "dm";
		}
	}
}

