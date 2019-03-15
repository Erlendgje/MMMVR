using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Pulse : MonoBehaviour
{

	private Bloom bloom;
	[SerializeField] private float pulseSpeed;
	private bool active;
	[SerializeField] private float from, to;
	[SerializeField] float intensity;
	[SerializeField] Color color;

    // Start is called before the first frame update
    void Start()
    {
		PostProcessProfile ppp = new PostProcessProfile();
		ppp.AddSettings<Bloom>();
		ppp.TryGetSettings<Bloom>(out bloom);
		bloom.enabled.value = true;
		bloom.intensity.overrideState = true;
		bloom.intensity.value = intensity;
		bloom.color.overrideState = true;
		bloom.color.value = color;
		GetComponent<PostProcessVolume>().profile = ppp;// .TryGetSettings(out bloom);
		StartCoroutine(pulse());
    }


	private IEnumerator pulse() {

		yield return new WaitForSeconds(Random.value);

		while(true) {
			while(bloom.intensity.value < to) {
				bloom.intensity.value = bloom.intensity.value + pulseSpeed * Time.deltaTime;
				yield return null;
			}
			while(bloom.intensity.value > from) {
				bloom.intensity.value = bloom.intensity.value - pulseSpeed * Time.deltaTime;
				yield return null;
			}

			yield return null;
		}
	}
}
