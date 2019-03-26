using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCube : MonoBehaviour
{

	public int answerInDm;
	public int numbersInGroup;
	public bool plane;
	private bool hasCollided;


	private void OnCollisionEnter(Collision collision) {
		hasCollided = true;
	}

	private void OnCollisionExit(Collision collision) {
		hasCollided = false;
	}

	private void OnCollisionStay(Collision collision) {
		hasCollided = true;
	}

	public bool getHasCollided() {
		return hasCollided;
	}
}
