using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPosition : MonoBehaviour {

	private Rigidbody rgdb;
    private bool isPickedUp = false;
    private bool inTrgger = false;


	// Use this for initialization
	void Start () {
		rgdb = this.GetComponent<Rigidbody>();
	}

    void OnTriggerStay(Collider other)
    {
        if (isPickedUp)
        {
            float rotX = transform.localRotation.eulerAngles.x;
            float rotY = transform.localRotation.eulerAngles.y;
            float rotZ = transform.localRotation.eulerAngles.z;

            float rotXstuff = rotX / 90;
            float rotXstuffRound = Mathf.Round(rotXstuff);

            float rotYstuff = rotY / 90;
            float rotYstuffRound = Mathf.Round(rotYstuff);

            float rotZstuff = rotZ / 90;
            float rotZstuffRound = Mathf.Round(rotZstuff);

            if (Mathf.Abs(transform.localPosition.x) <= 0.1 && Mathf.Abs(transform.localPosition.y) <= 0.1 && Mathf.Abs(transform.localPosition.z) <= 0.1)
            {
                if (Mathf.Abs(rotXstuff - rotXstuffRound) * 90 < 5 || Mathf.Abs(rotYstuff - rotYstuffRound) * 90 < 5 || Mathf.Abs(rotZstuff - rotZstuffRound) * 90 < 5)
                {
                    transform.localPosition = new Vector3(0, 0, 0);
                    transform.localRotation = Quaternion.Euler(rotXstuffRound * 90, rotYstuffRound * 90, rotZstuffRound * 90);
                    inTrgger = true;
                }
                else { inTrgger = false; }
            }
            else
            {
                inTrgger = false;
            }
        }
    }

    public void onPickUp() {
		rgdb.constraints = RigidbodyConstraints.None;
        isPickedUp = true;
	}

	public void onDetach() {
        isPickedUp = false;
		if(inTrgger) {
			rgdb.constraints = RigidbodyConstraints.FreezeAll;
		}
	}
}
