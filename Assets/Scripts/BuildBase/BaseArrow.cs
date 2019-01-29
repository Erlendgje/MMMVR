using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class BaseArrow : MonoBehaviour {
	private static bool mathWorldActivated = false;
	private bool arrowPress = false;
	[SerializeField] Material hoverMaterial;
	[SerializeField] Material standbyMaterial;
	[SerializeField] Material canPlaceMaterial;
	[SerializeField] Material cantPlaceMaterial;
	private GameObject clickedObject;
    private MeshRenderer mr;
	private LineRenderer lr;
	private Ray laser;
    private Vector3 initialControllerState;
    private Vector3 initialClickedObjectPosition;


	// Start is called before the first frame update
	void Start() {
		lr = GetComponent<LineRenderer>();
		laser = new Ray();
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
        laser.origin = this.transform.position;
        laser.direction = this.transform.forward;
        if (getArrowDown()) {
			RaycastHit raycastHit;
            if (Physics.Raycast(laser, out raycastHit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Base"), QueryTriggerInteraction.Ignore))
            {
                arrowPress = true;
                clickedObject = raycastHit.collider.gameObject.GetComponentInParent<ArrowsEnum>().gameObject;
                mr = raycastHit.collider.gameObject.GetComponent<MeshRenderer>();
                initialControllerState = transform.position + transform.forward * 20f;
                initialClickedObjectPosition = clickedObject.transform.position;
                if (clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Base)
                {
                    initialClickedObjectPosition = clickedObject.GetComponentInParent<Observer>().transform.position;
                }
            }
		}
	
		if(getArrowUp()) {
			arrowPress = false;
			if(clickedObject != null) {
				mr.material = standbyMaterial;
                if (clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Base)
                {
                    clickedObject.GetComponent<ExpandBase>().setColor = true;
                }
                clickedObject.GetComponentInParent<Observer>().checkTask();
				clickedObject = null;
            }
		}

		if(!arrowPress) {
			lr.enabled = true;
			lr.SetPosition(0, transform.position);

			RaycastHit raycastHit;
			if(Physics.Raycast(laser, out raycastHit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Base"), QueryTriggerInteraction.Ignore)) {
				if(clickedObject != null && raycastHit.collider.gameObject != clickedObject) {
					mr.material = standbyMaterial;
                    if(clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Base)
                    {
                        clickedObject.GetComponent<ExpandBase>().setColor = true;
                    }
				}
				clickedObject = raycastHit.collider.gameObject.GetComponentInParent<ArrowsEnum>().gameObject;
                mr = raycastHit.collider.gameObject.GetComponent<MeshRenderer>();
				mr.material = hoverMaterial;
				lr.SetPosition(1, raycastHit.point);
                if (clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Base)
                {
                    clickedObject.GetComponent<ExpandBase>().setColor = false;
                }

            }
			else {
				lr.SetPosition(1, laser.origin + laser.direction * 100f);
				if(clickedObject != null) {
                    if (clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Base)
                    {
                        clickedObject.GetComponent<ExpandBase>().setColor = true;
                    }
                    mr.material = standbyMaterial;
				}
			}

		}
		else {
			lr.enabled = false;
            if (clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.X) {
				clickedObject.transform.position = new Vector3(Mathf.RoundToInt(initialClickedObjectPosition.x + ((transform.position + transform.forward * 20f) - initialControllerState).x), clickedObject.transform.position.y, clickedObject.transform.position.z);
			}
			else if(clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Y) {
                if(Mathf.RoundToInt(initialClickedObjectPosition.y + ((transform.position + transform.forward * 20f) - initialControllerState).y) > 0 && Mathf.RoundToInt(initialClickedObjectPosition.y + ((transform.position + transform.forward * 20f) - initialControllerState).y) < 21)
                {
                    clickedObject.transform.position = new Vector3(clickedObject.transform.position.x, Mathf.RoundToInt(initialClickedObjectPosition.y + ((transform.position + transform.forward * 20f) - initialControllerState).y), clickedObject.transform.position.z);
                }
            }
			else if(clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Z) {
				clickedObject.transform.position = new Vector3(clickedObject.transform.position.x, clickedObject.transform.position.y, Mathf.RoundToInt(initialClickedObjectPosition.z + ((transform.position + transform.forward * 20f) - initialControllerState).z));
			}
			else if(clickedObject.GetComponent<ArrowsEnum>().direction == ArrowsEnum.Direction.Base) {
				clickedObject.GetComponentInParent<Observer>().transform.position = new Vector3(Mathf.RoundToInt(initialClickedObjectPosition.x + ((transform.position + transform.forward * 20f) - initialControllerState).x), clickedObject.GetComponentInParent<Observer>().transform.position.y, Mathf.RoundToInt(initialClickedObjectPosition.z + ((transform.position + transform.forward * 20f) - initialControllerState).z));
                if(clickedObject.GetComponent<ExpandBase>().outside || !clickedObject.GetComponent<ExpandBase>().inside)
                {
                    mr.material = cantPlaceMaterial;
                }
                else
                {
                    mr.material = canPlaceMaterial;
                }
			}
		}
    }
}
