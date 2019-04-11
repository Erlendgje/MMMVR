using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ScreenBatteryController : MonoBehaviour
{
	
    public Animator animator;

	private Material batteryMat;
	private float currentBatteryValue = 0.0f;
	private float lastBatteryValue = 0.0f;
	private float batteryDifference = 0.0f;
	private float totalBatteryValue = 0.0f;
    private int framesUnchanged = 0;


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
		var material = other.transform.GetComponent<MeshRenderer> ().materials [1];
		if (material.name == "Unlit_BatteryDrain (Instance)") {
			batteryMat = material;
		}

	}

	private void OnTriggerStay(Collider other)
	{
	
		if (batteryMat.name == "Unlit_BatteryDrain (Instance)") 
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
		}
		if (totalBatteryValue >= 1.0f) {
			transform.GetComponent<OnTabletPickUp>().enabled = true;
			transform.GetComponent<TabletDialogueHandler>().enabled = true;
			transform.GetComponent<Interactable>().enabled = true;
			animator.gameObject.SetActive (false);
			transform.GetComponent<ScreenBatteryController>().enabled = false;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		animator.enabled = false;
	}
		
    
}
