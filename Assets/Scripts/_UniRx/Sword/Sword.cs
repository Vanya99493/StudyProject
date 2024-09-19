using UniRx;
using UnityEngine;

namespace _UniRx.SwordModule
{
	public class Sword
	{
		public ReactiveProperty<int> CurrentHealthPoints = new();
		
		public int MaxHealthPoints { get; private set; }

		public void Initialize(int currentHealthPoints)
		{
			CurrentHealthPoints.Value = currentHealthPoints;
			MaxHealthPoints = currentHealthPoints;
		}
		
		public void Hit(int healthPoints)
		{
			CurrentHealthPoints.Value = Mathf.Max(CurrentHealthPoints.Value - healthPoints, 0);
		}

		public void Repair(int healthPoints)
		{
			CurrentHealthPoints.Value = Mathf.Min(CurrentHealthPoints.Value + healthPoints, MaxHealthPoints);
		}

		public void Reset()
		{
			CurrentHealthPoints.Value = MaxHealthPoints;
		}
	}
}