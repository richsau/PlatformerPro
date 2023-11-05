using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private float _speed = 9.0f;
    private float _gravity = 30.0f;
    private float _jumpHeight = 12.0f;
    private Vector3 _direction;
    private Vector3 _velocity;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    
    // speed
    // gravity
    // direction
    // jump height


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
        {
            Debug.LogError("Could not get CharacterController in Player.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if grounded, calculate movement direction based on input
        // if jump
        // adjust jump height
        // move

        float horizontalInput = Input.GetAxis("Horizontal");
        if (_characterController.isGrounded == true)
        {
            _direction = new Vector3(0, 0, horizontalInput); // get left-right input
            _velocity = _direction * _speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }
            _yVelocity -= _gravity * Time.deltaTime;
        }

        _velocity.y = _yVelocity;

        _characterController.Move(_velocity * Time.deltaTime);

    }
}
