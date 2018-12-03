using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Tasks : MonoBehaviour{

	public List<Task> tasks;
	private int task = 0;
	public Text text;
	private GameObject activeObject;
	public GameObject activeTaskObject;
	public string none = "";

	public void onDetach() {
		if(tasks[task].taskCheck()) {
			task++;
			text.text = tasks[task].text;
			if(tasks[task].prefab != none) {
				Destroy(activeObject);
				spawnObject();
			}
		}
	}

	public void spawnObject() {
		activeObject = Instantiate((GameObject)Resources.Load(tasks[task].prefab), this.transform);
		activeTaskObject = activeObject.transform.Find("TaskObject").gameObject;
	}

	public class Task {
		 
		public string text;
		public string prefab;
		public System.Func<bool> taskCheck;

		public Task(string text, string prefabName, System.Func<bool> taskCheck) {
			this.text = text;
			this.prefab = prefabName;
			this.taskCheck = taskCheck;
		}
	}
}