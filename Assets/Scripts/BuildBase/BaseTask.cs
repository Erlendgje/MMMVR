using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTask : Tasks
{

    // Use this for initialization
    void Start()
    {
        tasks = new List<Task> {
            new Task ("Vi må lage task, flytt basen til bygg området", NONE, new System.Func<bool> (() => {

				if(activeTaskObject.GetComponentInChildren<ExpandBase>().inside && !activeTaskObject.GetComponentInChildren<ExpandBase>().outside) {
					return true;
				}
                return false;
            })),
            new Task ("Sweet, dette er en test. Trykk på menyknappen for å fortsette!", NONE, new System.Func<bool> (() => {
				TaskManager.taskManager.nextTask();
                return false;

            }))
        };
        spawnObject();
    }
}
