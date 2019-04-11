using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{

    private Material batteryMaterial;
    [SerializeField] public Material tabletMaterial;
    private Color color;
    public float speed;
    public float currentY;
    public float minY;
    private float t;

    private void Start()
    {
        batteryMaterial = GetComponent<MeshRenderer>().materials[1];
        batteryMaterial.SetFloat("_CurrentY", currentY);
        tabletMaterial.SetColor("_EmissionColor", Color.black);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "sciFiTablet_redWhite")
        {
            color = tabletMaterial.GetColor("_EmissionColor");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "sciFiTablet_redWhite")
        {
            
            batteryMaterial.SetFloat("_CurrentY", currentY);
            currentY -= Time.deltaTime * speed;

            color = Color.Lerp(color, new Vector4(0.0470588f, 1.294118f, 1.498039f, 0), Time.deltaTime * 0.2f);

            tabletMaterial.SetColor("_EmissionColor", color);
            
			if (currentY <= minY)
            {
				transform.GetComponent<Battery> ().enabled = false;
            }
        }
    }
}
