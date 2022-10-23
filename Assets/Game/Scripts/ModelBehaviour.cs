using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class ModelBehaviour : MonoBehaviour
{
    private void Start()
    {
        transform.DOScale(Vector3.zero, 0.1f);
    }
    public void InitializeCharacter()
    {
        transform.DOScale(Vector3.one, 3f);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            InitializeCharacter();
        }
            
    }
}
