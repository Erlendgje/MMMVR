using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBlinking : MonoBehaviour
{

	private Color c;

	[SerializeField] private float from, to, speed;


	private void Start() {
		c = new Color();
		c = this.GetComponent<MeshRenderer>().material.color;
	}

	public void startBlinking() {
		StartCoroutine(blink());
	}

	private IEnumerator blink() {
		while(true) {
			while(c.a < to) {
				c[3] = c.a + speed * Time.deltaTime;
				this.GetComponent<MeshRenderer>().material.color = c;
				yield return null;
			}
			while(c.a > from) {
				c[3] = c.a - speed * Time.deltaTime;
				this.GetComponent<MeshRenderer>().material.color = c;
				yield return null;
			}
		}
	}
}
