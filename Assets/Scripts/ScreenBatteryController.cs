using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ScreenBatteryController : MonoBehaviour
{

	[SerializeField] GameObject startTeleportArea;
	[SerializeField] GameObject teleportArea;
	[SerializeField] private AudioClip blinkSound;
	[SerializeField] private AudioClip messageSound;

	public Animator animator;

	private AudioSource tabletAudio;
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

		animator.Play ("ScreenBatteryBlink", 0, 0.0f);
		tabletAudio = GetComponent<AudioSource>();
		tabletAudio.clip = blinkSound;
		StartCoroutine ( Beep());
		
	}

	private IEnumerator Beep()
	{
		while (!isCharged) {
			tabletAudio.Play();
			yield return new WaitForSeconds(1.0f);
		}

	}


	private void OnTriggerEnter(Collider other)
	{
        if(other.transform.GetComponent<MeshRenderer>() && !isCharged) { 
			if (other.transform.GetComponent<MeshRenderer>().materials.Length == 2) { 
		        var material = other.transform.GetComponent<MeshRenderer> ().materials [1];
		        if (material.name == "Unlit_BatteryDrain (Instance)") {
					animator.speed = 0.0f;
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

			animator.Play ("ScreenBatteryFill", 0, totalBatteryValue);
            if (totalBatteryValue >= 1.0f)
            {
                transform.GetComponent<OnTabletPickUp>().enabled = true;
                transform.GetComponent<TabletDialogueHandler>().enabled = true;
				GameManager.gameManager.unlockNextTask();
				foreach(GameObject go in GameObject.FindGameObjectsWithTag("GameController"))
				{
					if(go.GetComponent<Hand>() != null)
					{
						go.GetComponent<Hand>().hoverLayerMask = ~0;
					}
				}

				startTeleportArea.SetActive(false);
				teleportArea.SetActive(true);
				tabletAudio.clip = messageSound;
				animator.gameObject.SetActive(false);
                isCharged = true;
				
            }
        }
		
	}

	private void OnTriggerExit(Collider other)
	{

		if (other.transform.GetComponent<MeshRenderer> () && !isCharged) { 
			if (other.transform.GetComponent<MeshRenderer> ().materials.Length == 2) { 
				if (other.transform.GetComponent<MeshRenderer> ().materials [1].name == "Unlit_BatteryDrain (Instance)") {
					animator.speed = 1.0f;
					animator.Play ("ScreenBatteryBlink", 0, 0.0f);
				}
			}
		}
	}
		
    
}
