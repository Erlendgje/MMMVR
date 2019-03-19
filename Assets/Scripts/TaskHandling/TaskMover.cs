using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMover : MonoBehaviour
{
	[SerializeField] float moveDuration;
	[SerializeField] float moveUpwards;
    [SerializeField] bool dontActivateRigidBody;

    // Start is called before the first frame update
    void Start()
    {
		iTween.MoveBy(this.gameObject, iTween.Hash("y", moveUpwards, "islocal", true, "time", moveDuration));
        if (!dontActivateRigidBody)
        {
            StartCoroutine(setNotKinematic());
        }
        
	}


    private IEnumerator setNotKinematic()
    {
        yield return new WaitForSeconds(moveDuration);

        foreach(Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;
        }
    }
}
