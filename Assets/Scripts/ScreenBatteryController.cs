using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBatteryController : MonoBehaviour
{
	
    public Animator animator;

	private Material batteryMat;
	private float currentBatteryValue = 0.0f;
	private float lastBatteryValue = 0.0f;
	private float batteryDifference = 0.0f;
	private float totalBatteryValue = 0.0f;
    private int framesUnchanged = 0;
    private bool isCharged = false;


    void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        animator.speed = 0.0f;

    }


	private void OnTriggerEnter(Collider other)
	{
        if(other.transform.GetComponent<MeshRenderer>() && !isCharged) { 
            if (other.transform.GetComponent<MeshRenderer>().materials[1]) { 
		        var material = other.transform.GetComponent<MeshRenderer> ().materials [1];
		        if (material.name == "Unlit_BatteryDrain (Instance)") {
			        batteryMat = material;
		        }
            }
        }

    }

	private void OnTriggerStay(Collider other)
	{
	
		if (batteryMat != null && batteryMat.name == "Unlit_BatteryDrain (Instance)" && !isCharged) 
		{
			currentBatteryValue = Mathf.Abs ((batteryMat.GetFloat ("_CurrentY") - 0.04f)) / 8 * 100; //Time.deltaTime * 0.2f;
			if (currentBatteryValue > 0) {
				batteryDifference = currentBatteryValue - lastBatteryValue; 
				lastBatteryValue = currentBatteryValue;
			}else {
				lastBatteryValue = 0.0f;
				batteryDifference = 0.0f;
			}

			totalBatteryValue += batteryDifference;

			animator.enabled = true;
			animator.Play (0, 0, totalBatteryValue);
            if (totalBatteryValue >= 1.0f)
            {
                transform.GetComponent<OnTabletPickUp>().enabled = true;
                transform.GetComponent<TabletDialogueHandler>().enabled = true;
                animator.gameObject.SetActive(false);
                isCharged = true;
                
            }
        }
		
	}

	private void OnTriggerExit(Collider other)
	{
		animator.enabled = false;
	}
		
    
}
