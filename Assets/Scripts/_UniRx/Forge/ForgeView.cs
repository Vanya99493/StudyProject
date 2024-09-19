using _UniRx.SwordModule;
using UniRx;
using UnityEngine;

namespace _UniRx.Forge
{
	public class ForgeView : MonoBehaviour
	{
		[SerializeField] private SwordView _swordView;
		
		private readonly CompositeDisposable _disposable = new();
		
		private Sword _sword;

		private void Awake()
		{
			_sword = new Sword();
			_sword.CurrentHealthPoints.Subscribe(newValue => _swordView.UpdateSwordHealthPointsText(newValue)).AddTo(_disposable);
			_sword.Initialize(100);
		}

		public void Hit(int healthPoints)
		{
			_sword.Hit(healthPoints);
		}

		public void Repair(int healthPoints)
		{
			_sword.Repair(healthPoints);
		}

		public void Reset()
		{
			_sword.Reset();
		}
	}
}