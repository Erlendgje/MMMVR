using System;
using UnityEngine;

public class TaskCorrect : MonoBehaviour
{

	[SerializeField] private AudioClip successSound;
	[SerializeField] private Color onRegisterColor;
	[SerializeField] private Color onCorrectColor;
	[SerializeField] private bool keepCurrentColor;
	[SerializeField] private MeshRenderer cable;
	private Material material;

    private void Start()
    {
		material = Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)"));
		if(keepCurrentColor) {
			
			onCorrectColor = material.GetColor("_EmissionColor");

		}
    }

    public void onCorrect() {
		if (cable != null) {
			this.GetComponent<CablePulse> ().enabled = false;
			cable.GetComponent<CablePulse> ().enabled = false;
			Array.Find(cable.materials, m => m.name.Equals("CableLight (Instance)")).SetColor("_EmissionColor", onCorrectColor);
		}
		material.EnableKeyword("_EMISSION");
		material.SetColor("_EmissionColor", onCorrectColor);

		SoundManager.instance.PlaySingleDelayed(successSound, 0.2f);
	}

	public void onWrong() {
		material.DisableKeyword("_EMISSION");
	}

	public void onRegisterAnswer() {
		Debug.Log("KOMMER HIT");
		material.EnableKeyword("_EMISSION");
		material.SetColor("_EmissionColor", onRegisterColor);
	}
}
