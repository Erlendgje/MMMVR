using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSpace : MonoBehaviour {

	[SerializeField] private List<SpaceX> spaces;
	[SerializeField] private List<Task> tasks;


	public void valueChanged(bool value, SpaceX space) {
		valueChanged(value, space, 0);
	}

	public void valueChanged(bool value, SpaceX space, float solution) {
		Task task;
		task = tasks[spaces.FindIndex(s => s == space)];
		task.changeSolution(solution, space.answerIsPlane());
		task.setAnswerSpaceCorrect(value);
	}
}
