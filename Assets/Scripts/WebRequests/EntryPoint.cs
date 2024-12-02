using UnityEngine;
using WebRequests.UI;

namespace WebRequests
{
	public class EntryPoint : MonoBehaviour
	{
		[SerializeField] private RequestsPanel _requestsPanel;
		
		private WebRequestsController _webRequestsController;

		private void Awake()
		{
			_webRequestsController = new WebRequestsController();
			InitializeUI();
		}

		private void InitializeUI()
		{
			_requestsPanel.Initialize(GetToken, GetUserInfo, GetOrders);
		}

		[ContextMenu("Get token")]
		public void GetTokenByDebug()
		{
			StartCoroutine(_webRequestsController._GetToken());
		}
		
		[ContextMenu("Get me info")]
		public void GetMe()
		{
			StartCoroutine(_webRequestsController._GetMe());
		}

		private void GetToken()
		{
			_requestsPanel.UpdateResultText(_webRequestsController.GetToken());
		}

		private void GetUserInfo()
		{
			_requestsPanel.UpdateResultText(_webRequestsController.GetUserInfo());
		}

		private void GetOrders()
		{
			_requestsPanel.UpdateResultText(_webRequestsController.GetOrders());
		}
	}
}