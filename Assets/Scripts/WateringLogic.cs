using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WateringLogic : MonoBehaviour
{

	public UnityEvent onContainerInBox;
    [SerializeField] public int wantedValue;
    [SerializeField] public GameObject redLight = null;
	[SerializeField] public GameObject errorText = null;

    private Animator _animator;
    

	private List<Vector3> tankPositions = new List<Vector3>();
    private int totalValue = 0;


	void Start()
	{

        _animator = transform.Find("WateringDeviceDoor").GetComponent<Animator>();
        for (var i = 0; i < transform.childCount; i++) {
            
            tankPositions.Add(transform.GetChild(i).localPosition);
		}
	}


	protected virtual void OnTriggerEnter(Collider other)
	{
        //Debug.Log(other.name);
		errorText.SetActive (false);
        StartCoroutine(CloseDoor(other));

    }

    public void RespawnShapes()
    {
        var childCount = transform.childCount;


        for (var i = 0; i < childCount; i++) {

            //Debug.Log(tankPositions[i].ToString() + "hey");
            totalValue = 0;
            transform.GetChild(i).localPosition = tankPositions[i];
            transform.GetChild(i).localRotation = new Quaternion(0, 0, 0, 0);
            transform.GetChild (i).gameObject.SetActive (true);
            
        }
    }

    IEnumerator CloseDoor(Collider other)
    {
        int otherValue = 0;

        if (Int32.TryParse(other.name, out otherValue))
        {
            
            _animator.SetBool("open", true);
            

            yield return new WaitForSeconds(0.6f);
            

            totalValue += otherValue;
            if (totalValue == wantedValue)
            {
                onContainerInBox.Invoke();
            }

            other.gameObject.SetActive(false);

            yield return new WaitForSeconds(0.4f);

            _animator.SetBool("open", false);


            

            if (totalValue > wantedValue)
            {
                
				errorText.SetActive (true);
                redLight.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                redLight.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                redLight.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                redLight.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                redLight.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                RespawnShapes();
                redLight.SetActive(false);

            }
            

        }
    }


}