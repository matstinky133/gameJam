using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float _maxSpeed = 20f;
    [SerializeField] float _speed = 0f;
    [SerializeField] float _speedBuildup = 2f;
    [SerializeField] private int _direction = 1;
    [SerializeField] float _jumpForce = 3f;

    [SerializeField] InputAction _jumpAction;

    private Transform _player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(_jumpAction.triggered)
        {
            this.GetComponent<Rigidbody2D>().AddForceY(_jumpForce);
            Debug.Log("jump input pressed");
        }

    }

    private void Move()
    {
        _player.position = new Vector3(_player.position.x + (_speed * _direction * Time.deltaTime), _player.position.y, _player.position.z);
        if (_speed < _maxSpeed)
        {
            _speed += _speedBuildup * Time.deltaTime;
        }
    }
}
