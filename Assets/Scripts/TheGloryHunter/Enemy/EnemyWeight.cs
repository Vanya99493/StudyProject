using System;

namespace TheGloryHunter
{
	[Serializable]
	public class EnemyWeight : IComparable<EnemyWeight>
	{
		public int Weight;
		public EnemyData EnemyData;

		public int CompareTo(EnemyWeight other)
		{
			return Weight.CompareTo(other.Weight);
		}
	}
}