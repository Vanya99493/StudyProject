using NaughtyAttributes;
using UnityEngine;

namespace CardsDropAlgorithm
{
	public class _TestCardsDropAlgorithm: MonoBehaviour
	{
		[SerializeField] private CardsContainer _cardsContainer;
		
		private CardsDropper _cardsDropper;

		private void Awake()
		{
			_cardsDropper = new CardsDropper(_cardsContainer);
		}

		[Button]
		public void CalculateChance()
		{
			var cardData = _cardsDropper.GetCard();
			Debug.Log($"{cardData.CardName} (rarity: {cardData.Rarity})");
		}
	}
}