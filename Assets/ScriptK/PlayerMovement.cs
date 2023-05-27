using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; //
    public float rotationSpeed = 5f;
    public bool hasShield = false;
    public bool hasWings = false;
    public bool hasSpeed = false;
    public bool hasExplosive = false;
    public bool canThrow = false;
    public bool hasRange = false;
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

    movement.y = 0f; // Set the Y component to zero

    rb.velocity = new Vector3(movement.x * speed, 0f, movement.z * speed);
}



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShieldBonus"))
        {
            hasShield = true;
            shieldPrefab.SetActive(true);
            // Additional actions when collecting the shield bonus
            // For example, you can disable the collider or the bonus object itself
            Destroy(other.gameObject);
        }
        if (other.CompareTag("WingsBonus"))
        {
            hasWings = true;
            wingsPrefab.SetActive(true);
            // Additional actions when collecting the shield bonus
            // For example, you can disable the collider or the bonus object itself
            Destroy(other.gameObject);
        }
        if (other.CompareTag("RangeBonus"))
        {
            hasRange = true;
            // Additional actions when collecting the shield bonus
            // For example, you can disable the collider or the bonus object itself
            Destroy(other.gameObject);
        }
        if (other.CompareTag("ThrowBonus"))
        {
            canThrow = true;
            // Additional actions when collecting the shield bonus
            // For example, you can disable the collider or the bonus object itself
            Destroy(other.gameObject);
        }
        if (other.CompareTag("ExplosiveBonus"))
        {
            hasExplosive = true;
            // Additional actions when collecting the shield bonus
            // For example, you can disable the collider or the bonus object itself
            Destroy(other.gameObject);
        }
        if (other.CompareTag("SlowBonus"))
        {
            hasWings = true;
            // Additional actions when collecting the shield bonus
            // For example, you can disable the collider or the bonus object itself
            Destroy(other.gameObject);
        }
        if (other.CompareTag("StunBonus"))
        {
            hasWings = true;
            // Additional actions when collecting the shield bonus
            // For example, you can disable the collider or the bonus object itself
            Destroy(other.gameObject);
        }
        if (other.CompareTag("SpeedBonus"))
        {
            hasSpeed = true;
            // Additional actions when collecting the shield bonus
            // For example, you can disable the collider or the bonus object itself
            Destroy(other.gameObject);
        }
    }
}
