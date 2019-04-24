using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CablePulse : MonoBehaviour
{

	private Bloom bloom;
    private Material cableLight;
	[SerializeField] private float pulseSpeed;
	private bool active;
	[SerializeField] private float from, to;
	[SerializeField] float intensity;
	[SerializeField] Color color;

    // Start is called before the first frame update
    void Start()
    {
		cableLight = Array.Find(this.GetComponent<MeshRenderer>().materials, m => m.name.Equals("CableLight (Instance)"));
		Debug.Log (cableLight.name);
		StartCoroutine(pulse());
    }


	private IEnumerator pulse() {
        
        while (true) {
			float emission = from + Mathf.PingPong(Time.time * pulseSpeed, to);
            cableLight.SetColor("_EmissionColor", color * Mathf.LinearToGammaSpace(emission));
			yield return null;
		}
	}
}
