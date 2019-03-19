using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class MenuLaser : MonoBehaviour
{

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean touchInput;
    public SteamVR_Action_Vector2 touchDirectionInput;

    public RectTransform dictionaryScrollContent;

   
    public bool GetTrackpadTouched()
    {
        return touchInput.GetState(handType);
    }

    public Vector2 GetTouchDirection()
    {
        return touchDirectionInput.GetLastAxis(handType);
    }

   

    // Update is called once per frame
    void Update()
    {
        
        // Scrolling in the menu
        if (GetTrackpadTouched())
        {
            if (dictionaryScrollContent.gameObject.activeInHierarchy)
                ScrollScrollContent(dictionaryScrollContent);
           
        }

    }

    private void ScrollScrollContent(RectTransform scrollContent)
    {
        float currentPosY = scrollContent.GetComponent<RectTransform>().localPosition.y;
        float threshold = 0f;
        float yDirection = GetTouchDirection().y;
        float moveSpeed = 5f;

        float contentHeight = CalculateHeightOfContent(scrollContent);
        float mainPanelHeight = scrollContent.GetComponent<RectTransform>().rect.height;

        if (yDirection < -threshold && currentPosY + mainPanelHeight < contentHeight) // Down
        {
            scrollContent.transform.localPosition -= new Vector3(0f, moveSpeed * yDirection, 0f);
        }
        else if (yDirection > threshold && currentPosY > 0) // Up
        {
            scrollContent.transform.localPosition -= new Vector3(0f, moveSpeed * yDirection, 0f);
        }
    }



    private float CalculateHeightOfContent(RectTransform scrollContent)
    {
        float childHeight = scrollContent.GetChild(0).GetComponent<RectTransform>().rect.height;
        float paddingBottom = scrollContent.GetComponent<VerticalLayoutGroup>().padding.bottom;
        float paddingTop = scrollContent.GetComponent<VerticalLayoutGroup>().padding.top;
        return scrollContent.childCount * (childHeight) + paddingBottom + paddingTop;
    }

}
