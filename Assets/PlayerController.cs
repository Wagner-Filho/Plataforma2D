using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 _move;
    [SerializeField] Rigidbody2D _rigidbody;

    [SerializeField] float _speed;
    [SerializeField] float _jumpF;

    [SerializeField] bool _checkGround;
    [SerializeField] bool _isFacingRight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_move.x * _speed, _rigidbody.velocity.y);
        if (_move.x > 0 && _isFacingRight == true)
        {
            Flip();
        }
        else if (_move.x < 0 && _isFacingRight == false)
        {
            Flip();
        }
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector2>();
    }

    public void SetJump(InputAction.CallbackContext value)
    {
        if (_checkGround == true)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, 2 * _jumpF), ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        // Flip collider over the x-axis
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _checkGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _checkGround = false;
    }
}
