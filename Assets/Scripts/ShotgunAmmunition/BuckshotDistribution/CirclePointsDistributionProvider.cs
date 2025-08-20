using UnityEngine;

namespace ShotgunAmmunition.PointsProvider
{
	public abstract class CirclePointsDistributionProvider
	{
		public abstract Vector2[] GetDistribution();
	}
}