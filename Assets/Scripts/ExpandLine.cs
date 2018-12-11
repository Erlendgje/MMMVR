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
			if(d3) {
                foreach (MeshRenderer meshRenderer in background.Find("PlaneZ").GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material.mainTextureScale = new Vector2((float)System.Math.Round(lm.value * 2 - 0.05f, 1) + 0.005f, meshRenderer.material.mainTextureScale.y);
                }

                foreach (MeshRenderer meshRenderer in background.Find("PlaneY").GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material.mainTextureScale = new Vector2((float)System.Math.Round(lm.value * 2 - 0.05f, 1) + 0.005f, meshRenderer.material.mainTextureScale.y);
                }
            }
			else {
				mr.material.mainTextureScale = new Vector2((float)System.Math.Round(lm.value * 2 - 0.05f, 1) + 0.005f, mr.material.mainTextureScale.y);
			}
			background.localScale = new Vector3((float)System.Math.Round(this.transform.localPosition.x - 0.05f, 1), background.localScale.y, background.localScale.z);
			text.transform.localPosition = new Vector3(this.transform.localPosition.x / 2, starPosition.y, starPosition.z);
			handle1.localPosition = new Vector3(text.transform.localPosition.x, handle1.localPosition.y, handle1.localPosition.z);
			handle2.localPosition = new Vector3(text.transform.localPosition.x, handle2.localPosition.y, handle2.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Floor((lm.value * 2 * 10)) + "dm";
		}

		if(y) {
			if(d3) {
                foreach (MeshRenderer meshRenderer in background.Find("PlaneX").GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material.mainTextureScale = new Vector2((float)System.Math.Round(lm.value * 2 - 0.05f, 1) + 0.005f, meshRenderer.material.mainTextureScale.y);
                }
                foreach (MeshRenderer meshRenderer in background.Find("PlaneZ").GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material.mainTextureScale = new Vector2(meshRenderer.material.mainTextureScale.x, (float)System.Math.Round((lm.value * 2 - 0.05f), 1) * 10 + 0.005f * 10);
                }
            }
			else {
				mr.material.mainTextureScale = new Vector2(mr.material.mainTextureScale.x, (float)System.Math.Round((lm.value * 2 - 0.05f), 1) * 10 + 0.005f * 10);
			}
			background.localScale = new Vector3(background.localScale.x, (float)System.Math.Round(Mathf.Abs(this.transform.localPosition.y) - 0.05f, 1), background.localScale.z);
			text.transform.localPosition = new Vector3(starPosition.x, this.transform.localPosition.y / 2, starPosition.z);
			handle1.localPosition = new Vector3(handle1.localPosition.x, text.transform.localPosition.y, handle1.localPosition.z);
			handle2.localPosition = new Vector3(handle2.localPosition.x, text.transform.localPosition.y, handle2.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Floor(lm.value * 2 * 10) + "dm";
		}

		if(z) {
			if(d3) {
                foreach (MeshRenderer meshRenderer in background.Find("PlaneX").GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material.mainTextureScale = new Vector2(meshRenderer.material.mainTextureScale.x, (float)System.Math.Round((lm.value * 2 - 0.05f), 1) * 10 + 0.005f * 10);
                }

                foreach (MeshRenderer meshRenderer in background.Find("PlaneY").GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material.mainTextureScale = new Vector2(meshRenderer.material.mainTextureScale.x, (float)System.Math.Round((lm.value * 2 - 0.05f), 1) * 10 + 0.005f * 10);
                }
            }
			background.localScale = new Vector3(background.localScale.x, background.localScale.y, (float)System.Math.Round(this.transform.localPosition.x - 0.05f, 1));
			text.transform.localPosition = new Vector3(starPosition.x, starPosition.y, -this.transform.localPosition.x / 2);
			handle1.localPosition = new Vector3(handle1.localPosition.x, handle1.localPosition.y, text.transform.localPosition.z);
			handle2.localPosition = new Vector3(handle2.localPosition.x, handle2.localPosition.y, text.transform.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Floor(lm.value * 2 * 10) + "dm";
		}
	}
}
