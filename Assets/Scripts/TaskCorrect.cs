using System;
using UnityEngine;

public class TaskCorrect : MonoBehaviour
{

	[SerializeField] private AudioClip successSound;
	[SerializeField] private Color onRegisterColor;
	[SerializeField] private Color onCorrectColor;
	[SerializeField] private bool keepCurrentColor;
	private Material material;

    private void Start()
    {
		if(keepCurrentColor) {
			material = Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)"));
			onCorrectColor = material.GetColor("_EmissionColor");
		}
    }

    public void onCorrect() {
		material.EnableKeyword("_EMISSION");
		material.SetColor("_EmissionColor", onCorrectColor);
		SoundManager.instance.PlaySingleDelayed(successSound, 0.2f);
	}

	public void onWrong() {
		material.DisableKeyword("_EMISSION");
	}

	public void onRegisterAnswer() {
		material.EnableKeyword("_EMISSION");
		material.SetColor("_EmissionColor", onRegisterColor);
	}
}
