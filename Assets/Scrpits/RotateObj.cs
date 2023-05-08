using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    
    private void Start()
    {
        
    }
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 80,Space.Self);
        transform.Rotate(Vector3.left * Time.deltaTime * 40,Space.Self);
        transform.Rotate(Vector3.forward * Time.deltaTime * 80, Space.Self);
    }
}
