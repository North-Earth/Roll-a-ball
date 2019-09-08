using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialCutscene : MonoBehaviour
{
    #region Fields

    private CameraController cameraController;
    private Vector3 offset;

    #endregion

    #region Methods

    private void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        offset = cameraController.GetOffset();

        Vector3 position = new Vector3(x: 0.0f, 2.5f, -3.0f);
        transform.localPosition = position;
    }

    private void LateUpdate()
    {
        Vector3 position = transform.localPosition;
        position.y += 0.1f;
        position.z -= 0.1f;

        transform.localPosition = position;

        if (position.y >= offset.y && position.z <= offset.z)
        {
            cameraController.isPlay = true;
            this.enabled = false;
        }
    }

    #endregion
}
