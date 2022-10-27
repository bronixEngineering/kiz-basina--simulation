using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCanvasRotator : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0f, 0f));
    }
    
}
