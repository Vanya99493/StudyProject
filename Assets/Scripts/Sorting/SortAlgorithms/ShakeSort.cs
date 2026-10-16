namespace Sorting
{
	public class ShakeSort : SortAlgorithm<int>
	{
		public override int[] Sort(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				 bool isSwapped = false;
				
				for (int j = i + 1; j < array.Length - i; j++)
				{
					if (array[j - 1] > array[j])
					{
						(array[j], array[j - 1]) = (array[j - 1], array[j]);
						isSwapped = true;
					}
				}

				for (int k = array.Length - 1 - (i + 1); k > i; k--)
				{
					if (array[k - 1] > array[k])
					{
						(array[k], array[k - 1]) = (array[k - 1], array[k]);
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