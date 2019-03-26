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
			Quaternion rotation = this.transform.rotation;
			Matrix4x4 m = Matrix4x4.Rotate(rotation);
			Vector3 tabletDirection = m.MultiplyPoint(Vector3.right);
			Vector3 scrollDirection = other.transform.position - fromPosition;
			float scrollValue = Vector3.Dot(tabletDirection, scrollDirection);

			Vector3 tempPosition = position.localPosition;
			tempPosition[0] = scrollValue;
			position.localPosition = tempPosition;
		}
	}
}
