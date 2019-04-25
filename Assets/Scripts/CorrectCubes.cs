using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectCubes : MonoBehaviour
{
	[SerializeField] private MeshRenderer cable;
	[SerializeField] private MeshRenderer space;
    [SerializeField] private Color onCorrectColor;
    [SerializeField] private Color onWrongColor;

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

		Array.Find(cable.materials, m => m.name.Equals("CableLight (Instance)")).SetColor("_EmissionColor", onCorrectColor);
        cable.GetComponent<CablePulse> ().enabled = true;

		Array.Find(space.materials, m => m.name.Equals("CableLight (Instance)")).SetColor("_EmissionColor", onCorrectColor);
        space.GetComponent<CablePulse> ().enabled = true;

		Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)")).SetColor("_EmissionColor", onCorrectColor);
    }

	public void onWrong() {
		anim.SetBool("correct", false);

		cable.GetComponent<CablePulse> ().enabled = false;
		Array.Find(cable.materials, m => m.name.Equals("CableLight (Instance)")).SetColor("_EmissionColor", onWrongColor);

        space.GetComponent<CablePulse> ().enabled = false;
		Array.Find(space.materials, m => m.name.Equals("CableLight (Instance)")).SetColor("_EmissionColor", onWrongColor);

        Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)")).SetColor("_EmissionColor", onWrongColor);
    }
}
