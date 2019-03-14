using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBurstTrigger : MonoBehaviour
{

	[SerializeField] public List<GameObject> particles;
 
    public void PlayParticle(int index)
    {
		//activate particlesystem
		particles[index].GetComponent<ParticleSystem>().Play();
		transform.GetComponent<AudioSource>().Play ();
    }

}
