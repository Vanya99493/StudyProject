using System;
using UnityEngine;
using UnityEngine.UI;

namespace _UniRx.UI
{
	public class WavesLevelPanel : MonoBehaviour
	{
		[SerializeField] private Button _nextStepButton;
		[SerializeField] private Button _completeButton;

		public void Initialize(Action OnNextStepButtonClick, Action OnCompleteButtonClick)
		{
			_nextStepButton.onClick.AddListener(() => OnNextStepButtonClick?.Invoke());
			_completeButton.onClick.AddListener(() => OnCompleteButtonClick?.Invoke());
		}
	}
}