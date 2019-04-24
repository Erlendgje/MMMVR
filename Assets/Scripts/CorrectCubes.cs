using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectCubes : MonoBehaviour
{
	[SerializeField] private MeshRenderer cable;
	[SerializeField] private MeshRenderer space;
	private Animator anim;

	// Start is called before the first frame update
	void Start()
    {
		anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }


	public void onCorrect() {
		anim.SetBool("correct", true);

		Array.Find(cable.materials, m => m.name.Equals("CableLight (Instance)")).EnableKeyword("_EMISSION");
		cable.GetComponent<CablePulse> ().enabled = true;

		Array.Find(space.materials, m => m.name.Equals("CableLight (Instance)")).EnableKeyword("_EMISSION");
		space.GetComponent<CablePulse> ().enabled = true;

		Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)")).EnableKeyword("_EMISSION");
	}

	public void onWrong() {
		anim.SetBool("correct", false);

		cable.GetComponent<CablePulse> ().enabled = false;
		Array.Find(cable.materials, m => m.name.Equals("CableLight (Instance)")).DisableKeyword("_EMISSION");

		space.GetComponent<CablePulse> ().enabled = false;
		Array.Find(space.materials, m => m.name.Equals("CableLight (Instance)")).DisableKeyword("_EMISSION");

		Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)")).DisableKeyword("_EMISSION");
	}
}
