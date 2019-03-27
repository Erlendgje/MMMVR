using UnityEngine;

public class Tablet : MonoBehaviour
{
	[SerializeField] private RectTransform position;
	private Vector3 fromPosition;
	private Vector3 startScrollPosition;

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("GameController")) {
			fromPosition = other.transform.position;
			startScrollPosition = position.localPosition;
			Debug.Log(fromPosition);
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
			tempPosition[0] = startScrollPosition.x + scrollValue;
			position.localPosition = tempPosition;
		}
	}
}
