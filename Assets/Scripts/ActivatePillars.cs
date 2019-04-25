using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePillars : MonoBehaviour
{

    [SerializeField] private GameObject task;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPickup()
    {
        task.SetActive(true);
    }
}
