using System.Collections.Generic;
using UnityEngine;

namespace ShotgunAmmunition.PointsProvider
{
	public class RuledCirclePointsDistributionProvider : CirclePointsDistributionProvider
	{
		private const int MIN_SECTORS = 4;
		private const int MAX_SECTORS = 12;
		private const int MIN_RINGS = 2;
		private const int MAX_RINGS = 5;

		private readonly int _fractionsCount;

		public RuledCirclePointsDistributionProvider(int fractionsCount)
		{
			_fractionsCount = fractionsCount;
		}
		
		public override Vector2[] GetDistribution()
		{
			List<Vector2> fractions = new();

			int targetCount = _fractionsCount / 2;
			int bestSectors = MIN_SECTORS;
			int bestRings = MIN_RINGS;
			int bestDiff = int.MaxValue;

			bool isPerfectDiff = false;
			
			for (int sectors = MIN_SECTORS; sectors <= MAX_SECTORS; sectors++)
			{
				if (isPerfectDiff)
				{
					break;
				}
				
				for (int rings = MIN_RINGS; rings <= MAX_RINGS; rings++)
				{
					int cells = sectors * rings;
					int diff = Mathf.Abs(cells - targetCount);

					if (diff == 0)
					{
						bestSectors = sectors;
						bestRings = rings;
						isPerfectDiff = true;
						break;
					}

					if (diff < bestDiff)
					{
						bestDiff = diff;
						bestSectors = sectors;
						bestRings = rings;
					}
				}
			}
			
			float ringStep = 1f / bestRings;

			for (int ring = 0; ring < bestRings; ring++)
			{
				float innerRadius = ring * ringStep;
				float outerRadius = innerRadius + ringStep;

				for (int sector = 0; sector < bestSectors; sector++)
				{
					float startAngle = sector * (360f / bestSectors);
					float endAngle = (sector + 1) * (360f / bestSectors);

					float radius = Random.Range(innerRadius, outerRadius);
					float angle = Random.Range(startAngle, endAngle) * Mathf.Deg2Rad;

					Vector2 point = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
					fractions.Add(point);
				}
			}

			int remainingPellets = _fractionsCount - fractions.Count;

			for (int i = 0; i < remainingPellets; i++)
			{
				float radius = Random.value;
				float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

				fractions.Add(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius);
			}

			return fractions.ToArray();
		}
	}
}