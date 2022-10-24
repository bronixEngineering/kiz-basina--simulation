using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ModelBehaviour : MonoBehaviour
{

    [SerializeField] private SkinnedMeshRenderer _modelMesh;
    [SerializeField] private SkinnedMeshRenderer _firstHandMesh;

    private void ModelScale()
    {
        transform.DOScale(Vector3.zero, 0.1f).OnComplete(() =>
        {
            _modelMesh.enabled = true;
            _modelMesh.shadowCastingMode = ShadowCastingMode.On;
            transform.DOScale(Vector3.one, 4f).SetEase(Ease.Linear);
        });
    }

    

    public void StartButtonInteracted()
    {
        _firstHandMesh.gameObject.SetActive(false);
        _firstHandMesh.shadowCastingMode = ShadowCastingMode.Off;
        ModelScale();
    }
}
