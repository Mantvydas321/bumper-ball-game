using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody _rigidbody;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;
    
    // Speed at which the player moves.
    public float speed = 0;
    
    public GameObject winText;
    public GameObject loseText;
    public bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        _rigidbody = GetComponent<Rigidbody>();
        
        winText.SetActive(false);
        loseText.SetActive(false);
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movemntValue)
    {
        if (!isDead) 
        {
            // Convert the input value into a Vector2 for movement.
            Vector2 movementVector = movemntValue.Get<Vector2>();

            // Store the X and Y components of the movement.
            movementX = movementVector.x;
            movementY = movementVector.y;
        }
    }
    
    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        if (!isDead)
        {
            // Create a 3D movement vector using the X and Y inputs.
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);

            // Apply force to the Rigidbody to move the player.
            _rigidbody.AddForce(movement * speed);
        }
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("DeathColider")) 
        {
            if (!isDead)
            {
                isDead = true; 
                gameObject.SetActive(false);
                loseText.SetActive(true);
                winText.SetActive(false);
            }
        }
        
    }
}
