using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ExpandLine : MonoBehaviour {

    enum dimension { x, y, z };
    private List<string[]> planes;
    private List<int[]> meshDimensions;

    [SerializeField] private GameObject text;
    [SerializeField] private Transform handle1;
    [SerializeField] private Transform handle2;
    [SerializeField] private Transform cube;
    [SerializeField] dimension myDimension;
    [SerializeField] bool d3;
    private Vector3 position, scale;

    public bool isAttached;
	public bool go;

    private void Start()
    {

        planes = new List<string[]> { new string[] { "PlaneY", "PlaneZ" }, new string[] { "PlaneX", "PlaneZ" }, new string[] { "PlaneX", "PlaneY" } };
        meshDimensions = new List<int[]> { new int[] { 0, 0 }, new int[] {0, 1 }, new int[] { 1, 1 } };

        onAttach();
        onDetach();
    }

	public void Update() {
		if(isAttached && go) {
			StartCoroutine(changeSize());
			go = false;
		}
	}

	public void onAttach()
    {
        isAttached = true;
        StartCoroutine(changeSize());
    }

    public void onDetach()
    {
        isAttached = false;
    }

    private IEnumerator changeSize()
    {
        while (isAttached)
        {
            switch (myDimension)
            {
                case dimension.x:
                    changeCube(0);
                    break;
                case dimension.y:
                    changeCube(1);
                    break;
                case dimension.z:
                    changeCube(2);
                    break;
            }

            yield return null;
        }
        
    }


    private void changeCube(int index)
    {
		
        Vector3 scale = cube.transform.localScale;
		float negative = this.transform.localPosition[index] / Mathf.Abs(this.transform.localPosition[index]);
        scale[index] = Mathf.Floor(Mathf.Abs(this.transform.localPosition[index]) * 10f) / 10;
		cube.transform.localScale = scale;


		Vector3 position = text.transform.localPosition;
        position[index] = scale[index] / 2 * negative;
        text.transform.localPosition = position;

        Vector3 handle1Position = handle1.localPosition;
        handle1Position[index] = scale[index] / 2 * negative;
        handle1.localPosition = handle1Position;

        Vector3 handle2Position = handle2.localPosition;
        handle2Position[index] = scale[index] / 2 * negative;
        handle2.localPosition = handle2Position;

		text.GetComponent<TextMesh>().text = scale[index] * 10 + "dm";


        if (d3)
        {

            for(int i = 0; i < planes[index].Length; i++){
                
                foreach(MeshRenderer mr in cube.Find(planes[index][i]).GetComponentsInChildren<MeshRenderer>())
                {
                    Vector2 test = mr.material.mainTextureScale;
                    test[meshDimensions[index][i]] = scale[index] * 10 + 0.05f;
					mr.material.mainTextureScale = test;
                }
            }
        }
        else
        {
            cube.GetComponentInChildren<MeshRenderer>().material.mainTextureScale = new Vector2(scale[0] * 10 + 0.05f, scale[1] * 10 + 0.05f);
        }

    }

    /*
	[SerializeField] private GameObject text;
	[SerializeField] private LinearMapping lm;
	[SerializeField] private Transform handle1;
	[SerializeField] private Transform handle2;
	[SerializeField] private Transform background;
	[SerializeField] private bool x, y, z, d3;

	private Vector3 starPosition;
	private MeshRenderer mr;

	// Use this for initialization
	void Start () {
		starPosition = text.transform.localPosition;
		if(!d3) {
			mr = background.GetComponentInChildren<MeshRenderer>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(x) {
			if(d3) {
                foreach (MeshRenderer meshRenderer in background.Find("PlaneZ").GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material.mainTextureScale = new Vector2((float)System.Math.Round(lm.value * 2 - 0.05f, 1) + 0.005f, meshRenderer.material.mainTextureScale.y);
                }

                foreach (MeshRenderer meshRenderer in background.Find("PlaneY").GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material.mainTextureScale = new Vector2((float)System.Math.Round(lm.value * 2 - 0.05f, 1) + 0.005f, meshRenderer.material.mainTextureScale.y);
                }
            }
			else {
				mr.material.mainTextureScale = new Vector2((float)System.Math.Round(lm.value * 2 - 0.05f, 1) + 0.005f, mr.material.mainTextureScale.y);
			}
            Debug.Log(this.transform.localPosition.x - 0.05f);
			background.localScale = new Vector3((float)System.Math.Round(this.transform.localPosition.x - 0.05f, 1), background.localScale.y, background.localScale.z);
			text.transform.localPosition = new Vector3(this.transform.localPosition.x / 2, starPosition.y, starPosition.z);
			handle1.localPosition = new Vector3(text.transform.localPosition.x, handle1.localPosition.y, handle1.localPosition.z);
			handle2.localPosition = new Vector3(text.transform.localPosition.x, handle2.localPosition.y, handle2.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Floor((lm.value * 2 * 10)) + "dm";
		}

		if(y) {
			if(d3) {
                foreach (MeshRenderer meshRenderer in background.Find("PlaneX").GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material.mainTextureScale = new Vector2((float)System.Math.Round(lm.value * 2 - 0.05f, 1) + 0.005f, meshRenderer.material.mainTextureScale.y);
                }
                foreach (MeshRenderer meshRenderer in background.Find("PlaneZ").GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material.mainTextureScale = new Vector2(meshRenderer.material.mainTextureScale.x, (float)System.Math.Round((lm.value * 2 - 0.05f), 1) * 10 + 0.005f * 10);
                }
            }
			else {
				mr.material.mainTextureScale = new Vector2(mr.material.mainTextureScale.x, (float)System.Math.Round((lm.value * 2 - 0.05f), 1) * 10 + 0.005f * 10);
			}
			background.localScale = new Vector3(background.localScale.x, (float)System.Math.Round(Mathf.Abs(this.transform.localPosition.y) - 0.05f, 1), background.localScale.z);
			text.transform.localPosition = new Vector3(starPosition.x, this.transform.localPosition.y / 2, starPosition.z);
			handle1.localPosition = new Vector3(handle1.localPosition.x, text.transform.localPosition.y, handle1.localPosition.z);
			handle2.localPosition = new Vector3(handle2.localPosition.x, text.transform.localPosition.y, handle2.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Floor(lm.value * 2 * 10) + "dm";
		}

		if(z) {
			if(d3) {
                foreach (MeshRenderer meshRenderer in background.Find("PlaneX").GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material.mainTextureScale = new Vector2(meshRenderer.material.mainTextureScale.x, (float)System.Math.Round((lm.value * 2 - 0.05f), 1) * 10 + 0.005f * 10);
                }

                foreach (MeshRenderer meshRenderer in background.Find("PlaneY").GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material.mainTextureScale = new Vector2(meshRenderer.material.mainTextureScale.x, (float)System.Math.Round((lm.value * 2 - 0.05f), 1) * 10 + 0.005f * 10);
                }
            }
			background.localScale = new Vector3(background.localScale.x, background.localScale.y, (float)System.Math.Round(this.transform.localPosition.x - 0.05f, 1));
			text.transform.localPosition = new Vector3(starPosition.x, starPosition.y, -this.transform.localPosition.x / 2);
			handle1.localPosition = new Vector3(handle1.localPosition.x, handle1.localPosition.y, text.transform.localPosition.z);
			handle2.localPosition = new Vector3(handle2.localPosition.x, handle2.localPosition.y, text.transform.localPosition.z);
			text.GetComponent<TextMesh>().text = System.Math.Floor(lm.value * 2 * 10) + "dm";
		}
	}
    */
}
