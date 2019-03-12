using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskStart : MonoBehaviour
{
	[SerializeField] float moveDuration;
	[SerializeField] Vector3 moveTo;

    // Start is called before the first frame update
    void Start()
    {
		iTween.MoveTo(this.gameObject, iTween.Hash("position", moveTo, "islocal", true, "time", moveDuration));
	}
}
