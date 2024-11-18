using DG.Tweening;
using UnityEngine;

namespace _DOTween.Movers
{
	public class ObjectRotator : MonoBehaviour
	{
		[SerializeField] private float _rotationsPerSecond;
		[SerializeField] private bool _isClockwise;
		[SerializeField] private bool _isPlaying = false;

		private Sequence _rotationSequence;
		private float _currentRotation;
		
		private void Start()
		{
			StartRotation();
		}

		private void Update()
		{
			HandleSequencePause();
		}

		private void HandleSequencePause()
		{
			if (_isPlaying && !_rotationSequence.IsPlaying())
			{
				_rotationSequence?.Play();
			}
			else if (!_isPlaying && _rotationSequence.IsPlaying())
			{
				_rotationSequence?.Pause();
			}
		}
		
		private void StartRotation()
		{
			float duration = 1f / _rotationsPerSecond;
			_currentRotation = 0f;
			
			_rotationSequence?.Kill();
			_rotationSequence = DOTween.Sequence()
				.Pause()
				.Append(DOTween.To(() => _currentRotation, x => _currentRotation = x, 360f * (_isClockwise ? 1 : -1), duration)
					.SetEase(Ease.Linear)
					.OnUpdate(() => transform.eulerAngles = new Vector3(transform.eulerAngles.x, _currentRotation, transform.eulerAngles.z)))
				.OnComplete(StartRotation);
		}
	}
}