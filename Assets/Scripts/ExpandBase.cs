using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandBase : MonoBehaviour
{

	[SerializeField] private Transform xArrow1;
	[SerializeField] private Transform xArrow2;

	[SerializeField] private Transform zArrow1;
	[SerializeField] private Transform zArrow2;

    [SerializeField] private TextMesh x1;
    [SerializeField] private TextMesh x2;

    [SerializeField] private TextMesh y1;
    [SerializeField] private TextMesh y2;


    // Update is called once per frame
    void Update()
    {
		this.transform.localScale = new Vector3(xArrow1.localPosition.x - xArrow2.localPosition.x, 1, zArrow1.localPosition.z - zArrow2.localPosition.z);
		this.transform.localPosition = new Vector3((xArrow1.localPosition.x - xArrow2.localPosition.x) / 2 + xArrow2.localPosition.x, 0.5f, (zArrow1.localPosition.z - zArrow2.localPosition.z) / 2 + zArrow2.localPosition.z);

        xArrow1.transform.position = new Vector3(xArrow1.transform.position.x, this.transform.position.y, this.transform.position.z);
        xArrow2.transform.position = new Vector3(xArrow2.transform.position.x, this.transform.position.y, this.transform.position.z);
        zArrow1.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, zArrow1.transform.position.z);
        zArrow2.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, zArrow2.transform.position.z);

        y1.text = (int)this.transform.localScale.x + "m";
        y2.text = (int)this.transform.localScale.x + "m";

        x1.text = (int)this.transform.localScale.z + "m";
        x2.text = (int)this.transform.localScale.z + "m";
    }
}
