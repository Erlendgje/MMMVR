using UnityEngine;

public class Tablet : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private RectTransform position;
	private Vector3 fromPosition;

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("GameController")) {
			fromPosition = other.transform.position;
		}
	}

	private void OnTriggerStay(Collider other) {
		if(other.gameObject.CompareTag("GameController")) {
			Vector3 scrollValue = Vector3.Cross(this.transform.position, other.transform.rotation.eulerAngles / 360) - Vector3.Cross(fromPosition, other.transform.rotation.eulerAngles / 360);
			position.position = new Vector3(scrollValue.x, position.position.y, position.position.z);
		}
	}
}
