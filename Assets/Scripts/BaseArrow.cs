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
    private LineRenderer lr;


	// Start is called before the first frame update
	void Start() {
        lr = GetComponent<LineRenderer>();
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
			RaycastHit raycastHit;
			if(Physics.Raycast(transform.position, transform.forward, out raycastHit)) {
				if(raycastHit.collider.gameObject.CompareTag("Arrow")) {
                    arrowPress = true;
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
            Ray laser = new Ray();
            laser.origin = this.transform.position;
            laser.direction = this.transform.forward;


            lr.enabled = true;
            lr.SetPosition(0, transform.position);

			RaycastHit raycastHit;
			if(Physics.Raycast(laser, out raycastHit)) {
				if(raycastHit.collider.gameObject.CompareTag("Arrow")) {
                    if(clickedObject != null && raycastHit.collider.gameObject != clickedObject)
                    {
                        clickedObject.GetComponent<MeshRenderer>().material = standbyMaterial;
                    }
                    clickedObject = raycastHit.collider.gameObject;
                    clickedObject.GetComponent<MeshRenderer>().material = hoverMaterial;
				}
                lr.SetPosition(1, raycastHit.point);
                
            }
            else
            {
                lr.SetPosition(1, laser.origin + laser.direction * 100f);
                if (clickedObject != null)
                {
                    clickedObject.GetComponent<MeshRenderer>().material = standbyMaterial;
                }
            }
            
		}
		else {
            lr.enabled = false;
			RaycastHit raycastHit;
			if(Physics.Raycast(transform.position, transform.forward, out raycastHit)) {
				if(clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.X) {
					clickedObject.transform.position = new Vector3(Mathf.FloorToInt((transform.position + transform.forward * 20f).x), clickedObject.transform.position.y, clickedObject.transform.position.z);
				}
				else if(clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Y) {
					clickedObject.transform.position = new Vector3(clickedObject.transform.position.x, Mathf.FloorToInt((transform.position + transform.forward * 20f).y), clickedObject.transform.position.z);
				}
				else if(clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Z) {
					clickedObject.transform.position = new Vector3(clickedObject.transform.position.x, clickedObject.transform.position.y, Mathf.FloorToInt((transform.position + transform.forward * 20f).z));
				}
                else if (clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Base)
                {
                    GameObject.FindGameObjectWithTag("Base").transform.position = new Vector3((transform.position + transform.forward * 20f).x, GameObject.FindGameObjectWithTag("Base").transform.position.y, (transform.position + transform.forward * 20f).z);
                }
            }
		}
	}
}
