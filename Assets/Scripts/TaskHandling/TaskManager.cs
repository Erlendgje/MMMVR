using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

	public List<MarsTask> marsTasks;
	public GameObject activeObject;
    public GameObject mathTask;
	public bool mathWorldDone;
	public int mathWorldTask;

	public static TaskManager taskManager;
	public int activeTask = 0;

	public void Start() {
		if(taskManager == null) {
			taskManager = this;
		}
		else {
			Destroy(this);
		}
	}


	public void nextTask() {
		activeTask++;
		mathWorldDone = false;
        mathWorldTask = 0;
        activeObject.GetComponent<Tasks>().enabled = false;
		activeObject = null;
	}

	public MarsTask getActiveTask() {
		return marsTasks[activeTask];
	}

	public void spawnTask() {
		activeObject = Instantiate(marsTasks[activeTask].task);
		activeObject.transform.position = marsTasks[activeTask].position;
	}
    
	public void setActive(bool value) {
        if (activeObject != null) {
            marsTasks[activeTask].task.GetComponentInChildren<Tasks>().onChangeScene();
            activeObject.SetActive(value);
            
        }
		else if(mathWorldDone) {
            marsTasks[activeTask].task.GetComponentInChildren<Tasks>().onChangeScene();
            spawnTask();
		}
	}

	[System.Serializable]
	public class MarsTask {
		public GameObject task;
		public Vector3 position;
		public Vector3 playerPosition;
	}
}
