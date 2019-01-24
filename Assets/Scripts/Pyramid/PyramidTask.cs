using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidTask : Tasks {
    public override void onChangeScene()
    {
    }

    // Use this for initialization
    void Start() {
		tasks = new List<Task> {
			new Task ("Hva er volumet til en pyramide? Plukk opp en av pyramidene", "Pyramid", new System.Func<bool> (() => {


				for (int i = 0; i < activeTaskObject.transform.childCount; i++) {
					if (activeTaskObject.transform.GetChild(i).GetComponent<SnapToPosition>().getIsPickedUp()) {
						return true;
					}
				}
				return false;

			})),
			new Task ("Vi har sett at volumet av en kube er <b>lengde * bredde * høyde</b>. Hvor mange pyramider får du plass til i en kube?", NONE, new System.Func<bool> (() => {

				int count = 0;
				for (int i = 0; i < activeTaskObject.transform.childCount; i++) {
					if (activeTaskObject.transform.GetChild(i).GetComponent<SnapToPosition>().getInTrigger()) {
						count++;
					}
				}
				if(count >= 3) {
                    TaskManager.taskManager.mathWorldDone = true;
                    return true;
				}
				return false;

			})),
			new Task ("Så bra, du får plass til tre pyramider inni kuben. Trykk på meny knappen for å fortsette", NONE, new System.Func<bool> (() => {
				return false;
			}))
		};
		spawnObject();
	}
}
