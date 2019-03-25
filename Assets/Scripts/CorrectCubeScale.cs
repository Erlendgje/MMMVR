using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectCubeScale : MonoBehaviour
{

    private AudioSource sound;

    private void Start()
    {
        sound = this.GetComponent<AudioSource>();
    }

    public void onCorrect() {
		Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)")).EnableKeyword("_EMISSION");
		sound.PlayDelayed (0.2f);
	}

	public void onWrong() {
		Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)")).DisableKeyword("_EMISSION");
	}
}
