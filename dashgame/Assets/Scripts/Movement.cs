using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float _maxSpeed = 20f;
    [SerializeField] float _speed = 0f;
    [SerializeField] float _speedBuildup = 2f;
    [SerializeField] private int _direction = 1;
    [SerializeField] float _jumpForce = 3f;
    [SerializeField] float _wallJumpForce = 1f;
    [SerializeField] float _slideForce = 10f;
    [SerializeField] bool _isgrounded = false;
    [SerializeField] bool _touchingWall = false;

    [SerializeField] InputAction _playerControls;

    private Transform _player;
    private Rigidbody2D _playerRB;
    [SerializeField] private ConstantForce2D _constantForce2D;

    private void OnEnable()
    {
        _playerControls.Enable();
    }
    private void OnDisable()
    {
        _playerControls.Disable();
    }
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = this.transform;
        _playerRB = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        WallJump();

    }

    

    private void FixedUpdate()
    {
        Move();
        
        
        //if(_touchingWall)
        //{
        //    _playerRB.linearVelocityY = _slideForce;
        //}
    }

    private void WallJump()
    {
        if (!_isgrounded && _touchingWall && _playerControls.triggered)
        {
            _direction = _direction * -1;
            _speed = _maxSpeed;
            _playerRB.AddForce(new Vector2(_wallJumpForce, _wallJumpForce), ForceMode2D.Impulse);

        }
    }

    private void Jump()
    {
        if (_playerControls.triggered && _isgrounded)
        {
            this.GetComponent<Rigidbody2D>().AddForceY(_jumpForce, ForceMode2D.Impulse);
            _isgrounded = false;
            Debug.Log("jump input pressed");
            
        }
    }

    private void Move()
    {
        _playerRB.linearVelocityX = _speed * _direction * Time.deltaTime;


        if (_speed < _maxSpeed && !_touchingWall)
        {
            _speed += _speedBuildup;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            _isgrounded = true;
            return;
        }
        if(collision.CompareTag("Wall"))
        {
            _touchingWall = true;
            _speed = 0;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            _isgrounded = false;
        }
        if(collision.CompareTag("Wall"))
        {
            _touchingWall = false;
        }
    }

}
