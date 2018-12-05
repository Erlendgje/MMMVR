using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidTask : Tasks {

	// Use this for initialization
	void Start () {
		tasks = new List<Task> {
			new Task ("Vi har sett at volumet av en kube er l * b * h. Men hva er volumet til en pyramide? Fyll pyramider inn i kuben til den er full.", "Pyramid", new System.Func<bool> (() => {
				


				for (int i = 0; i < activeTaskObject.transform.GetChildCount (); i++) {
					if (!activeTaskObject.transform.GetChild(i).GetComponent<SnapToPosition>().getInTrigger()) {
						return false;
					}
				}
				return true;

			}))
		};
		spawnObject();
	}
}
