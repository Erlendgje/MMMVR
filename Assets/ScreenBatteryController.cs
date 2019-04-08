using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBatteryController : MonoBehaviour
{
    public GameObject battery;
    public Animator animator;

    private float currentLinearMapping = float.NaN;
    private int framesUnchanged = 0;


    //-------------------------------------------------
    void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        animator.speed = 0.0f;

        if (battery == null)
        {
            
        }
    }


    //-------------------------------------------------
    void Update()
    {
        if (true) //currentLinearMapping != linearMapping.value)
        {
            //currentLinearMapping = linearMapping.value;
            animator.enabled = true;
            //animator.Play(0, 0, currentLinearMapping);
            framesUnchanged = 0;
        }
        else
        {
            framesUnchanged++;
            if (framesUnchanged > 2)
            {
                animator.enabled = false;
            }
        }
    }
}
