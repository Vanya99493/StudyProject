using System.Collections.Generic;
using UnityEngine;

namespace ShotgunAmmunition.PointsProvider
{
	public class CarrouselPointsDistributionProvider : CirclePointsDistributionProvider
	{
		private const int SECTORS_COUNT = 8;
		
		private readonly int _fractionsCount;

		public CarrouselPointsDistributionProvider(int fractionsCount)
		{
			_fractionsCount = fractionsCount;
		}
		
		public override Vector2[] GetDistribution()
		{
			List<Vector2> points = new List<Vector2>(_fractionsCount);

			float angleStep = 360f / SECTORS_COUNT;
			int pointsPerSector = Mathf.CeilToInt((float)_fractionsCount / SECTORS_COUNT);

			for (int s = 0; s < SECTORS_COUNT; s++)
			{
				float startAngle = s * angleStep;
				float endAngle = (s + 1) * angleStep;

				for (int i = 0; i < pointsPerSector; i++)
				{
					float r = Mathf.Sqrt(Random.value);
					float angle = Random.Range(startAngle, endAngle) * Mathf.Deg2Rad;

					Vector2 point = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * r;
					points.Add(point);

					if (points.Count >= _fractionsCount)
					{
						return points.ToArray();
					}
				}
			}

			return points.ToArray();
		}
	}
}