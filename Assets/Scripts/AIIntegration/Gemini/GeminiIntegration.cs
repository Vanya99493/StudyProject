using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Networking;

namespace AIIntegration
{
	public class GeminiIntegration : MonoBehaviour
	{
		[SerializeField] private ApiKeyConfig _apiKeyConfig;
        [Space(10)]
        [SerializeField] private string _topic = "";
        [SerializeField] private string _resultWordsNumber;
        [SerializeField] private Language _language;
        
        private readonly string _apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent";
        
        [Button]
        public void SendRequest()
        {   
            StartCoroutine( SendPromptRequestToGemini(PrintResultWords));    
        }

        private void PrintResultWords(string result)
        {
            string[] words = result.Trim().Split(',');
            Debug.Log("----------------");
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
                Debug.Log(words[i]);
            }
            Debug.Log("----------------");
        }

        private IEnumerator SendPromptRequestToGemini(Action<string> callback = null)
        {
            string url = $"{_apiUrl}?key={_apiKeyConfig.ApiKey}";
            string jsonData = "{\"contents\": [{\"parts\": [{\"text\": \"{" + BuildRequestMessage() + "}\"}]}]}";
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);

            using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
            {
                www.uploadHandler = new UploadHandlerRaw(jsonToSend);
                www.downloadHandler = new DownloadHandlerBuffer();
                www.SetRequestHeader("Content-Type", "application/json");

                yield return www.SendWebRequest();

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
                        callback?.Invoke(text);
                    }
                    else
                    {
                        Debug.Log("No text found.");
                    }
                }
            }
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
	}
}