using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpF;
    [SerializeField] float _moveX;

    [SerializeField] bool _checkGround;
    [SerializeField] bool _checkIniciar;
    [SerializeField] bool isFacingRight;

    [SerializeField] Rigidbody2D _rb;

    [SerializeField] Vector2 _inputValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_checkIniciar == true)
        {
            Walk();
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && _checkGround == true)
        {
            Jump();
        }

        if (_moveX > 0 && isFacingRight == false)
        {
            Flip();
        }
        
        else if (_moveX < 0 && isFacingRight == true)
        {
            Flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _checkGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _checkGround = false;
        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        // Flip collider over the x-axis
    }
    void Walk()
    {
        _rb.velocity = new Vector2(_moveX * _speed, _rb.velocity.y);
    }
    void Control()
    {
        _inputValue.x = Input.GetAxisRaw("Horizontal") * _speed;
        _inputValue.y = _rb.velocity.y;
    }
    void Jump()
    {
        _rb.AddForce(new Vector2(0, _jumpF * 10));
    }
}
