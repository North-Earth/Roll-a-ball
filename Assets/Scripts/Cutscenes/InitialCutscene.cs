using UnityEngine;

public class InitialCutscene : MonoBehaviour
{
    #region Fields

    public GameObject player;
    public float speed;

    private Vector3 cameraPosition;

    #endregion

    #region Methods

    private void Start()
    {
        SetEnableScripts(false);
        cameraPosition = Camera.main.transform.localPosition;
        transform.localPosition = player.transform.position;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, cameraPosition, step);

        if (transform.localPosition == cameraPosition)
        {
            SetEnableScripts(true);
            this.enabled = false;
        }
    }

    private void SetEnableScripts(bool enabled)
    {
        player.GetComponent<PlayerController>().enabled = enabled;
        this.GetComponent<CameraController>().enabled = enabled;
    }

    #endregion
}
