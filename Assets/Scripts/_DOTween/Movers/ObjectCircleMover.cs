using DG.Tweening;
using UnityEngine;

namespace _DOTween.Movers
{
	public class ObjectCircleMover : MonoBehaviour
	{
		[SerializeField] private float _movementDuration;
		[SerializeField] private float _rotationDuration;
		[SerializeField] private bool _isPlaying = false;

		private Sequence _movingSequence;

		private void Start()
		{
			StartMoving();
		}

		private void Update()
		{
			HandleSequencePause();
		}

		private void HandleSequencePause()
		{
			if (_isPlaying && !_movingSequence.IsPlaying())
			{
				_movingSequence?.Play();
			}
			else if (!_isPlaying && _movingSequence.IsPlaying())
			{
				_movingSequence?.Pause();
			}
		}

		private void StartMoving()
		{
			_movingSequence?.Kill();
			_movingSequence = DOTween.Sequence()
				.Pause()
				.Append(transform.DOMove(transform.position + transform.forward, _movementDuration))
				.AppendInterval(1f)
				.Append(transform.DORotate(transform.eulerAngles + new Vector3(0f, 90f, 0f), _rotationDuration))
				.AppendInterval(1f)
				.SetLink(gameObject, LinkBehaviour.KillOnDestroy)
				.OnComplete(StartMoving);
		}
	}
}