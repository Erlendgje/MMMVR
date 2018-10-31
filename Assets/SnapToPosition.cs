using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPosition : MonoBehaviour {




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //GameObject parent = this.gameObject.transform.parent.gameObject;
        //print(gameObject.transform.position);
   
        //print("P1" + gameObject.transform.GetChild(0).transform.localPosition);
        //print("P2" + gameObject.transform.GetChild(1).transform.localPosition);
        //print("P3" + gameObject.transform.GetChild(2).transform.localPosition);

        //Vector3 pos1 = gameObject.transform.GetChild(0).transform.localPosition;
        //Vector3 pos2 = gameObject.transform.GetChild(1).transform.localPosition;
        //Vector3 pos3 = gameObject.transform.GetChild(2).transform.localPosition;



    }

    void OnTriggerStay(Collider other)
    {
        print("P1" + other.transform.localPosition);
        

        float rotX = other.transform.localRotation.eulerAngles.x;
        float rotY = other.transform.localRotation.eulerAngles.y;
        float rotZ = other.transform.localRotation.eulerAngles.z;

        float rotXstuff = rotX / 90;
        float rotXstuffRound = Mathf.Round(rotXstuff);

        float rotYstuff = rotY / 90;
        float rotYstuffRound = Mathf.Round(rotYstuff);

        float rotZstuff = rotZ / 90;
        float rotZstuffRound = Mathf.Round(rotZstuff);

        if (Mathf.Abs(other.transform.localPosition.x) <= 0.1 && Mathf.Abs(other.transform.localPosition.y) <= 0.1 && Mathf.Abs(other.transform.localPosition.z) <= 0.1)
        {
            if (Mathf.Abs(rotXstuff - rotXstuffRound) * 90 < 5 || Mathf.Abs(rotYstuff - rotYstuffRound) * 90 < 5 || Mathf.Abs(rotZstuff - rotZstuffRound) * 90 < 5)
            {
                other.transform.localPosition = new Vector3(0, 0, 0);
                other.transform.localRotation = Quaternion.Euler(rotXstuffRound *90, rotYstuffRound *90, rotZstuffRound *90);
            }
        }



    }
}
