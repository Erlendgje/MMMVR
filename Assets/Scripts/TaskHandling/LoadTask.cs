using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTask : MonoBehaviour
{
	[SerializeField] private List<GameObject> taskObjects;

	// Start is called before the first frame update
	void Start() {
		if(TaskManager.taskManager.activeTask < taskObjects.Count) {
			TaskManager.taskManager.mathTask = Instantiate(taskObjects[TaskManager.taskManager.activeTask], this.transform);
		}
	}
}
