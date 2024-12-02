using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace WebRequests
{
	public class WebRequestsController
	{
		public event Action<string> SuccessGetDataEvent;
        
		private const string URI = "https://dev.goimprovr.com/wp-json";
		
		private string _token;

		public IEnumerator Get()
		{
			using (UnityWebRequest request = UnityWebRequest.Get(URI))
			{
				AddAuthorizationRequest(request);
				yield return request.SendWebRequest();
                
				if (request.result != UnityWebRequest.Result.Success)
				{
					Debug.LogError("Error downloading: " + request.error);
				}
				else
				{
					string result = request.downloadHandler.text;
					SuccessGetDataEvent?.Invoke(result);
				}
			}
		}
		
		public IEnumerator _GetToken()
		{
			WWWForm form = new WWWForm();
			form.AddField("username", "testusr");
			form.AddField("password", "testusr@sO2024!");

			using (UnityWebRequest request = UnityWebRequest.Post($"{URI}/jwt-auth/v1/token", form))
			{
				yield return request.SendWebRequest();
                
				if (request.result != UnityWebRequest.Result.Success) 
				{
					Debug.LogError("Error uploading data: " + request.error);
				} 
				else 
				{
					Debug.Log(request.downloadHandler.text);
				}
			}
		}
		
		public IEnumerator _GetMe()
		{
			WWWForm form = new WWWForm();
			form.AddField("username", "testusr");
			form.AddField("password", "testusr@sO2024!");

			using (UnityWebRequest request = UnityWebRequest.Post("https://dev.goimprovr.com/wp-json/wp/v2/users/me", form))
			{
				request.SetRequestHeader("Authorization", $"Bearer token={"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczovL2Rldi5nb2ltcHJvdnIuY29tIiwiaWF0IjoxNzMzMTQ0NjQ5LCJuYmYiOjE3MzMxNDQ2NDksImV4cCI6MTczMzc0OTQ0OSwiZGF0YSI6eyJ1c2VyIjp7ImlkIjoiMiJ9fX0.1-f4ohN3iBM6BO9Wz8nvTacVBfOwieJflraOElkX2JE"}");
				yield return request.SendWebRequest();
                
				if (request.result != UnityWebRequest.Result.Success) 
				{
					Debug.LogError("Error uploading data: " + request.error);
				} 
				else 
				{
					Debug.Log(request.downloadHandler.text);
				}
			}
		}

		private void AddAuthorizationRequest(UnityWebRequest request)
		{
			request.SetRequestHeader("Authorization", $"Bearer token=authorization_token");
		}
		
		public WebRequestsController()
		{
			
		}

		public string GetToken()
		{
			return "";
		}

		public string GetUserInfo()
		{
			return "";
		}

		public string GetOrders()
		{
			return "";
		}
	}
}