using UnityEngine;

namespace AIIntegration
{
	[CreateAssetMenu(fileName = "ApiKeyConfig", menuName = "AIIntegration/Configs/ApiKeyConfig")]
	public class ApiKeyConfig : ScriptableObject
	{
		[SerializeField] private string _apiKey;
		
		public string ApiKey => _apiKey;
	}
}