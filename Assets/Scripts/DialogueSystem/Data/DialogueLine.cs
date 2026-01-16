using System;
using UnityEngine;

namespace DialogueSystem
{
	[Serializable]
	public class DialogueLine
	{
		public SpeakerType SpeakerType { get; private set; }
		public string Text { get; private set; }
		public AudioClip AudioClip { get; private set; }

		public DialogueLine(SpeakerType speakerType, string text, AudioClip audioClip)
		{
			SpeakerType = speakerType;
			Text = text;
			AudioClip = audioClip;
		}
	}
}