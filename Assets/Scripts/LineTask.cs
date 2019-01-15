using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTask : Tasks {

	// Use this for initialization
	void Start () {
		tasks = new List<Task> {
			new Task("Nå skal vi se på lendgde, areal og volum. Dra i det røde håndtaket for å endre lengden på linjen.", "Area", new System.Func<bool>(() => activeTaskObject.transform.localScale.x != 0.1f)),

			new Task("Dra nå i håndtakene for å lage et areal på 1 kvadratmeter", none, new System.Func<bool>(() => {
                if(activeTaskObject.transform.localScale.x * activeTaskObject.transform.localScale.y == 1f) {
					return true;
				}
				return false;
			})),

			new Task("Bra! Se på kuben til høyre. Bruk de fargede spakene til å lage en kube med volum på 100 kubikkdesimeter", "Volume", new System.Func<bool>(() => {
				if(activeTaskObject.transform.localScale.x * activeTaskObject.transform.localScale.y * activeTaskObject.transform.localScale.z == 0.1f) {
					return true;
				}
				return false;
			})),

			new Task("Bra! Lag nå en kube på 1 kubikkmeter", none, new System.Func<bool>(() => {
				if(activeTaskObject.transform.localScale.x * activeTaskObject.transform.localScale.y * activeTaskObject.transform.localScale.z == 1f) {
					return true;
				}
				return false;
			})),

			new Task("En kubikkmeter inneholder 1000 kuber på 1 kubikkdesemeter", "Cubes", new System.Func<bool>(() => {
				return true;
			}))};

		spawnObject();
	}
}
