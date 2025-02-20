using NaughtyAttributes;
using UnityEngine;

namespace AIIntegration.Test
{
	public class MonoBeh : MonoBehaviour
	{
		[Button]
		public void RequestWords()
		{
			var geminiWordsGenerator = new GeminiWordsGenerator(
					"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent",
					"AIzaSyA2HZ8WnWfvFyCl0cp4I5Zig1UxnbqAiL8",
					"Програмування",
					',');
			var words = geminiWordsGenerator.GetWords(10);
			
			
			Debug.Log("---------");
			for (int i = 0; i < words.Length; i++)
			{
				Debug.Log(words[i]);
			}
			Debug.Log("---------");
		}
	}
}