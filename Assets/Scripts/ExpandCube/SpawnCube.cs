using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour {

	[SerializeField] GameObject cube;
	[SerializeField] int x, y, z = 10;

    private bool first = true;
    private bool reset;
    private bool spawning;

    public void buttonLogic()
    {
        if (!spawning && !reset)
        {
            spawning = true;
            StartCoroutine("spawnCubes", first);
        }
        else if (!spawning && !first && reset)
        {
            foreach (Rigidbody r in this.GetComponentsInChildren<Rigidbody>())
            {
                r.isKinematic = false;
            }
            reset = false;
        }
    }

    private IEnumerator spawnCubes(bool first)
    {
        for (int i = 0; i < x; i++)
        {
            for (int k = 0; k < y; k++)
            {
                for (int l = 0; l < z; l++)
                {
                    if (first)
                    {
                        Instantiate(cube, this.transform).transform.localPosition = new Vector3(l * 0.101f, i * 0.101f, k * 0.101f);
                    }
                    else
                    {
                        transform.GetChild(i * 100 + k * 10 + l).transform.localPosition = new Vector3(l * 0.101f, i * 0.101f, k * 0.101f);
                        transform.GetChild(i * 100 + k * 10 + l).transform.localRotation = Quaternion.Euler(0, 0, 0);
                        transform.GetChild(i * 100 + k * 10 + l).GetComponent<Rigidbody>().isKinematic = true;
                    }
                    
                    yield return new WaitForSeconds(0.01f);
                }
            }
        }
        spawning = false;
        this.first = false;
        reset = true;
    }
}
