using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTask : Tasks
{
    public override void onChangeScene()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<BaseArrow>().enabled = !GameObject.FindGameObjectWithTag("GameController").GetComponent<BaseArrow>().enabled;
    }

    // Use this for initialization
    void Start()
    {
        tasks = new List<Task> {
            new Task ("Vi må lage task, flytt basen til bygg området", "Base", new System.Func<bool> (() => {
                Debug.Log(activeTaskObject.GetComponentInChildren<ExpandBase>().inside);
				if(activeTaskObject.GetComponentInChildren<ExpandBase>().inside && !activeTaskObject.GetComponentInChildren<ExpandBase>().outside) {
                    onChangeScene();
                    TaskManager.taskManager.nextTask();
                    return true;
				}
                return false;
            })),
            new Task ("Sweet, dette er en test. Trykk på menyknappen for å fortsette!", NONE, new System.Func<bool> (() => {
                return false;

            }))
        };

        spawnObject();
    }
}
