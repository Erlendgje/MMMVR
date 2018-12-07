using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidTask : Tasks {

	// Use this for initialization
	void Start () {
		tasks = new List<Task> {
			new Task ("Hva er volumet til en pyramide? Plukk opp en av pyramidene", "Pyramid", new System.Func<bool> (() => {
				

				for (int i = 0; i < activeTaskObject.transform.childCount; i++) {
                    Debug.Log("Hey" + activeTaskObject.transform.GetChild(i).GetComponent<SnapToPosition>().getIsPickedUp(), activeTaskObject);
                    if (activeTaskObject.transform.GetChild(i).GetComponent<SnapToPosition>().getIsPickedUp()) {
						return true;
					}
				}
				return false;

			})),
            new Task ("Vi har sett at volumet av en kube er l * b * h. Fyll pyramider inn i kuben til den er full.", none, new System.Func<bool> (() => {


                for (int i = 0; i < activeTaskObject.transform.childCount; i++) {
                    Debug.Log("Hey" + i, activeTaskObject);
                    if (!activeTaskObject.transform.GetChild(i).GetComponent<SnapToPosition>().getInTrigger()) {
                        return false;
                    }
                }
                return true;

            })),
            new Task ("Så bra! Siden du fikk 3 pyramider inni kuben er formelen for en pyramide (l * b * h)/3.", none, new System.Func<bool> (() => {
                return true;
            }))
        };
		spawnObject();
	}
}
