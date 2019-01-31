using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandBase : MonoBehaviour
{
	[SerializeField] private Transform xArrow1;
	[SerializeField] private Transform xArrow2;

    [SerializeField] private Transform yArrow;

	[SerializeField] private Transform zArrow1;
	[SerializeField] private Transform zArrow2;

    [SerializeField] private TextMesh x1;
    [SerializeField] private TextMesh x2;

    [SerializeField] private TextMesh y;

    [SerializeField] private TextMesh z1;
    [SerializeField] private TextMesh z2;

    [SerializeField] private Material outsideMaterial;
    [SerializeField] private Material insideMaterial;

	public bool inside, outside, overlap;
    public bool setColor = true;

    // Update is called once per frame
    void Update()
    {
		this.transform.localScale = new Vector3(xArrow1.localPosition.x - xArrow2.localPosition.x, yArrow.position.y, zArrow1.localPosition.z - zArrow2.localPosition.z);
        Vector3 position = new Vector3((xArrow1.localPosition.x - xArrow2.localPosition.x) / 2 + xArrow2.localPosition.x, yArrow.position.y / 2, (zArrow1.localPosition.z - zArrow2.localPosition.z) / 2 + zArrow2.localPosition.z);

        this.transform.localPosition = position;


        xArrow1.transform.position = new Vector3(xArrow1.transform.position.x, xArrow1.transform.position.y, this.transform.position.z);
        xArrow2.transform.position = new Vector3(xArrow2.transform.position.x, xArrow2.transform.position.y, this.transform.position.z);
        yArrow.transform.position = new Vector3(this.transform.position.x, yArrow.transform.position.y, this.transform.position.z);
        zArrow1.transform.position = new Vector3(this.transform.position.x, zArrow1.transform.position.y, zArrow1.transform.position.z);
        zArrow2.transform.position = new Vector3(this.transform.position.x, zArrow2.transform.position.y, zArrow2.transform.position.z);

        z1.text = Mathf.RoundToInt(this.transform.localScale.x) + "m";
        z2.text = Mathf.RoundToInt(this.transform.localScale.x) + "m";

        y.text = Mathf.RoundToInt(this.transform.localScale.y) + "m";

        x1.text = Mathf.RoundToInt(this.transform.localScale.z) + "m";
        x2.text = Mathf.RoundToInt(this.transform.localScale.z) + "m";


        if(setColor)
        {
            if(outside || !inside || overlap)
            {
                GetComponent<MeshRenderer>().material = outsideMaterial;
            }
            else if(!outside && inside && !overlap)
            {
                GetComponent<MeshRenderer>().material = insideMaterial;
            }
        }
    }

	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Inside")) {
			inside = true;
		}
		else if(other.CompareTag("Outside")) {
			outside = true;
        }
        else if (other.CompareTag("Base"))
        {
            overlap = true;
        }
	}

	private void OnTriggerStay(Collider other) {
		if(other.CompareTag("Inside")) {
			inside = true;
		}
		else if(other.CompareTag("Outside")) {
			outside = true;
        }
        else if (other.CompareTag("Base"))
        {
            overlap = true;
        }
    }

	private void OnTriggerExit(Collider other) {
		if(other.CompareTag("Inside")) {
			inside = false;
		}
		else if(other.CompareTag("Outside")) {
			outside = false;
        }
        else if (other.CompareTag("Base"))
        {
            overlap = false;
        }
    }
}
