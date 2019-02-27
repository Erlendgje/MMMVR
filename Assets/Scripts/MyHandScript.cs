using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class MyHandScript : MonoBehaviour {
    
	private static bool mathWorldActivated = false;

	// Start is called before the first frame update
	void Start() {

	}

	public SteamVR_Input_Sources handType;
	public SteamVR_Action_Boolean changeAction;

	public bool GetChangeScene() {
		return changeAction.GetLastStateDown(handType);
	}

	// Update is called once per frame
	void Update() {
		if(GetChangeScene()) {
			if(!mathWorldActivated) {
				mathWorldActivated = true;
				SceneManager.LoadScene("MathWorld", LoadSceneMode.Additive);

			}
			else {
				mathWorldActivated = false;
				SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MathWorld"));
			}
		}
	}

	private void teleportPlayer(Vector3 position) {
		GameObject.FindGameObjectWithTag("Player").transform.position = position;
	}

}
