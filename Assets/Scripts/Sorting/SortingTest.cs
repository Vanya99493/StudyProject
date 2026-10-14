using System;
using NaughtyAttributes;
using UnityEngine;

namespace Sorting
{
	public class SortingTest : MonoBehaviour
	{
		private static int[][] testArrays =
		{
			new[] { 5, 3, 8, 1, 2 },
			new[] { 9, 7, 4, 2 },
			new[] { 1, 2, 3, 4, 5 },
			new[] { 8, 6, 4, 2, 0 },
			new[] { 3 },
			Array.Empty<int>(),
			new[] { 5, 5, 2, 2, 1 },
			new[] { -5, 10, -2, 0, 7 },
			new[] { 100, 1 },
			new[] { 9, 3, 7, 1, 8, 2, 6 },
			new[] { 2, 2 },
		};

		[Button("Bubble Sort")]
		public void StartBubbleSortTest() => StartSortTest(new BubbleSort());
		
		[Button("Selection Sort")]
		public void StartSelectionSortTest() => StartSortTest(new SelectionSort());
		
		[Button("Insertion Sort")]
		public void StartInsertionSortTest() => StartSortTest(new InsertionSort());
		
		[Button("Merge Sort")]
		public void StartMergeSortTest() => StartSortTest(new MergeSort());

		private void StartSortTest(SortAlgorithm<int> algorithm)
		{
			foreach (var testArray in testArrays)
			{
				int[] array = testArray.Clone() as int[];
				LogArray($"{algorithm.GetType()}: Initial array", array);
				
				array = algorithm.Sort(array);
				LogArray($"{algorithm.GetType()}: Sorted array", array);
				
				Debug.Log("-------------");
			}
		}

		private void LogArray(string message, int[] array)
		{
			string result = $"{{ {string.Join(", ", array)} }}";
			Debug.Log($"{message}: {result}");
		}
	}
}