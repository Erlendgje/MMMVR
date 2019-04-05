using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStory : MonoBehaviour
{
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag.CompareTo("Player") == 0) {
			GameManager.gameManager.GetDialogueHandler().playStory();
			Destroy(this.gameObject);
		}
	}
}
