using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviPlayer : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _moveX;
    [SerializeField] float _moveY;
    
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

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(new Vector2(0, 200));
        }
    }
}
