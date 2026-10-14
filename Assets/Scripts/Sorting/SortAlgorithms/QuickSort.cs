namespace Sorting
{
	public class QuickSort : SortAlgorithm<int>
	{
		public override int[] Sort(int[] array)
		{
			return SortByPivot(array, 0, array.Length);
		}
		
		private int[] SortByPivot(int[] array, int left, int right)
		{
			if (right - left <= 1)
			{
				return array;
			}
			
			int pivotIndex = Partition(array, left, right);
			
			SortByPivot(array, left, pivotIndex);
			SortByPivot(array, pivotIndex + 1, right);
			
			return array;
		}

		private int Partition(int[] array, int left, int right)
		{
			int pivotIndex = right - 1;
			
			for (int i = left, j = i - 1; i < right; i++)
			{
				if (array[i] <= array[pivotIndex])
				{ 
					j++;
					(array[j], array[i]) = (array[i], array[j]);

					if (i == pivotIndex)
					{
						pivotIndex = j;
					}
				}
			}
			
			return pivotIndex;
		}
	}
}