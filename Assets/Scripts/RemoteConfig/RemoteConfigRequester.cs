using UnityEngine;
using System.Threading.Tasks;

using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.RemoteConfig;
using UnityEngine.UI;

namespace RemoteConfig
{
	public class RemoteConfigRequester : MonoBehaviour
	{
		public struct UserAttributes
		{
			public string Name;
		}

		public struct AppAttributes
		{
			public string Rules;
		}

		[SerializeField] private RemoteConfigView _remoteConfigView;
		[SerializeField] private Button _reloadButton;
		
		private void Awake()
		{
			_reloadButton.onClick.AddListener(() =>
			{
				gameObject.SetActive(false);
				gameObject.SetActive(true);
			});
			RemoteConfigService.Instance.FetchCompleted += ApplyRemoteConfig;
		}
		
		private async void OnEnable()
		{
			await InitializeRemoteConfigAsync();
			await RemoteConfigService.Instance.FetchConfigsAsync(new UserAttributes(), new AppAttributes());
		}

		private async Task InitializeRemoteConfigAsync()
		{
			await UnityServices.InitializeAsync();
			if (!AuthenticationService.Instance.IsSignedIn)
			{
				await AuthenticationService.Instance.SignInAnonymouslyAsync();
			}
		}

		private void ApplyRemoteConfig(ConfigResponse configResponse)
		{
			switch (configResponse.requestOrigin) 
			{
				case ConfigOrigin.Default:
					Debug.Log ("No settings loaded this session and no local cache file exists; using default values.");
					break;
				case ConfigOrigin.Cached:
					Debug.Log ("No settings loaded this session; using cached values from a previous session.");
					break;
				case ConfigOrigin.Remote:
					Debug.Log ("New settings loaded this session; update values accordingly.");
					break;
			}
			
			_remoteConfigView.Initialize(
				RemoteConfigService.Instance.appConfig.GetString("Name"), 
				RemoteConfigService.Instance.appConfig.GetString("Info")
				);
		}
	}
}