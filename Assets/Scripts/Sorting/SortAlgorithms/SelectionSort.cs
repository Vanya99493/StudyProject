namespace Sorting
{
	public class SelectionSort : SortAlgorithm<int>
	{
		public override int[] Sort(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				int minimalNumberIndex = -1;
				
				for (int j = i; j < array.Length; j++)
				{
					if (array[j] < array[minimalNumberIndex])
					{
						minimalNumberIndex = j;
					}
				}
				
				(array[i], array[minimalNumberIndex]) = (array[minimalNumberIndex], array[i]);
			}

			return array;
		}
	}
}