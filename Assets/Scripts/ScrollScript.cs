using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{

    public RectTransform dictionaryScrollContent;
    private static bool isTriggered;
    [SerializeField] private bool isOnTop;
    [SerializeField] private float scrollLenght;


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "GameController")
        {
            if (isTriggered)
            {
                if (isOnTop) {
                    dictionaryScrollContent.localPosition -= new Vector3(scrollLenght, 0f, 0f);
                } else
                {
                    dictionaryScrollContent.localPosition += new Vector3(scrollLenght, 0f, 0f);
                }
                isTriggered = false;
            }
            else
            {
                isTriggered = true;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }

}
