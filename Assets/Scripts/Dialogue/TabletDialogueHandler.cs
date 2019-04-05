using System;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabletDialogueHandler : MonoBehaviour
{

	private String dialogueFileName = "story.json";
	private Dialogue dialogue;
	[SerializeField] private GameObject chat;
	[SerializeField] private GameObject textBubble;
	[SerializeField] private float secondsBetweenMessages;
	[SerializeField] private RectTransform scrollView;
	[SerializeField] private ScrollRect scrollRect;

	private int storyProgress = 0;

	// Start is called before the first frame update
	void Start()
    {
		string filePath = Path.Combine(Application.streamingAssetsPath, dialogueFileName);
		if(File.Exists(filePath)) {
			string dataAsJason = File.ReadAllText(filePath);
			dialogue = JsonUtility.FromJson<Dialogue>(dataAsJason);
		}
		else {
			this.enabled = false;
		}
		playIntro();
	}

	public void playIntro() {
		StartCoroutine(addToChat(dialogue.intro.message[0].text));
	}

	public void playStory() {
		if(dialogue.taskDialouge[GameManager.gameManager.getCurrentTask()].message.Length < storyProgress) {
			StartCoroutine(addToChat(dialogue.taskDialouge[GameManager.gameManager.getCurrentTask()].message[storyProgress].text));
			storyProgress++;

			if(dialogue.taskDialouge[GameManager.gameManager.getCurrentTask()].message.Length == storyProgress) {
				storyProgress = 0;
			}
		}
	}

	public void playClue(String id) {
		Clue c = Array.Find<Clue>(dialogue.taskDialouge[GameManager.gameManager.getCurrentTask()].clue, clue => clue.id.CompareTo(id) == 0);
		StartCoroutine(addToChat(c.text));
	}

	private IEnumerator addToChat(String[] messages) {
		for(int i = 0; i < messages.Length; i++) {
			GameObject chatBubble = Instantiate(textBubble, chat.transform);
			chatBubble.GetComponentInChildren<TextMeshProUGUI>().text = messages[i];
			LayoutRebuilder.ForceRebuildLayoutImmediate(chatBubble.GetComponent<RectTransform>());
			yield return null;
			LayoutRebuilder.ForceRebuildLayoutImmediate(scrollView);
			yield return null;
			//scrollRect.normalizedPosition = new Vector2(0.0f, 0.0f);
			StartCoroutine(scrollDown());

			GetComponent<AudioSource>().Play();
			if(i < messages.Length - 1) {
				yield return new WaitForSeconds(secondsBetweenMessages);
			}
		}
	}

	private IEnumerator scrollDown() {

		while(scrollRect.verticalNormalizedPosition > 0) {

			scrollView.Translate(new Vector3(0, 0.5f, 0) * Time.deltaTime);

			yield return null;
		}
	}
}
