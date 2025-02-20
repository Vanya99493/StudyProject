using System.Threading.Tasks;

namespace AIIntegration.Test
{
	public interface IRequester
	{
		Task<string> RequestWords(int wordsCount);
	}
}