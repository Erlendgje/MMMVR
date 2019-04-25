using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskHandler : MonoBehaviour
{
	public List<bool> task;
	[SerializeField] private UnityEvent onCorrect;
    private bool done = false;

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
            //DO SOMETHING HERE, TASK IS DONE'
            onCorrect.Invoke();
            if (!done)
            {
				GameManager.gameManager.GetDialogueHandler().playStory("TaskHandler");
                GameManager.gameManager.unlockNextTask();
                done = true;
            }
		}
	}
}
