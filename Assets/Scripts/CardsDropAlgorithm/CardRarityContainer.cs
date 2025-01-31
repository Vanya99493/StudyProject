using System;
using System.Collections.Generic;

namespace CardsDropAlgorithm
{
	[Serializable]
	public class CardRarityContainer
	{
		public CardRarity CardRarity;
		public float CardDropChance;
		public List<Card> Cards;
	}
}