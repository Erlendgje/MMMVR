using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTask : MonoBehaviour
{
	[SerializeField] private List<GameObject> taskObjects;

	// Start is called before the first frame update
	void Start() {
		Instantiate(taskObjects[TaskManager.activeTask], this.transform);
	}
}
