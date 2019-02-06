using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatform : MonoBehaviour
{


    [SerializeField] public Vector3 platformEndPosition;
    [SerializeField] public Vector3 playerEndPosition;
    private Vector3 platformStartPosition;

    void Start()
    {
        platformStartPosition = transform.position;
    }

    public void MovePlatform()
    {
        transform.localPosition = platformEndPosition;
        Debug.Log(transform.localPosition.y);
        teleportPlayer(playerEndPosition);
    }

    private void teleportPlayer(Vector3 position)
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = position;
    }

}


