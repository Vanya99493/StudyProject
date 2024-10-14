using _UniRx.Infrastructure.Factories;
using _UniRx.UI;
using UniRx;
using UnityEngine;

namespace _UniRx.Infrastructure
{
	public class WavesEntryPoint : MonoBehaviour
	{
		[SerializeField] private BugFactory _bugFactory;
		[SerializeField] private WavesLevelPanel _wavesLevelPanel;

		private ISubject<int> _waves = new Subject<int>();

		private CompositeDisposable _disposable = new();

		private void Awake()
		{
			_waves.Subscribe(
				onNext: OnNextStep,
				onCompleted: OnComplete
				).AddTo(_disposable);
			
			_wavesLevelPanel.Initialize(
				() => _waves.OnNext(1),
				_waves.OnCompleted
				);
		}

		private void OnNextStep(int bugsCount)
		{
			for (int i = 0; i < bugsCount; i++)
			{
				_bugFactory.InstantiateBug();
			}
		}

		private void OnComplete()
		{
			_disposable.Dispose();
		}
	}
}