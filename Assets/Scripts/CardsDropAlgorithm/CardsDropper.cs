using UnityEngine;

namespace CardsDropAlgorithm
{
	public class CardsDropper
	{
		private CardsContainer _cardsContainer;
		
		public CardsDropper(CardsContainer cardsContainer)
		{
			_cardsContainer = cardsContainer;
		}

		public CardData GetCard()
		{
			float randomValue = Random.Range(0f, _cardsContainer.MaxDropChnceValue);
			float currentChance = 0f;
			Card selectedCard;

			foreach (var cardRarityContainer in _cardsContainer.CardsRarities)
			{
				currentChance += cardRarityContainer.CardDropChance;
				if (randomValue <= currentChance)
				{
					selectedCard = cardRarityContainer.Cards[Random.Range(0, cardRarityContainer.Cards.Count)];
					return new CardData()
					{
						CardName = selectedCard.Name,
						Rarity = cardRarityContainer.CardRarity
					};
				}
			}

			var lastCardRarityContainer = _cardsContainer.CardsRarities[^1];
			selectedCard = lastCardRarityContainer.Cards[Random.Range(0, lastCardRarityContainer.Cards.Count)];
			return new CardData()
			{
				CardName = selectedCard.Name,
				Rarity = lastCardRarityContainer.CardRarity
			};
		}
	}
}