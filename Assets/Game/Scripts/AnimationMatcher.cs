using System;
using System.Collections.Generic;
using UnityEngine;
namespace Scenes
{
	public class AnimationMatcher : MonoBehaviour
	{
		[SerializeField] private List<Transform> _sourceBones;
		[SerializeField] private List<Transform> _targetBones;

		private void Update()
		{
			for (int i = 0; i < _targetBones.Count; i++)
			{
				_targetBones[i].localRotation = _sourceBones[i].localRotation;

				if (_targetBones[i].name is "Left leg" or "Right leg")
				{
					_targetBones[i].localRotation *= Quaternion.Euler(0f, 180f, 0f);
				}
			}
		}
	}
}
