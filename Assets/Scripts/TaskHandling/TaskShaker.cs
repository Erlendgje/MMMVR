using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskShaker : MonoBehaviour
{

	[SerializeField] private float shakeAmount;
	[SerializeField] private float shakeDuration;

    // Start is called before the first frame update
    void Start()
    {
		iTween.ShakePosition(this.gameObject, new Vector3(1, 0, 1) * shakeAmount, shakeDuration);
	}
}
