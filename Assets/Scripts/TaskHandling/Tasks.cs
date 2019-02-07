﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public abstract class Tasks : MonoBehaviour{

	public List<Task> tasks;
	public int task = 0;
	public Text text;
	public GameObject activeObject;
	public GameObject activeTaskObject;
	public static string NONE = "";

	public void onDetach() {
		if(tasks[task].taskCheck()) {
            if(task <= tasks.Count)
            {
                task++;
            }
			text.text = tasks[task].text;
			if(tasks[task].prefab != NONE) {
				//Destroy(activeObject);
				spawnObject(task);
			}
		}
	}

	public void spawnObject(int task) {
		activeObject = GetComponentsInChildren<Transform>(true).Where(x => x.name == tasks[task].prefab).ToList()[0].gameObject;
		activeObject.SetActive(true);
		activeTaskObject = activeObject.transform.Find("TaskObject").gameObject;
		text.text = tasks[task].text;
	}

	public void loadTask(int taskState) {
		for(int i = 0; i < taskState; i++) {
			if(tasks[i].prefab != NONE) {
				spawnObject(i);
			}
		}
		task = taskState;
	}

    public abstract void onChangeScene();
    

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