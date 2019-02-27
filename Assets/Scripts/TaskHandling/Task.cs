using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour {

	[SerializeField] private bool plane;
	public float solution;
	public bool answerSpaceCorrect;
	public bool taskComplete;
	private TaskHandler taskHandler;
	public int index;

	// Start is called before the first frame update
	void Start() {
		taskHandler = GetComponentInParent<TaskHandler>();
		index = taskHandler.registerTask();
	}

	public void changeSolution(float solution) {
		this.solution = solution;
	}

	public void setAnswerSpaceCorrect(bool value) {
		answerSpaceCorrect = value;
		checkIfSolved();
	}

	public void checkIfSolved() {
		if(answerSpaceCorrect) {
			Vector3 size = this.transform.localScale;
			float volume = 0;
			if(plane) {
				volume = size.x * size.y * 100;
			}
			else {
				volume = size.x * size.y * size.z * 1000;
			}

			if(volume == solution) {
				taskComplete = true;
			}
			else {
				taskComplete = false;
			}
		}
		else {
			taskComplete = false;
		}

		taskHandler.updateTask(index, taskComplete);
	}

	public void onDetach() {
		checkIfSolved();
	}
}
