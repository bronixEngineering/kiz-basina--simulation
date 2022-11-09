using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Game.Scripts
{
    public class ModelBehaviour : MonoBehaviour
    {

        [SerializeField] private List<SkinnedMeshRenderer> _modelMeshes;
        [SerializeField] private GameObject _firstHand;

        private void ModelScale()
        {
            foreach (var mesh in _modelMeshes)
            {
                mesh.enabled = true;
                mesh.shadowCastingMode = ShadowCastingMode.Off;
            }
            
        }

        public void StartButtonInteracted()
        {
            _firstHand.gameObject.SetActive(false);
            ModelScale();
        }
    }
}
