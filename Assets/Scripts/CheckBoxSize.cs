using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxSize : MonoBehaviour
{

	enum Type { cm, dm, m };

	[SerializeField] Type myType;
	[SerializeField] GameObject cubeToCheck;
	private TextMesh tm;
	[SerializeField] private bool d3;
	private char ending;
	private float z;
	private float times;

	private void Start() {
		tm = GetComponent<TextMesh>();
		if(d3) {
			ending = '\u00B3';
			times = 10;
		}
		else {
			ending = '\u00B2';
			times = 1;
		}
	}

	// Update is called once per frame
	void Update()
    {

		if(d3) {
			z = cubeToCheck.transform.localScale.z;
		}
		else {
			z = 1;
		}

		if(myType == Type.cm) {
			tm.text = System.Math.Round(cubeToCheck.transform.localScale.x * cubeToCheck.transform.localScale.y * z * 10000 * times * times, 2) + "cm" + ending;
		}
		else if(myType == Type.dm) {
			tm.text = System.Math.Round(cubeToCheck.transform.localScale.x * cubeToCheck.transform.localScale.y * z * 100 * times, 2) + "dm" + ending;
		}
		else if(myType == Type.m) {
			tm.text = System.Math.Round(cubeToCheck.transform.localScale.x * cubeToCheck.transform.localScale.y * z, 2) + "m" + ending;
		}
	}
}
