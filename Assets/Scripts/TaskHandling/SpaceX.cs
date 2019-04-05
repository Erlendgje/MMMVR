using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;

public class SpaceX : MonoBehaviour {

	private static bool playedStory = false;

	private AnswerSpace answerSpace;
	private List<AnswerCube> answers;
	public bool correct;
	public bool checkValueChanged;

	[SerializeField] UnityEvent onCorrect;
	[SerializeField] UnityEvent onWrong;
	[SerializeField] UnityEvent onRegisterdAnswer;
	[SerializeField] private bool useRegisterdAnswer;
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
				if(useRegisterdAnswer) {
					onRegisterdAnswer.Invoke();
				}
				else {
					onCorrect.Invoke();
					if(!playedStory) {
						GameManager.gameManager.GetDialogueHandler().playStory();
						playedStory = true;
					}
				}
				answerSpace.valueChanged(correct, this, answers[0].answerInDm);
			}
			else {
				correct = false;
				if(useRegisterdAnswer) {
					onRegisterdAnswer.Invoke();
				}
				else {
					onWrong.Invoke();
				}
				answerSpace.valueChanged(correct, this);
			}
		}
		else {
			correct = false;
			onWrong.Invoke();
			answerSpace.valueChanged(correct, this);
		}
	}

	private void OnTriggerStay(Collider other) {
		
		if(other.gameObject.GetComponent<AnswerCube>() != null) {
			AnswerCube ac = other.gameObject.GetComponent<AnswerCube>();
			if(!answers.Contains(ac)) {
				if(ac.getHasCollided() || useRegisterdAnswer) {
					addAnswer(ac);
				}
			}
			else {
				if(!ac.getHasCollided() && !useRegisterdAnswer) {
					removeAnswer(ac);
				}
			}
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.GetComponent<AnswerCube>() != null) {
			if(answers.Contains(other.gameObject.GetComponent<AnswerCube>())) {
				removeAnswer(other.gameObject.GetComponent<AnswerCube>());
			}
		}
	}

	public bool answerIsPlane() {
		if(correct) {
			return answers[0].plane; 
		}
		else {
			return false;
		}
	}
}
