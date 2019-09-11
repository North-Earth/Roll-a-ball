using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    #region Filds

    public Vector3 targetPosition;
    public float speed;
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

    #endregion
}
