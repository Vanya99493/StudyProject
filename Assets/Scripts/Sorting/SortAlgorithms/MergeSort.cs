namespace Sorting
{
	public class MergeSort : SortAlgorithm<int>
	{
		public override int[] Sort(int[] array)
		{
			return Divide(array, 0, array.Length / 2, array.Length);
		}

		private int[] Divide(int[] array, int left, int middle, int right)
		{
			if (right - left > 1)
			{
				Divide(array, left, left + (middle - left) / 2, middle);
				Divide(array, middle, middle + (right - middle) / 2, right);
				
				return Merge(array, left, middle, right);
			}
			
			return array;
		}

		private int[] Merge(int[] array, int left, int middle, int right)
		{
			int[] mergedArray = new int[right - left];
			
			int firstPartIndex = left;
			int secondPartIndex = middle;
			
			for (int i = 0; i < mergedArray.Length; i++)
			{
				if (secondPartIndex == right
				    || (firstPartIndex != middle
						&& array[firstPartIndex] <= array[secondPartIndex]))
				{
					mergedArray[i] = array[firstPartIndex++];
				}
				else if (firstPartIndex == middle
				         || (secondPartIndex != right
				             && array[secondPartIndex] <= array[firstPartIndex]))
				{
					mergedArray[i] = array[secondPartIndex++];
				}
			}

			int indexer = left;
			for (int i = 0; i < mergedArray.Length; i++)
			{
				array[indexer++] = mergedArray[i];
			}
			
			return array;
		}
	}
}