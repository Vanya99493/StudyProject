using System.Threading.Tasks;

namespace AIIntegration.Test
{
	public class GeminiWordsGenerator
	{
		private readonly IRequester _requester;

		public GeminiWordsGenerator(string apiUrl, string apiKey, string topic, char splitSymbol)
		{
			_requester = new GeminiRequester(apiUrl, apiKey, topic, splitSymbol);
		}
		
		public string[] GetWords(int wordsCount)
		{
			string requestResultString = RequestWordsAsync(wordsCount).Result;

			return requestResultString.Split(',');
		}

		private async Task<string> RequestWordsAsync(int wordsCount)
		{
			return await _requester.RequestWords(wordsCount);
		}
	}
}