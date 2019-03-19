using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSpace : MonoBehaviour {

	[SerializeField] private List<Space> spaces;
	[SerializeField] private List<Task> tasks;


	public void valueChanged(bool value, Space space) {
		valueChanged(value, space, 0);
	}

	public void valueChanged(bool value, Space space, float solution) {
		Task task;
		task = tasks[spaces.FindIndex(s => s == space)];
		task.changeSolution(solution, space.answerIsPlane());
		task.setAnswerSpaceCorrect(value);
	}
}
