﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public float speed;
    public Text countText;
    public Text winText;

    private CameraController cameraController;
	private Rigidbody rb;
    private int count;

	void Start ()
	{
        cameraController = Camera.main.GetComponent<CameraController>();

		rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();

        winText.text = string.Empty;

	}

	void FixedUpdate ()
	{
        if (cameraController.isPlay)
        {
		    float moveHorizontal = Input.GetAxis ("Horizontal");
		    float moveVertical = Input.GetAxis ("Vertical");

		    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		    rb.AddForce (movement * speed);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = $"Count: {count}";
        if (count >= 8 )
        {
            winText.text = "You Win!";
        }
    }
}
