using System;
using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

namespace AIIntegration.ChatGPT 
{
	/*static class OpenAIUtil
	{

		public static IEnumerator SendRequestCoroutine(string requestText, Action<string> callback = null)
		{
			var settings = AICommandSettings.instance;

			using var www = UnityWebRequest.Post(Api.Url, CreateChatRequestBody(requestText), "application/json");
			www.timeout = settings.timeout;
			www.SetRequestHeader("Authorization", "Bearer " + settings.apiKey);

			yield return www.SendWebRequest();
			
			if (www.result != UnityWebRequest.Result.Success) 
			{
				Debug.LogError(www.error);
			} 
			else 
			{
				callback?.Invoke(www.downloadHandler.text);
			}
		}
		
		public static string InvokeChat(string prompt)
		{
			var settings = AICommandSettings.instance;

			using var post = UnityWebRequest.Post(Api.Url, CreateChatRequestBody(prompt), "application/json");
			post.timeout = settings.timeout;
			post.SetRequestHeader("Authorization", "Bearer " + settings.apiKey);
			var req = post.SendWebRequest();

			// Progress bar (Totally fake! Don't try this at home.)
			for (var progress = 0.0f; !req.isDone; progress += 0.01f)
			{
				EditorUtility.DisplayProgressBar
					("AI Command", "Generating...", progress);
				System.Threading.Thread.Sleep(100);
				progress += 0.01f;
			}
			EditorUtility.ClearProgressBar();

			// Response extraction
			var json = post.downloadHandler.text;
			var data = JsonUtility.FromJson<Response>(json);
			return data.choices[0].message.content;
		}
		
		private static string CreateChatRequestBody(string prompt)
		{
			var msg = new RequestMessage();
			msg.role = "user";
			msg.content = prompt;

			var req = new Request();
			req.model = "gpt-3.5-turbo";
			req.messages = new [] { msg };

			return JsonUtility.ToJson(req);
		}
	}*/
}