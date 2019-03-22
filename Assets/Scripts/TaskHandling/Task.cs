using UnityEngine;
using UnityEngine.Events;

public class Task : MonoBehaviour {

	[SerializeField] private bool plane;
	public float solution;
	public bool answerSpaceCorrect;
	public bool taskComplete;
	private TaskHandler taskHandler;
	public int index;
	[SerializeField] private GameObject textZ;
	[SerializeField] private GameObject handleX;
	[SerializeField] private GameObject handleY;
	[SerializeField] private GameObject handleZ;
	[SerializeField] private UnityEvent onCorrect;
	[SerializeField] private UnityEvent onWrong;

	// Start is called before the first frame update
	void Start() {
		taskHandler = GetComponentInParent<TaskHandler>();
		index = taskHandler.registerTask();
	}

	public void changeSolution(float solution, bool plane) {
		this.plane = plane;
        try
        {
            if (plane)
            {
                textZ.SetActive(false);
                handleZ.SetActive(false);
                this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, 0.01f);
                handleX.transform.localPosition = new Vector3(handleX.transform.localPosition.x, handleX.transform.localPosition.y, 0);
                handleY.transform.localPosition = new Vector3(handleY.transform.localPosition.x, handleY.transform.localPosition.y, 0);
            }
            else
            {
                textZ.SetActive(true);
                handleZ.SetActive(true);
                ExpandLine el = handleZ.GetComponentInChildren<ExpandLine>();
                el.onAttach();
                el.onDetach();
            }
        }
        catch
        {
            Debug.Log("labal");
        }
		
		this.solution = solution;
	}

	public void setAnswerSpaceCorrect(bool value) {
		answerSpaceCorrect = value;
		checkIfSolved();
	}

	public void checkIfSolved() {
		if(answerSpaceCorrect) {
			Vector3 size = this.transform.localScale;
			float volume = 0;
			if(plane) {
				volume = size.x * size.y * 100;
			}
			else {
				volume = size.x * size.y * size.z * 1000;
			}

			if(Mathf.Round(volume) == Mathf.Round(solution)) {
				taskComplete = true;
				onCorrect.Invoke();
			}
			else {
				taskComplete = false;
				onWrong.Invoke();
			}
		}
		else {
			taskComplete = false;
			onWrong.Invoke();
		}

		taskHandler.updateTask(index, taskComplete);
	}

	public void onDetach() {
		checkIfSolved();
	}
}
