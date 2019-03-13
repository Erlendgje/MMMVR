using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager gameManager;
	private int currentTask = 0;

	[SerializeField] private List<TaskAndLocation> tasks;

    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null) {
			gameManager = this;
		}
		else {
			Destroy(this);
		}

        unlockNextTask();
	}


	public void unlockNextTask() {
		currentTask++;
		if(currentTask < tasks.Count) {
			Instantiate(tasks[currentTask].task, tasks[currentTask].position.transform);
		}
	}


	[Serializable]
	private class TaskAndLocation {
		public GameObject task;
		public GameObject position;
	}
}
