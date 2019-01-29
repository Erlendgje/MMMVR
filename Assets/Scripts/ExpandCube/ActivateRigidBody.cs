using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRigidBody : MonoBehaviour
{

    private bool kinematic;

    public void onPickUp()
    {
        kinematic = this.GetComponent<Rigidbody>().isKinematic;
        this.GetComponent<Rigidbody>().isKinematic = false;
    }


    public void onRelease()
    {
        this.GetComponent<Rigidbody>().isKinematic = kinematic;
    }
}
