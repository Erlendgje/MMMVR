using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanvas : MonoBehaviour
{

    [SerializeField] List<Transform> positions;
    [SerializeField] float speed;
    private int position = 0;


    public void moveText()
    {
        position++;
        StartCoroutine("moveTowards");
    }


    private IEnumerator moveTowards()
    {

        while(this.transform.localPosition != positions[position].localPosition)
        {
            this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, positions[position].localPosition, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

    }
}
