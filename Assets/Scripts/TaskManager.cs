using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

	public static int activeTask = 0;


	public void nextTask() {
		activeTask++;
	}
    
}
