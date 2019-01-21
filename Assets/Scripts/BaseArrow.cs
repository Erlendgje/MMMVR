using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BaseArrow : MonoBehaviour
{
	private static bool mathWorldActivated = false;
	private bool arrowPress = false;
	[SerializeField] Material hoverMaterial;
	[SerializeField] Material standbyMaterial;
	[SerializeField] Material clickedMaterial;
	private GameObject clickedObject;


	// Start is called before the first frame update
	void Start() {

	}

	public SteamVR_Input_Sources handType;
	public SteamVR_Action_Boolean changeAction;

	public bool getArrowDown() {
		return changeAction.GetLastStateDown(handType);
	}

	public bool getArrowUp() {
		return changeAction.GetLastStateUp(handType);
	}

	// Update is called once per frame
	void Update() {
		if(getArrowDown()) {
			arrowPress = true;
			RaycastHit raycastHit;
			if(Physics.Raycast(transform.position, transform.forward, out raycastHit)) {
				if(raycastHit.collider.gameObject.CompareTag("Arrow")) {
					clickedObject = raycastHit.collider.gameObject;
					clickedObject.GetComponent<MeshRenderer>().material = clickedMaterial;
				}
			}
		}

		if(getArrowUp()) {
			arrowPress = false;
			if(clickedObject != null) {
				clickedObject.GetComponent<MeshRenderer>().material = standbyMaterial;
				clickedObject = null;
			}
		}

		if(!arrowPress) {
			RaycastHit raycastHit;
			if(Physics.Raycast(transform.position, transform.forward, out raycastHit)) {
				if(raycastHit.collider.gameObject.CompareTag("Arrow")) {
					raycastHit.collider.gameObject.GetComponent<MeshRenderer>().material = hoverMaterial;
				}
			}
		}
		else {
			RaycastHit raycastHit;
			if(Physics.Raycast(transform.position, transform.forward, out raycastHit)) {
				if(clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.X) {
					clickedObject.transform.position = new Vector3(raycastHit.point.x, clickedObject.transform.position.y, clickedObject.transform.position.z);
				}
				else if(clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Y) {
					clickedObject.transform.position = new Vector3(clickedObject.transform.position.x, raycastHit.point.y, clickedObject.transform.position.z);
				}
				else if(clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Z) {
					clickedObject.transform.position = new Vector3(clickedObject.transform.position.y, clickedObject.transform.position.y, raycastHit.point.z);
				}
			}
		}
	}
}
