using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesTask : Tasks {

	// Use this for initialization
	void Start() {
		tasks = new List<Task> {
			new Task ("Potetene trenger vann. Ta formen som inneholder 10 liter vann og putt inn i vanningsskapet", "PotatoFarm", new System.Func<bool> (() => {

				if (activeTaskObject.transform.GetChild(0).GetComponent<WateringLogic>().isCorrectContainer()) {
					return true;	
				}
				return false;

			}))
		};
		spawnObject();
	}
}

