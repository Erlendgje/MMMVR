using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnapToPosition : MonoBehaviour {

	private static bool taskDone = false;
	private static UnityEvent onCorrectStatic;
	private static UnityEvent onWrongStatic;

	[SerializeField] private UnityEvent onCorrect;
	[SerializeField] private UnityEvent onWrong;

    [SerializeField] GameObject errorText;
	[SerializeField] GameObject ghostPyramid;
	public GameObject point;
	private Rigidbody rgdb;
    private bool isPickedUp = false;
	private bool inTrigger = false;
    public static List<GameObject> snappedObjects;
    public AudioClip snapSound;
    public AudioClip failSound;
   
    private float distance = 0.1f;


	// Use this for initialization
	void Start () {

		if(onCorrectStatic != null && onCorrect != null) {
			onCorrectStatic = onCorrect;
			onWrongStatic = onWrong;
		}

        rgdb = this.GetComponent<Rigidbody>();
        snappedObjects = new List<GameObject>();
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
		rgdb.constraints = RigidbodyConstraints.None;
        if (snappedObjects.Contains(this.gameObject))
        {
            snappedObjects.Remove(this.gameObject);
            errorText.SetActive(false);
        }
        isPickedUp = true;

		if(snappedObjects.Count == 0) {
			ghostPyramid.SetActive(true);
			ghostPyramid.GetComponent<MaterialBlinking>().startBlinking();
		}
	}

	public void onDetach() {
        isPickedUp = false;
		ghostPyramid.SetActive(false);
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
            
            if (!errorText.activeInHierarchy) {
                SoundManager.instance.PlaySingle(snapSound);
                if  (snappedObjects.Count == 3 && !taskDone) {
					//TASK DONE!!!
					taskDone = true;
					onCorrectStatic.Invoke();
				    GameManager.gameManager.unlockNextTask();
                
			    }
            } 
            else{
                SoundManager.instance.PlaySingle(failSound);
				if(!taskDone) {
					onWrongStatic.Invoke();
				}
            }
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
