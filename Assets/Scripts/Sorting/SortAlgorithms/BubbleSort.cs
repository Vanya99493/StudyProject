namespace Sorting
{
	public class BubbleSort : SortAlgorithm<int>
	{
		public override int[] Sort(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				bool isSwapped = false;
				
				for (int j = 1; j < array.Length - i; j++)
				{
					if (array[j - 1] > array[j])
					{
						(array[j], array[j - 1]) = (array[j - 1], array[j]);
						isSwapped = true;
					}
				}
				
				if (!isSwapped)
				{
					break;
				}
			}

			return array;
		}
	}
}