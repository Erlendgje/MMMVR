﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesTask : Tasks {
    public override void onChangeScene()
    {
    }

    // Use this for initialization
    void Start() {
		tasks = new List<Task> {
			new Task ("Potetene trenger vann. Ta tankene som tilsammen inneholder 35 liter vann og putt dem inn i vanningsskapet.", "PotatoFarm", new System.Func<bool> (() => {

				return true;	

			})),
            new Task ("Så bra! Nå fikk potetene perfekt mengde vann", NONE, new System.Func<bool> (() => {

                return false;

            }))
        };
		loadTask(0);
	}
}
