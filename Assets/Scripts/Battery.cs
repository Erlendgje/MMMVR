using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{

    public Material batteryMaterial;
    public float speed;
    public float currentY;
    public float minY;


    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "sciFiTablet_redWhite")
        {
            if (currentY > minY)
            {
                batteryMaterial.SetFloat("_CurrentY", currentY);
                currentY -= Time.deltaTime * speed;
            }
            else
            {
                other.transform.GetComponent<OnTabletPickUp>().enabled = true;
            }
        }
    }
}
