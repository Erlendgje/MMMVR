using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTask : Tasks {
    public override void onChangeScene()
    {
		TaskManager.taskManager.activeTask = task;
    }

    // Use this for initialization
    void Start () {
		tasks = new List<Task> {
			new Task("Nå skal vi se på lengde, areal og volum. Dra i det røde håndtaket for å endre lengden på linjen.", "Area", new System.Func<bool>(() => activeTaskObject.transform.localScale.x != 0.1f)),

			new Task("Dra nå i håndtakene for å lage et areal på 1 kvadratmeter", NONE, new System.Func<bool>(() => {
                if(activeTaskObject.transform.localScale.x * activeTaskObject.transform.localScale.y == 1f) {
                    text.GetComponentInParent<MoveCanvas>().moveText();
					return true;
				}
				return false;
			})),

			new Task("Bra! Bruk de fargede spakene til å lage en kube med volum på 100 kubikkdesimeter", "Volume", new System.Func<bool>(() => {
				if(activeTaskObject.transform.localScale.x * activeTaskObject.transform.localScale.y * activeTaskObject.transform.localScale.z == 0.1f) {
					return true;
				}
				return false;
			})),

			new Task("Bra! Lag nå en kube på 1 kubikkmeter", NONE, new System.Func<bool>(() => {
				if(activeTaskObject.transform.localScale.x * activeTaskObject.transform.localScale.y * activeTaskObject.transform.localScale.z == 1f) {
                    text.GetComponentInParent<MoveCanvas>().moveText();
                    return true;
				}
				return false;
			})),

			new Task("En kubikkmeter inneholder 1000 kuber på 1 kubikkdesemeter. Hver kube kan tas ut av kuben. Trykk på den rød knappen på bordet for å fortsette!", "1000Cubes", new System.Func<bool>(() => {
                if(activeTaskObject.GetComponentsInChildren<Rigidbody>() != null)
                {
                    return true;
                }
                return false;
			})),
            new Task("En kubikkmeter inneholder 1000 kuber på 1 kubikkdesemeter. Hver kube kan tas ut av kuben. Prøv å trykk på knappen igjen.", NONE, new System.Func<bool>(() => {
                if (!activeTaskObject.GetComponentInChildren<Rigidbody>().isKinematic)
                {
                    TaskManager.taskManager.mathWorldDone = true;
                    return true;
                }
                return false;
            })),
            new Task("Trykk på menyknappen for å fortsette!", NONE, new System.Func<bool>(() => {
				return false;
			}))};

		loadTask(TaskManager.taskManager.activeTask);
	}
}
