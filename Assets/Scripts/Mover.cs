using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    #region Filds

    public GameObject Player;

    public Vector3 targetPosition;
    public float speed = 5;
    public bool isRepeat;


    private Vector3 startingPosition;
    private bool isFlip;

    #endregion

    #region Methods

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        Vector3 currentPositin = transform.position;
        float step = speed * Time.deltaTime;

        if (isRepeat && (currentPositin == startingPosition || currentPositin == targetPosition))
        {
            isFlip = !isFlip;
        }

        if (!isFlip)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.parent = transform;    
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.parent = null;
        }
    }
    #endregion
}
