using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private Animator _anim;
    private bool _jumping = false;
    private bool _onLedge = false;
    private Ledge _activeLedge;
    private bool _onLadder = false;
    private bool _rolling = false;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
        {
            Debug.LogError("Could not get CharacterController in Player.");
        }

        _anim = GetComponentInChildren<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Could not get Animator in Player.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (_onLedge == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ClimbLedge();
            }
            if (_onLadder == true)
            {
                ClimbLedge();
            }
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (_onLadder == true)
        {
            _direction = new Vector3(0, verticalInput, 0);
            _yVelocity = 2 * _direction.y;
            _velocity = _direction * _speed;
            if (verticalInput > 0)
            {
                _anim.SetBool("ClimbLadder", true);
            }
            else
            {
                _anim.SetBool("ClimbLadder", false);
                _onLadder = false;
            }
        }
        
        if (_characterController.isGrounded == true)
        {
            _direction = new Vector3(0, 0, horizontalInput); // get left-right input
            if (horizontalInput != 0)
            {
                Vector3 facing = transform.localEulerAngles;
                facing.y = _direction.z > 0 ? 0 : 180;
                transform.localEulerAngles = facing;
            }
            _velocity = _direction * _speed;
            _anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
            if (_jumping == true)
            {
                _jumping = false;
                _anim.SetBool("Jump", _jumping);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _jumping = true;
                _anim.SetBool("Jump", _jumping);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _rolling = true;
                _anim.SetBool("Roll", _rolling);
            }

        }
        else
        {
            if (_onLadder == false)
            {
                _yVelocity -= _gravity * Time.deltaTime;
            }
        }

        _velocity.y = _yVelocity;
        if (_characterController.enabled == true)
        {
            _characterController.Move(_velocity * Time.deltaTime);
        }
        
    }

    public void ClimbLedge()
    {
        _anim.SetTrigger("ClimbUp");
    }

    public void GrabLedge(Vector3 handPos, Ledge currentLedge)
    {
        
        _characterController.enabled = false;  // freeze the player 
        _anim.SetBool("GrabLedge", true);
        _anim.SetFloat("Speed", 0.0f);
        _anim.SetBool("Jump", false);
        _onLedge = true;
        _activeLedge = currentLedge;
        transform.position = handPos;
    }


    public void GrabLadder()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (verticalInput > 0)
        {
            _onLadder = true;
        }
        else
        {
            _onLadder = false;
        }
    }

    public void ClimbUpComplete()
    {
        transform.position = _activeLedge.GetStandPos();
        _anim.SetBool("GrabLedge", false);
        _anim.SetBool("ClimbLadder", false);
        _onLadder = false;
        _characterController.enabled = true;  // un-freeze the player 
    }

    public void RollingComplete()
    {
        Debug.Log("Roll Done");
        _rolling = false;
        _anim.SetBool("Roll", _rolling);
    }
}
