using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public float speed;

    private CameraController cameraController;
    private UIManager UI;
	private Rigidbody rb;

    private void Start()
	{
        cameraController = Camera.main.GetComponent<CameraController>();
        UI = cameraController.GetComponent<UIManager>();

        rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
	{
        if (cameraController.isPlay)
        {
		    float moveHorizontal = Input.GetAxis ("Horizontal");
		    float moveVertical = Input.GetAxis ("Vertical");

		    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		    rb.AddForce (movement * speed);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        UI.PickUp(other);
    }
}
