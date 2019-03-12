using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMover : MonoBehaviour
{
	[SerializeField] float moveDuration;
	[SerializeField] float moveUpwards;

    // Start is called before the first frame update
    void Start()
    {
		iTween.MoveBy(this.gameObject, iTween.Hash("y", moveUpwards, "islocal", true, "time", moveDuration));
	}
}
