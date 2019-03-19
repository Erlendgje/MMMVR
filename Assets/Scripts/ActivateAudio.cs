using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAudio : MonoBehaviour
{

	private AudioSource audio; 

    // Start is called before the first frame update
    void Start()
    {
		audio = this.GetComponent<AudioSource>();
		StartCoroutine(activateAudioSource());
    }

	private IEnumerator activateAudioSource() {
		yield return new WaitForSeconds(Random.value);
		audio.PlayDelayed(Random.value);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
