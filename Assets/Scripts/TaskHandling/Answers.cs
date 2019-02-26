using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "Answer", menuName = "ScriptableObjects/Answer", order = 1)]
public class Answers : ScriptableObject
{
	public int answerInDm;
	public int numbersInGroup;
	public string value;
}
