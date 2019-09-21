using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    public float speed;
    public GameObject mainUI;
    public GameObject gravestone;

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
        switch (other.tag)
        {
            case "Finish":
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                UIManager.FinishGame();
                this.enabled = false;
                break;
            case "Pick Up":
                other.gameObject.SetActive(false);
                UIManager.PickUp();
                break;
            case "Respawn":
                break;
            case "Death Zone":
                var gm = Instantiate(gravestone);
                gm.transform.position = this.gameObject.transform.position;
                this.gameObject.SetActive(false);
                UIManager.EndGame();
                break;
            default:
                break;
        }
    }

    #endregion
}
