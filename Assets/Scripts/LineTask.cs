using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTask : Tasks {

	// Use this for initialization
	void Start () {
		tasks = new List<Task> {
			new Task("Dra i det røde håndtaket for å endre lengden på linjen til 1 meter.", "Area", new System.Func<bool>(() => activeTaskObject.transform.localScale.x == 1)),

			new Task("Dra i det blå håndtaket for å endre høyden på boksen til 1 meter.", none, new System.Func<bool>(() => {
                Debug.Log("Hey ehye hyeh yhey hyehy hy");
                if(activeTaskObject.transform.localScale.x == 1) {
					if(activeTaskObject.transform.localScale.y == 1) {
						return true;
					}
				}
				return false;
			})),

			new Task("Bruk de fargede spakene til å lage en kube med volum på 100dm^3", "Volume", new System.Func<bool>(() => {
				if(activeTaskObject.transform.localScale.x * activeTaskObject.transform.localScale.y * activeTaskObject.transform.localScale.z == 0.1) {
					return true;
				}
				return false;
			})),

			new Task("Bra! Lag nå en kube på 1000dm^3", none, new System.Func<bool>(() => {
				if(activeTaskObject.transform.localScale.x * activeTaskObject.transform.localScale.y * activeTaskObject.transform.localScale.z == 1) {
					return true;
				}
				return false;
			}))};

		spawnObject();
	}
}
