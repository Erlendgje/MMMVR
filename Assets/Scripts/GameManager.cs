using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager gameManager;
	private int currentTask = 0;

	[SerializeField] private TabletDialogueHandler tabletDialogueHandler;
	[SerializeField] private int spawnTaskNumber;
	[SerializeField] private List<GameObject> tasks;

    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null) {
			gameManager = this;
		}
		else {
			Destroy(this);
		}

		for(int i = 0; i < spawnTaskNumber; i++) {
			unlockNextTask();
		}
	}


    public void unlockNextTask() {
		currentTask++;
		if(currentTask < tasks.Count) {
			tasks[currentTask].SetActive(true);
		}
	}

	public int getCurrentTask() {
		return currentTask;
	}

	public TabletDialogueHandler GetDialogueHandler() {
		return tabletDialogueHandler;
	}
}
