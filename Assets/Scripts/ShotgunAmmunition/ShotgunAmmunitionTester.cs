using System.Diagnostics;
using NaughtyAttributes;
using ShotgunAmmunition.PointsProvider;
using UnityEngine;

namespace ShotgunAmmunition
{
	public class ShotgunAmmunitionTester : MonoBehaviour
	{
		[SerializeField]
		private int _fractionsCount = 100;
		
		[Button("Start Test")]
		public void StartTest()
		{
			RuledCirclePointsDistributionProvider ruledCirclePointsDistributionProvider = new(_fractionsCount);
			CarrouselPointsDistributionProvider carrouselPointsDistributionProvider = new(_fractionsCount);
			
			Stopwatch sw = new();

			Vector2[] arr;
			sw.Start();
			arr = ruledCirclePointsDistributionProvider.GetDistribution();
			sw.Stop();
			UnityEngine.Debug.Log($"Length: {arr.Length};\nRuled: {sw.ElapsedMilliseconds}");
			
			sw.Reset();
			sw.Start();
			arr = carrouselPointsDistributionProvider.GetDistribution();
			sw.Stop();
			UnityEngine.Debug.Log($"Length: {arr.Length};\nCarrousel: {sw.ElapsedMilliseconds}");
		}
	}
}