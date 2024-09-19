using UnityEngine;

namespace StudyProj.Environment
{
	[RequireComponent(typeof(MeshRenderer))]
	public class MaterialChanger : MonoBehaviour, IRayInteractable
	{
		[SerializeField] private Material _outlineMaterial;
		[SerializeField] private MeshRenderer _meshRenderer;

		private int _outlineMaterialIndex;
		private bool _isActive;

		public bool IsActive => _isActive;

		private void Awake()
		{
			_meshRenderer ??= GetComponent<MeshRenderer>();
		}

		public void Activate()
		{
			Material[] newMaterialsArray = new Material[_meshRenderer.materials.Length + 1];
			for (int i = 0; i < _meshRenderer.materials.Length; i++)
			{
				newMaterialsArray[i] = _meshRenderer.materials[i];
			}

			newMaterialsArray[newMaterialsArray.Length - 1] = _outlineMaterial;
			_meshRenderer.materials = newMaterialsArray;

			_isActive = true;
		}

		public void Deactivate()
		{
			Material[] newMaterialsArray = new Material[_meshRenderer.materials.Length - 1];
			int materialIndex = 0;
			for (int i = 0; i < _meshRenderer.materials.Length; i++)
			{
				if (!AreMaterialsEqual(_meshRenderer.materials[i], _outlineMaterial))
				{
					newMaterialsArray[materialIndex] = _meshRenderer.materials[i];
					materialIndex++;
				}
			}

			_meshRenderer.materials = newMaterialsArray;

			_isActive = false;
		}

		private bool AreMaterialsEqual(Material firstMaterial, Material secondMaterial)
		{
			if (firstMaterial.shader != secondMaterial.shader) return false;
			if (firstMaterial.mainTexture != secondMaterial.mainTexture) return false;
			if (firstMaterial.color != secondMaterial.color) return false;

			return true;
		}
	}
}