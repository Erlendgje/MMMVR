using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Pulse : MonoBehaviour
{

	private Bloom bloom;
    private Material answerCubeScreen;
	[SerializeField] private float pulseSpeed;
	private bool active;
	[SerializeField] private float from, to;
	[SerializeField] float intensity;
	[SerializeField] Color color;

    // Start is called before the first frame update
    void Start()
    {
        answerCubeScreen = GetComponent<MeshRenderer>().material;
		StartCoroutine(pulse());
    }


	private IEnumerator pulse() {

		yield return new WaitForSeconds(Random.value);
        
        while (true) {
            float emission = 1.0f + Mathf.PingPong(Time.time,2.0f);
            answerCubeScreen.SetColor("_EmissionColor", color * Mathf.LinearToGammaSpace(emission));

			yield return null;
		}
	}
}
