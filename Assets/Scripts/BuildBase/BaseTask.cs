using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BaseTask : Tasks
{
    public override void onChangeScene()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<BaseArrow>().enabled = !GameObject.FindGameObjectWithTag("GameController").GetComponent<BaseArrow>().enabled;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<LineRenderer>().enabled = !GameObject.FindGameObjectWithTag("GameController").GetComponent<LineRenderer>().enabled;
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
                        return true;
                    }
                }
                return false;
            })),
            new Task ("Du kan fortsette å endre på byggningene hvis du vil, trykk på den rød knappen når du er ferdig.", "Button", new System.Func<bool> (() => {
                if(activeTaskObject.GetComponent<HoverButton>().engaged) {
                    onChangeScene();
                    TaskManager.taskManager.nextTask();
                    return true;
                }
                return false;
            })),
            new Task ("Trykk på menyknappen for å fortsette!", NONE, new System.Func<bool> (() => {
                return false;

            }))
        };

        spawnObject();
    }
}
