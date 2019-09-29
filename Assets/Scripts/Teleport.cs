using UnityEngine;

public class Teleport : MonoBehaviour
{
    #region Fields

    public Vector3 destination;

    #endregion


    #region Methods

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Player")
        //{
        //    other.gameObject.transform.position = destination;
        //}

        other.gameObject.transform.position = destination;
    }

    #endregion
}
