using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialRotation : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    void Start()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(transform.localEulerAngles.x, -cameraTransform.localEulerAngles.y, transform.localEulerAngles.z));
    }
    
}

