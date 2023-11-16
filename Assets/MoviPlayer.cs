using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MoviPlayer : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _moveX;
    [SerializeField] float _moveY;
    [SerializeField] float _jumpF;

    [SerializeField] bool _checkGround;
    [SerializeField] bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
       //rb.gravityScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _moveX = UnityEngine.Input.GetAxisRaw("Horizontal");
        _moveY = UnityEngine.Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector2(_moveX, _rb.velocity.y);
        //_rb.velocity = new Vector2(_moveX, _moveY);

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && _checkGround == true)
        {
            _rb.AddForce(new Vector2(0, _jumpF*10));
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
        if (collision.gameObject.name == "Ground")
        {
            _checkGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ground")
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
}
