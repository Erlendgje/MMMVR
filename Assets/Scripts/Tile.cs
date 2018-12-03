using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public Material emptyMaterial;

	public Material filledMaterial;

	public Renderer tileRenderer;

	public void SetState(bool newState)
	{
		switch (newState)
		{
		case true:
			if (tileRenderer != null && filledMaterial != null)
			{
				tileRenderer.sharedMaterial = filledMaterial;
			}
			break;
		case false:
			if (tileRenderer != null && emptyMaterial != null)
			{
				tileRenderer.sharedMaterial = emptyMaterial;
			}
			break;
		}
	}

}
