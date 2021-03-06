﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TabletDialogueHandler : MonoBehaviour
{

	private String dialogueFileName = "story.json";
	private Dialogue dialogue;
    private AudioSource audioSource;
	[SerializeField] private GameObject chat;
	[SerializeField] private GameObject textBubble;
	[SerializeField] private RectTransform scrollView;
	[SerializeField] private ScrollRect scrollRect;
	[SerializeField] private List<Hand> hands;

	public int storyProgress = 0;
	public int clueProgress = 0;


	public SteamVR_Input_Sources handType;
	public SteamVR_Action_Boolean changeAction;

	public bool getClueDown() {
		return changeAction.GetLastStateDown(handType);
	}


	// Start is called before the first frame update
	void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

	private void Update() {
		if(getClueDown()) {
            foreach(Hand h in hands)
            {
                hideButtonHint(h);
            }
			playClue();
		}
	}

	public void playIntro() {
        string audioName = "intro-message0-text";
        StartCoroutine(addToChat(dialogue.intro.message[0].text, audioName));
		StartCoroutine(showHint(dialogue.intro.message[0].text.Length * 5));
	}

	public void playStory() {
		if(dialogue.taskDialouge[GameManager.gameManager.getCurrentTask()].message.Length > storyProgress) {
            string audioName = "story-id" + GameManager.gameManager.getCurrentTask() + "-message" + storyProgress + "-text";

            StartCoroutine(addToChat(dialogue.taskDialouge[GameManager.gameManager.getCurrentTask()].message[storyProgress].text, audioName));

			if(storyProgress == 0)
			{
				clueProgress = 0;
			}

			storyProgress++;

			if(dialogue.taskDialouge[GameManager.gameManager.getCurrentTask()].message.Length == storyProgress) {
				storyProgress = 0;
				clueProgress = 0;
			}
		}
	}

	public void playClue() {
		if(dialogue.taskDialouge[GameManager.gameManager.getCurrentTask()].clue.Length > clueProgress) {
            string audioName = "clue-id" + GameManager.gameManager.getCurrentTask() + "-message" + clueProgress + "-text";
            StartCoroutine(addToChat(dialogue.taskDialouge[GameManager.gameManager.getCurrentTask()].clue[clueProgress].text, audioName));
			clueProgress++;
		}
	}

	private IEnumerator addToChat(String[] messages, string name) {
		for(int i = 0; i < messages.Length; i++) {
			GameObject chatBubble = Instantiate(textBubble, chat.transform);
			chatBubble.GetComponentInChildren<TextMeshProUGUI>().text = messages[i];
			LayoutRebuilder.ForceRebuildLayoutImmediate(chatBubble.GetComponent<RectTransform>());
			yield return null;
			LayoutRebuilder.ForceRebuildLayoutImmediate(scrollView);
			yield return null;
			StartCoroutine(scrollDown());
            string audioName = name + i;
			AudioClip ac = Resources.Load<AudioClip>("DialogueAudio/" + audioName);
            audioSource.clip = ac;
			audioSource.Play();
			if(i < messages.Length - 1) {
				yield return new WaitForSeconds(audioSource.clip.length);
			}
		}
	}

	private IEnumerator scrollDown() {

		while(scrollRect.verticalNormalizedPosition > 0) {

			scrollView.Translate(new Vector3(0, 0.5f, 0) * Time.deltaTime);

			yield return null;
		}
	}

	private IEnumerator showHint(float seconds) {
		yield return new WaitForSeconds(seconds);
		foreach(Hand h in hands) {
			showButtonHint(h, changeAction, "Hint");
			h.TriggerHapticPulse(700);
		}
	}

	private void showButtonHint(Hand hand, SteamVR_Action_Boolean action, string text) {
		if(!ControllerButtonHints.IsButtonHintActive(hand, action)) {
			ControllerButtonHints.ShowButtonHint(hand, action);
			ControllerButtonHints.ShowTextHint(hand, action, text, true);
		}
	}

	private void hideButtonHint(Hand hand) {
		ControllerButtonHints.HideAllButtonHints(hand);
		ControllerButtonHints.HideAllTextHints(hand);
	}
}
