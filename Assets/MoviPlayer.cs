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
    [SerializeField] bool _checkIniciar;

    // Start is called before the first frame update
    void Start()
    {
       //rb.gravityScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_checkIniciar == true) // andar: _rb.velocity = new Vector2(_moveX * _speed, _rb.velocity.y);
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
                                                                //LINHA 36 A 44, MOVIMENTO DE DIREITA 1 E ESQUERDA -1 DO PERSONAGEM
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
        Control();
        
        _rb.velocity = new Vector2(_moveX * _speed, _rb.velocity.y);
    }
    void Control()
    {
        _moveX = UnityEngine.Input.GetAxisRaw("Horizontal");

        _moveY = UnityEngine.Input.GetAxisRaw("Vertical");
    }
    void Jump()
    {
        _rb.AddForce(new Vector2(0, _jumpF * 10));
    }
}
