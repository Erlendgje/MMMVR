using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class MyHandScript : MonoBehaviour {

	[SerializeField] private GameObject mathWorld;
	[SerializeField] private GameObject teleportingArea;
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
				SceneManager.SetActiveScene(SceneManager.GetSceneByName("MathWorld"));
				teleportingArea.SetActive(false);
				teleportPlayer(new Vector3(0, 1, 0));
			}
			else {
				mathWorldActivated = false;
				SceneManager.SetActiveScene(SceneManager.GetSceneByName("TheGame"));
				SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MathWorld"));
				teleportingArea.SetActive(true);
				teleportPlayer(new Vector3(0, 1, 0));
			}
		}
	}

	private void teleportPlayer(Vector3 position) {
		GameObject.FindGameObjectWithTag("Player").transform.position = position;
	}


}
