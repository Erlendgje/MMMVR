using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Observer : MonoBehaviour
{
    public UnityEvent onDetach;

    public void checkTask()
    {
        onDetach.Invoke();
    }
}
