using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _speed = 3.0f;
    private bool _switching = false;
    private bool _moving = true;

    void FixedUpdate()
    {
        if (_switching == false)
        {
            if (_moving)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
            }
        }
        else if (_switching == true)
        {
            if (_moving)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
            }
        }

        if (transform.position == _targetB.position)
        {
            _switching = true;
            _moving = false;
            StartCoroutine(MovingPlatformCoolDown());
        }
        else if (transform.position == _targetA.position)
        {
            _switching = false;
            _moving = false;
            StartCoroutine(MovingPlatformCoolDown());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OnPlatform");
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OffPlatform");
            other.transform.parent = null;
        }
    }

    IEnumerator MovingPlatformCoolDown()
    {
        yield return new WaitForSeconds(2.0f);
        _moving = true;
    }
}
