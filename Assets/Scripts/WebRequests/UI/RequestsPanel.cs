using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WebRequests.UI
{
	public class RequestsPanel : MonoBehaviour
	{
		[SerializeField] private TMP_Text _resultText;
		[SerializeField] private Button _getTokenButton;
		[SerializeField] private Button _getUserInfoButton;
		[SerializeField] private Button _getOrdersButton;

		public void Initialize(Action onGetTokenButtonClickEvent, Action onGetUserInfoButtonClickEvent,
			Action onGetOrdersButtonClickEvent)
		{
			_getTokenButton.onClick.AddListener(() => onGetTokenButtonClickEvent?.Invoke());
			_getUserInfoButton.onClick.AddListener(() => onGetUserInfoButtonClickEvent?.Invoke());
			_getOrdersButton.onClick.AddListener(() => onGetOrdersButtonClickEvent?.Invoke());
		}

		public void Deinitialize()
		{
			_getTokenButton.onClick.RemoveAllListeners();
			_getUserInfoButton.onClick.RemoveAllListeners();
			_getOrdersButton.onClick.RemoveAllListeners();
		}

		public void UpdateResultText(string result)
		{
			_resultText.text = result;
		}
	}
}