using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GameManager : MonoBehaviour
{

	[SerializeField] private GameObject mathWorld;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean changeAction;

    public bool GetChangeScene()
    {
        return changeAction.GetLastStateDown(handType);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GetChangeScene())
        {
            print("KAKE");
        }
    }
}
