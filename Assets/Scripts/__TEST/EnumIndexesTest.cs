using System.Collections.Generic;
using UnityEngine;

namespace __TEST
{
	public enum TestEnum
	{
		Value0 = 0,
		Value1,
		Value4 = 4,
		Value5,
		Value9 = 5,
		Value10,
	}
	
	public class EnumIndexesTest : MonoBehaviour
	{
		private List<TestEnum> enumList = new()
		{
			TestEnum.Value0,
			TestEnum.Value1,
			TestEnum.Value4,
			TestEnum.Value5,
			TestEnum.Value9,
			TestEnum.Value10,
		};
		
		private void Awake()
		{
			string str = "";
			foreach (var testEnum in enumList)
			{
				str += (int)testEnum + ", ";
			}
			Debug.Log(str); // 0, 1, 4, 5, 5, 6,
			
			Show((TestEnum)5);
		}

		private void Show(TestEnum value)
		{
			Debug.Log(value.ToString()); // Value9
		}
	}
}