using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectCubeScale : MonoBehaviour
{

    public AudioClip successSound;


    public void onCorrect() {
		Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)")).EnableKeyword("_EMISSION");
        SoundManager.instance.PlaySingle(successSound);
	}

	public void onWrong() {
		Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)")).DisableKeyword("_EMISSION");
	}
}
