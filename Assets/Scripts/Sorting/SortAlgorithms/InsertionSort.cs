namespace Sorting
{
	public class InsertionSort : SortAlgorithm<int>
	{
		public override int[] Sort(int[] array)
		{
			for (int i = 1; i < array.Length; i++)
			{
				for (int j = i; j > 0; j--)
				{
					if(array[j] < array[j - 1])
					{
						(array[j], array[j - 1]) = (array[j - 1], array[j]);
					}
					else
					{
						break;
					}
				}
			}
			
			return array;
		}
	}
}