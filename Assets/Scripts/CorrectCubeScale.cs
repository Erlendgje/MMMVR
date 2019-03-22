using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectCubeScale : MonoBehaviour
{

    private AudioSource[] sounds;

    private void Start()
    {
        sounds = this.GetComponents<AudioSource>();
    }

    public void onCorrect() {
		Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)")).EnableKeyword("_EMISSION");
		sounds[0].PlayDelayed (0.2f);
	}

	public void onWrong() {
		Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)")).DisableKeyword("_EMISSION");
        sounds[1].PlayDelayed(0.2f);
	}
}
