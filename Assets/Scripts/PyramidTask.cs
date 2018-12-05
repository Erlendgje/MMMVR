using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidTask : Tasks {

	// Use this for initialization
	void Start () {
		tasks = new List<Task> {
			new Task ("Vi har sett at volumet av en kube er l * b * h. Men hva er volumet til en pyramide? Fyll pyramider inn i kuben til den er full.", "Pyramid", new System.Func<bool> (() => {
				


				for (int i = 0; i < activeTaskObject.transform.childCount; i++) {
                    Debug.Log("Hey" + i, activeTaskObject);
                    if (!activeTaskObject.transform.GetChild(i).GetComponent<SnapToPosition>().getInTrigger()) {
						return false;
					}
				}
				return true;

			})),
            new Task("Bruk de fargede spakene til å lage en kube med volum på 100dm^3", "Volume", new System.Func<bool>(() => {
                if(activeTaskObject.transform.localScale.x * activeTaskObject.transform.localScale.y * activeTaskObject.transform.localScale.z == 0.1) {
                    return true;
                }
                return false;
            }))
        };
		spawnObject();
	}
}
