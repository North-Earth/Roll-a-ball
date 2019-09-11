using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    #region Fields

    public GameObject player;

    private Vector3 offset;

    #endregion

    #region Methods

    public Vector3 GetOffset() => offset;

    private void Awake()
    {
        offset = transform.position - player.transform.position;
    }

    private void Start()
    {

    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    #endregion
}