using System;

[Serializable]
public class Dialogue
{
	public String language;
	public Intro intro;
	public TaskDialogue[] taskDialouge;

	/*
	[Serializable]
	public class Intro {
		public Messages[] messages;
	}

	[Serializable]
	public class Messages {
		public String[] text;
	}
	*/
}
