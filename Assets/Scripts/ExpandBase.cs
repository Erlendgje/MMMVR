using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandBase : MonoBehaviour
{

	[SerializeField] private Transform xArrow1;
	[SerializeField] private Transform xArrow2;

	[SerializeField] private Transform zArrow1;
	[SerializeField] private Transform zArrow2;


    // Update is called once per frame
    void Update()
    {
		this.transform.localScale = new Vector3(xArrow1.position.x - xArrow2.position.x, 1, zArrow1.position.z - zArrow2.position.z);
		this.transform.position = new Vector3((xArrow1.position.x - xArrow2.position.x) / 2, 0.5f, (zArrow1.position.z - zArrow2.position.z) / 2);
    }
}
