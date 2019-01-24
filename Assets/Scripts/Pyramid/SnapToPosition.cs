using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPosition : MonoBehaviour {

    [SerializeField] GameObject errorText;
    public GameObject point;
	private Rigidbody rgdb;
    private bool isPickedUp = false;
	private bool inTrigger = false;
    public static List<GameObject> snappedObjects;
   

    private float distance = 0.1f;


	// Use this for initialization
	void Start () {
        rgdb = this.GetComponent<Rigidbody>();

        if (snappedObjects == null)
        {
            snappedObjects = new List<GameObject>();
        }

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
                    inTrigger = true;
                }
                else { inTrigger = false; }
            }
            else
            {
                inTrigger = false;
            }
        }
    }

    public void onPickUp() {
        Debug.Log(snappedObjects.Count);
		rgdb.constraints = RigidbodyConstraints.None;
        if (snappedObjects.Contains(this.gameObject))
        {
            snappedObjects.Remove(this.gameObject);
            errorText.SetActive(false);
        }
        isPickedUp = true;
	}

	public void onDetach() {
        isPickedUp = false;
		if(inTrigger) {
			rgdb.constraints = RigidbodyConstraints.FreezeAll;

            foreach(GameObject go in snappedObjects)
            {
                if(Vector3.Distance(go.GetComponent<SnapToPosition>().point.transform.position, point.transform.position) > distance)
                {
                    errorText.SetActive(true);
                }
            }
            snappedObjects.Add(this.gameObject);
        }
	}

	public bool getInTrigger() {
		return this.inTrigger;
	}

    public bool getIsPickedUp()
    {
        return this.isPickedUp;
    }

}
