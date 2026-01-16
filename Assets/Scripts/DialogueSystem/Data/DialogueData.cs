using System.Collections.Generic;

namespace DialogueSystem
{
	public class DialogueData
	{
		private readonly string _name = "";
		private readonly List<DialogueLine> _dialogueLines = new();

		public string Name => _name;
		public List<DialogueLine> DialogueLines
		{
			get
			{
				List<DialogueLine> dialogueLines = new();
				foreach (var dialogueLine in _dialogueLines)
				{
					dialogueLines.Add(dialogueLine);
				}
				return dialogueLines;
			}
		}

		public DialogueData() {}
		
		public DialogueData(string name, List<DialogueLine> dialogueLines)
		{
			_name = name;
			_dialogueLines = dialogueLines;
		}
	}
}