using System.Collections.Generic;
using UnityEngine;

namespace CardsDropAlgorithm
{
	[CreateAssetMenu(fileName = "CardsContainer", menuName = "TheGloryHunter/Configs/Cards/CardsContainer")]
	public class CardsContainer : ScriptableObject, ISerializationCallbackReceiver
	{
		[Header("Config settings")]
		public float MaxDropChnceValue = 100f;
		
		[Space(10)]
		[Header("Data")]
		public List<CardRarityContainer> CardsRarities = new ();
		
		#region SerializationCallback
		
		public void OnBeforeSerialize() {}

		public void OnAfterDeserialize()
		{
			if (CardsRarities.Count == 0)
			{
				return;
			}

			float currentGlobalRarity = 0f;
			float lastGlobalRarity = 0f;
			int index = 0;
			foreach (var cardsRarity in CardsRarities)
			{
				if (index == CardsRarities.Count - 1)
				{
					CardsRarities[^1].CardDropChance = MaxDropChnceValue - currentGlobalRarity;
					return;
				}
				
				currentGlobalRarity += cardsRarity.CardDropChance;
				
				if (currentGlobalRarity > MaxDropChnceValue)
				{
					cardsRarity.CardDropChance = MaxDropChnceValue - lastGlobalRarity;
					currentGlobalRarity = MaxDropChnceValue;
				}

				index++;
				lastGlobalRarity = currentGlobalRarity;
			}
		}
		
		#endregion
	}
}