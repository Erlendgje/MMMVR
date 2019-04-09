using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBatteryController : MonoBehaviour
{
	
    public Animator animator;

	private Material batteryMat;
	private float currentBatteryValue = 0.0f;
    private int framesUnchanged = 0;


    //-------------------------------------------------
    void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        animator.speed = 0.0f;

    }


	void onTriggerEnter(Collider other) 
	{
		
		batteryMat = other.transform.GetComponent<MeshRenderer> ().materials [1];

	}

	void onTriggerStay(Collider other) {
	
		if (batteryMat.name == "Unlit_BatteryDrain (Instance)") 
		{
			currentBatteryValue += (0.4f + batteryMat.GetFloat ("_CurrentY")) - currentBatteryValue;
			animator.enabled = true;
			animator.Play (0, 0, currentBatteryValue);
		}
	}

	void onTriggerExit(Collider other) {
		if (batteryMat.name == "Unlit_BatteryDrain (Instance)") 
		{
			animator.enabled = false;
		}
	}

	//onTriggerEscape
    
}
