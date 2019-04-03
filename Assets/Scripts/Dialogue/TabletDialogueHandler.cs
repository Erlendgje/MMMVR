using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TabletDialogueHandler : MonoBehaviour
{

	private String dialogueFileName = "story.json";
	private Dialogue dialogue;

	// Start is called before the first frame update
	void Start()
    {
		string filePath = Path.Combine(Application.streamingAssetsPath, dialogueFileName);

		if(File.Exists(filePath)) {
			string dataAsJason = File.ReadAllText(filePath);
			dialogue = JsonUtility.FromJson<Dialogue>(dataAsJason);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
