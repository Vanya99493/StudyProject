using StudyProj.Environment.Generator.States;
using UnityEngine;

namespace StudyProj.Environment.Generator
{
	public class GeneratorSwitcher : MonoBehaviour, IInteractable
	{
		[SerializeField] private Generator _generator;

		private bool _isGeneratorActive;

		public void Interact()
		{
			Switch();
		}
		
		public void Switch()
		{
			if (_isGeneratorActive)
			{
				_isGeneratorActive = false;
				_generator.SwitchState<WaitingState>();
			}
			else
			{
				_isGeneratorActive = true;
				_generator.SwitchState<ActiveState>();
			}
		}
	}
}