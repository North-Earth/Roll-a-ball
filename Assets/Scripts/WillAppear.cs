using UnityEngine;

public class WillAppear : MonoBehaviour
{
    #region Fields

    public new GameObject gameObject;
    public bool isPlayerOnly;

    #endregion


    #region Methods

    private void OnTriggerEnter(Collider other)
    {
        if (isPlayerOnly)
        {
            if (other.tag == "Player")
            {
                gameObject.SetActive(true);
            }
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    #endregion
}
