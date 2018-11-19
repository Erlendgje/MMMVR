using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ExpandLine : MonoBehaviour {
	
	[SerializeField] private GameObject text;
	[SerializeField] private LinearMapping lm;
	[SerializeField] private Transform handle1;
	[SerializeField] private Transform handle2;
	[SerializeField] private Transform background;
	[SerializeField] private bool x, y, z;

	private Vector3 starPosition;
	private MeshRenderer mr;
	private Vector2 mainTextureScale;

	// Use this for initialization
	void Start () {
		starPosition = text.transform.localPosition;
		mr = background.GetComponentInChildren<MeshRenderer>();
		mainTextureScale = mr.material.mainTextureScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(x) {
			mr.material.mainTextureScale = new Vector2(lm.value * 2, mr.material.mainTextureScale.y);
			background.localScale = new Vector3(this.transform.position.x, background.localScale.y, background.localScale.z);
			text.transform.localPosition = new Vector3(starPosition.x + (this.transform.position.x) / 2, starPosition.y, starPosition.z);
			handle1.localPosition = new Vector3(text.transform.localPosition.x, handle1.localPosition.y, handle1.localPosition.z);
			handle2.localPosition = new Vector3(text.transform.localPosition.x, handle2.localPosition.y, handle2.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Round(lm.value * 2, 1) + "dm";
		}

		if(y) {
			mr.material.mainTextureScale = new Vector2(mr.material.mainTextureScale.x, lm.value * 2);
			background.localScale = new Vector3(background.localScale.x, Mathf.Abs(this.transform.position.y), background.localScale.z);
			text.transform.localPosition = new Vector3(starPosition.x, starPosition.y + (this.transform.position.y) / 2, starPosition.z);
			handle1.localPosition = new Vector3(handle1.localPosition.x, text.transform.localPosition.y, handle1.localPosition.z);
			handle2.localPosition = new Vector3(handle2.localPosition.x, text.transform.localPosition.y, handle2.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Round(lm.value * 2, 1) + "dm";
		}

		if(z) {
			background.localScale = new Vector3(background.localScale.x, background.localScale.y, this.transform.position.z);
			text.transform.localPosition = new Vector3(starPosition.x, starPosition.y, (this.transform.position.z) / 2);
			handle1.localPosition = new Vector3(handle1.localPosition.x, handle1.localPosition.y, text.transform.localPosition.z);
			handle2.localPosition = new Vector3(handle2.localPosition.x, handle2.localPosition.y, text.transform.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Round(lm.value * 2, 1) + "dm";
		}
	}
}
