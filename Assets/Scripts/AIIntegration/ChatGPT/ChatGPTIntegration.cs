using System;
using NaughtyAttributes;
using UnityEngine;

namespace AIIntegration.ChatGPT
{
	/*public class ChatGPTIntegration : MonoBehaviour
	{
		[SerializeField] private string _topic = "";
		[SerializeField] private string _resultWordsNumber;
		[SerializeField] private Language _language;

		[Button]
		public void SendRequest()
		{
			StartCoroutine(OpenAIUtil.SendRequestCoroutine(BuildRequestMessage(), PrintResult));
		}

		private void PrintResult(string result)
		{
			Debug.Log(result);
		}
		
		private string BuildRequestMessage()
		{
			switch (_language)
			{
				case Language.English:
					return
						$"Give me a list of ${_resultWordsNumber} noun words related to the topic {_topic}. The answer should contain only the words I need in the following format: they should be on one line, with no punctuation other than a comma ','. The result should be in {_language} language";
				case Language.Ukrainian:
					return
						$"Наведи мені список з ${_resultWordsNumber} слів іменників пов'язаних з темою {_topic}. У відповіді повинні бути тільки необхідні мені слова у наступному форматі: вони мають бути в один рядок, без жодних розділових знаків окрім коми ','. Результат має мути {_language} мовою";
			}

			throw new Exception("Cannot find the matched language");
		}
	}*/
}