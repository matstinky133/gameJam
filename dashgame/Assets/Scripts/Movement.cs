using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float _maxSpeed = 20f;
    [SerializeField] float _speed = 0f;
    [SerializeField] float _speedBuildup = 2f;
    [SerializeField] public int _direction = 1;
    [SerializeField] float _jumpForce = 3f;
    [SerializeField] float _wallJumpForce = 1f;
    [SerializeField] float _slideForce = 10f;
    [SerializeField] public bool _isgrounded = false;
    [SerializeField] public bool _touchingWall = false;

    private float _wallJumpCooldown = 0.3f;
    private float _wallJumpTimer = 0f;

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

        WallSlide();
        WallJump();
        Jump();
        if(_wallJumpTimer < _wallJumpCooldown)
        {
            _wallJumpTimer += Time.deltaTime;
        }

    }
    private void WallSlide()
    {
        if (!_isgrounded && _touchingWall && _playerRB.linearVelocityY < 0)
        {
            //_playerRB.AddRelativeForceY(_slideForce);

            _playerRB.linearVelocityY = _slideForce;
            //_speed = _maxSpeed;


        }
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
        if (!_isgrounded && _touchingWall && _playerControls.triggered && _wallJumpTimer >= _wallJumpCooldown)
        {
            _direction = _direction * -1;
            _speed = _maxSpeed;
            _playerRB.AddForce(new Vector2(_wallJumpForce, _wallJumpForce), ForceMode2D.Impulse);
            _wallJumpTimer = 0;

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
        _playerRB.linearVelocityX = _speed * _direction;


        if (_speed < _maxSpeed && !_touchingWall)
        {
            _speed += _speedBuildup;
        }

    }
    

}