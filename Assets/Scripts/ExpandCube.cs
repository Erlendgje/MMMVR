using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ExpandCube : MonoBehaviour {

	[SerializeField] private GameObject text;
	[SerializeField] private LinearMapping lm;
	[SerializeField] private Transform handle1;
	[SerializeField] private Transform handle2;
	[SerializeField] private Transform background;
	[SerializeField] private bool x, y, z, d3;

	private Vector3 starPosition;
	private MeshRenderer mr;

	// Use this for initialization
	void Start () {
		starPosition = text.transform.localPosition;
		if(!d3) {
			mr = background.GetComponentInChildren<MeshRenderer>();
		}
	}

	// Update is called once per frame
	void Update () {
		if(x) {
			
			background.localScale = new Vector3((float)System.Math.Floor(this.transform.localPosition.x), background.localScale.y, background.localScale.z);
			text.transform.localPosition = new Vector3(this.transform.localPosition.x / 2, starPosition.y, starPosition.z);
			handle1.localPosition = new Vector3(text.transform.localPosition.x, handle1.localPosition.y, handle1.localPosition.z);
			handle2.localPosition = new Vector3(text.transform.localPosition.x, handle2.localPosition.y, handle2.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Floor(background.localScale.x) + "dm";
		}

		if(y) {
			
			background.localScale = new Vector3(background.localScale.x, -(float)System.Math.Floor(this.transform.localPosition.y), background.localScale.z);
			text.transform.localPosition = new Vector3(starPosition.x, this.transform.localPosition.y / 2, starPosition.z);
			handle1.localPosition = new Vector3(handle1.localPosition.x, text.transform.localPosition.y, handle1.localPosition.z);
			handle2.localPosition = new Vector3(handle2.localPosition.x, text.transform.localPosition.y, handle2.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Floor(-background.localScale.y) + "dm";
		}

		if(z) {
			
			background.localScale = new Vector3(background.localScale.x, background.localScale.y, (float)System.Math.Floor(this.transform.localPosition.x));
			text.transform.localPosition = new Vector3(starPosition.x, starPosition.y, -this.transform.localPosition.x / 2);
			handle1.localPosition = new Vector3(handle1.localPosition.x, handle1.localPosition.y, text.transform.localPosition.z);
			handle2.localPosition = new Vector3(handle2.localPosition.x, handle2.localPosition.y, text.transform.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Floor(background.localScale.z) + "dm";
		}
	}
}
