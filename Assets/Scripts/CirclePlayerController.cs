using UnityEngine;

public class CirclePlayerController : MonoBehaviour
{
    private const float Speed = 8f;
    private const float JumpingPower = 16f;
    private const float OverlapCircleRadius = 0.6f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    private float _horizontal;
    private Rigidbody2D _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        
        var velocity = _rb.velocity;
        if (Input.GetButtonDown("Jump") && IsPlayerGrounded())
        {
            _rb.velocity = new Vector2(velocity.x, JumpingPower);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(Speed * _horizontal, _rb.velocity.y);
    }

    private bool IsPlayerGrounded()
    { 
        return Physics2D.OverlapCircle(groundCheck.position, OverlapCircleRadius, groundLayer);
    }
    
}
