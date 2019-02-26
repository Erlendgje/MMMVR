using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHandler : MonoBehaviour
{
	private List<bool> task;

	public int registerTask() {
		task.Add(false);
		return task.Count - 1;
	}


	public void updateTask(int index, bool value) {
		task[index] = value;

		if(task.FindAll(t => t.Equals(true)).Count == task.Count) {
			//DO SOMETHING HERE, TASK IS DONE
		}
	}
}
