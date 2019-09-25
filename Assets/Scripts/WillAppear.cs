using UnityEngine;

public class WillAppear : MonoBehaviour
{
    #region Fields

    public new GameObject gameObject;

    #endregion


    #region Methods

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(true);
        }
    }

    #endregion
}
