using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHandler : MonoBehaviour
{
	public List<bool> task;

	public void Awake() {
		task = new List<bool>();
	}

	public int registerTask() {
		task.Add(false);
		return task.Count - 1;
	}


	public void updateTask(int index, bool value) {
		task[index] = value;

		if(task.FindAll(t => t.Equals(true)).Count == task.Count) {
			Debug.Log("TaskDone");
			//DO SOMETHING HERE, TASK IS DONE
			GameManager.gameManager.unlockNextTask();
		}
	}
}
