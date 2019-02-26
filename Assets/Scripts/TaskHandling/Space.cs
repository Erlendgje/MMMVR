using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour {

	private AnswerSpace answerSpace;
	private List<Answers> answers;
	private bool correct;

	// Start is called before the first frame update
	void Start() {
		answerSpace = GetComponentInParent<AnswerSpace>();
		answers = new List<Answers>();
	}

	// Update is called once per frame
	void Update() {

	}


	public void addAnswer(Answers answer) {
		this.answers.Add(answer);
		checkSolution();
	}

	public void removeAnswer(Answers answer) {
		this.answers.Remove(answer);
		checkSolution();
	}

	public bool isCorrect() {
		return correct;
	}

	public void checkSolution() {

		if(answers.FindAll(a => a.answerInDm == answers[0].answerInDm).Count == answers[0].numbersInGroup && answers.Count == answers[0].numbersInGroup) {
			correct = true;
			answerSpace.valueChanged(correct, this, answers[0].answerInDm);
		}
		else {
			correct = false;
			answerSpace.valueChanged(correct, this);
		}
	}
}
