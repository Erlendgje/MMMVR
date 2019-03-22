using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectCubes : MonoBehaviour
{
	[SerializeField] private MeshRenderer cable;
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
		anim.enabled = true;
		Array.Find(cable.materials, m => m.name.Equals("CableLight (Instance)")).EnableKeyword("_EMISSION");
		Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)")).EnableKeyword("_EMISSION");
	}

	public void onWrong() {
		Array.Find(cable.materials, m => m.name.Equals("CableLight (Instance)")).DisableKeyword("_EMISSION");
		Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)")).DisableKeyword("_EMISSION");
	}
}
