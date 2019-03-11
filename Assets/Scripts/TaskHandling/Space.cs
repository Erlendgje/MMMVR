using System.Collections.Generic;
using UnityEngine;


public class Space : MonoBehaviour {

	private AnswerSpace answerSpace;
	private List<AnswerCube> answers;
	public bool correct;
	public bool checkValueChanged;

	// Start is called before the first frame update
	void Start() {
		answerSpace = GetComponentInParent<AnswerSpace>();
		answers = new List<AnswerCube>();
	}


	public void addAnswer(AnswerCube answer) {
		this.answers.Add(answer);
		checkSolution();
	}

	public void removeAnswer(AnswerCube answer) {
		this.answers.Remove(answer);
		checkSolution();
	}

	public bool isCorrect() {
		return correct;
	}

	public void checkSolution() {
		if(answers.Count != 0) {
			if (answers.FindAll(a => a.answerInDm == answers[0].answerInDm && a.plane == answers[0].plane).Count == answers[0].numbersInGroup && answers.Count == answers[0].numbersInGroup) {
				correct = true;
				answerSpace.valueChanged(correct, this, answers[0].answerInDm);
			}
			else {
				correct = false;
				answerSpace.valueChanged(correct, this);
			}
		}
		else {
			correct = false;
			answerSpace.valueChanged(correct, this);
		}
	}


	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.GetComponent<AnswerCube>() != null) {
			addAnswer(other.gameObject.GetComponent<AnswerCube>());
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.GetComponent<AnswerCube>() != null) {
			removeAnswer(other.gameObject.GetComponent<AnswerCube>());
		}
	}
}
