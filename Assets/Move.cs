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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        _moveX = UnityEngine.Input.GetAxisRaw("Horizontal");
    }
    void Jump()
    {
        _rb.AddForce(new Vector2(0, _jumpF * 10));
    }
}
