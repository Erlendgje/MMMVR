using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBurstTrigger : MonoBehaviour
{

	[SerializeField] public GameObject particle1;
	[SerializeField] public List<GameObject> particles;

    public void PlayParticle(int index)
    {
		//activate particlesystem
		Debug.Log("Particle System" + index);
		//particle1.GetComponent<ParticleSystem>().Play();
		particles[index].GetComponent<ParticleSystem>().Play();
    }

}
