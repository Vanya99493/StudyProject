using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace AIIntegration.Test
{
	public class GeminiRequester : IRequester
	{
		private readonly string _apiUrl;
		private readonly string _apiKey;
		private readonly string _topic;
		private readonly char _splitSymbol;
		
		public GeminiRequester(string apiUrl, string apiKey, string topic, char splitSymbol)
		{
			_apiUrl = apiUrl;
			_apiKey = apiKey;
			_topic = topic;
			_splitSymbol = splitSymbol;
		}
		
		public async Task<string> RequestWords(int wordsCount)
		{
			string url = $"{_apiUrl}?key={_apiKey}";
			string jsonData = "{\"contents\": [{\"parts\": [{\"text\": \"{" + BuildRequestMessage(wordsCount) + "}\"}]}]}";
			byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
			
			using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
			{
				www.uploadHandler = new UploadHandlerRaw(jsonToSend);
				www.downloadHandler = new DownloadHandlerBuffer();
				www.SetRequestHeader("Content-Type", "application/json");

				var operation = www.SendWebRequest();

				while (!operation.isDone)
				{
					await Task.Yield();
				}
				
				if (www.result != UnityWebRequest.Result.Success) 
				{
					Debug.LogError(www.error);
				} 
				else 
				{
					Response response = JsonUtility.FromJson<Response>(www.downloadHandler.text);
					if (response.candidates.Length > 0 && response.candidates[0].content.parts.Length > 0)
					{
						string text = response.candidates[0].content.parts[0].text;
						return text;
					}
					
					Debug.Log("No text found.");
				}

				return "";
			}
		}
		
		private string BuildRequestMessage(int wordsCount)
		{
			return $"Наведи мені список з ${wordsCount} слів іменників пов'язаних з темою {_topic}. У відповіді повинні бути тільки необхідні мені слова у наступному форматі: вони мають бути в один рядок, без жодних розділових знаків окрім настумного '{_splitSymbol}'. Результат наведи українсьокю мовою.";
		}
	}
}