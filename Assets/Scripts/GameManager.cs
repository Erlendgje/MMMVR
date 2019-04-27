using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	[SerializeField] private GameObject wayPoint;

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

        try
        {
            moveWayPoint(tasks[currentTask].transform.Find("WayPoint").transform.position);
        }
        catch
        {
            //No waypoint
        }
    }


    public void unlockNextTask() {
		currentTask++;
		if(currentTask < tasks.Count) {
			tasks[currentTask].SetActive(true);
            try
            {
                moveWayPoint(tasks[currentTask].transform.Find("WayPoint").transform.position);
            }
            catch
            {
                //No waypoint
            }
			
			enableWayPoint(tasks[currentTask]);
		}
	}

	public int getCurrentTask() {
		return currentTask;
	}

	public TabletDialogueHandler GetDialogueHandler() {
		return tabletDialogueHandler;
	}

	public void moveWayPoint(Vector3 position) {
		wayPoint.transform.position = position;
	}

	public void enableWayPoint(GameObject parent)
	{
		if(tasks.IndexOf(parent) == currentTask)
		{
			foreach (ParticleSystem ps in wayPoint.GetComponentsInChildren<ParticleSystem>())
			{
				Debug.Log("KJØRER");
				ps.Play();
			}
		}
	}
}
