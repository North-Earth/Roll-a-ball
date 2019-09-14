using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    public float speed;
    public GameObject mainUI;

    private Rigidbody rb;
    private UIManager UIManager;

    #endregion

    #region Methods

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        UIManager = mainUI.GetComponent<UIManager>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick Up")
        {
            other.gameObject.SetActive(false);
            UIManager.PickUp();
        }
        else if (other.tag == "Finish")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            UIManager.FinishGame();
            this.enabled = false;
        }
        else if (other.tag == "Respawn")
        {
            UIManager.Restart();
        }
    }

    #endregion
}
