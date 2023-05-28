using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; //
    public float rotationSpeed = 5f;
    public bool hasShield = false;
    public bool hasWings = false;
    public bool hasSpeed = false;
    public bool isSlowed = false;
    public bool isStunned = false;
    public GameObject shieldPrefab;
    public GameObject wingsPrefab;

    public Rigidbody rb;
    public float speedMultiplier = 1.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
{
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
    movement.Normalize();

    if (hasSpeed)
    {
        movement *= speedMultiplier;
    }

    if (movement.magnitude > 0.1f)
    {
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime / Time.timeScale);
    }

    movement.y = -9f; //Gravité

    rb.velocity = new Vector3(movement.x * speed, 0f, movement.z * speed);
}



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShieldBonus"))
        {
            hasShield = true;
            shieldPrefab.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("WingsBonus"))
        {
            hasWings = true;
            wingsPrefab.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("SlowBonus"))
        {
            hasWings = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("StunBonus"))
        {
            hasWings = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("SpeedBonus"))
        {
            hasSpeed = true;
            Destroy(other.gameObject);
        }
    }
}
