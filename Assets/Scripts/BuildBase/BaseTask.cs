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
            new Task ("Vi må bygge en base. Først trenger vi et drivhus for å dyrke poteter. Sett av et område på 200m" + "\u00B2", "Greenhouse", new System.Func<bool> (() => {
                if(activeTaskObject.GetComponent<ExpandBase>().inside && !activeTaskObject.GetComponent<ExpandBase>().outside) {
                    if (activeTaskObject.transform.localScale.x * activeTaskObject.transform.localScale.z == 200)
                    {
                        return true;
                    }
                }
                return false;
            })),
            new Task ("Vi trenger vann til potetene. Sett ut en vanntank som rommer 100 liter", "WaterTank", new System.Func<bool> (() => {
                if(activeTaskObject.GetComponent<ExpandBase>().inside && !activeTaskObject.GetComponent<ExpandBase>().outside) {
                    if (activeTaskObject.transform.localScale.x * activeTaskObject.transform.localScale.y * activeTaskObject.transform.localScale.z == 100)
                    {
                        return true;
                    }
                }
                return false;
            })),
            new Task ("Vi må nå lage en kompost-tank på 50 kubikkmeter", "Compost", new System.Func<bool> (() => {
				if(activeTaskObject.GetComponent<ExpandBase>().inside && !activeTaskObject.GetComponent<ExpandBase>().outside) {
                    
                    if (activeTaskObject.transform.localScale.x * activeTaskObject.transform.localScale.y * activeTaskObject.transform.localScale.z == 50)
                    {
                        onChangeScene();
                        TaskManager.taskManager.nextTask();
                        return true;
                    }
                }
                return false;
            })),
            new Task ("Bra, trykk på menyknappen for å fortsette!", NONE, new System.Func<bool> (() => {
                return false;

            }))
        };

        spawnObject();
    }
}
