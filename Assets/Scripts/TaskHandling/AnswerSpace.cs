using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSpace : MonoBehaviour {

	public Dictionary<Space, Task> answers;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void valueChanged(bool value, Space space) {
		valueChanged(value, space, 0);
	}

	public void valueChanged(bool value, Space space, float solution) {
		Task task;
		answers.TryGetValue(space, out task);
		task.setAnswerSpaceCorrect(value);
		task.changeSolution(solution);
	}
}
