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
    [SerializeField] private GameObject _firstHand;

    private void ModelScale()
    {
        _modelMesh.enabled = true;
        _modelMesh.shadowCastingMode = ShadowCastingMode.Off;
    }

    

    public void StartButtonInteracted()
    {
        _firstHand.gameObject.SetActive(false);
        ModelScale();
    }
}
