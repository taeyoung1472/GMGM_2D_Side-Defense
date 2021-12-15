using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isGround;
    float jumpForce, curSpeed;
    Rigidbody2D rb;
    SpriteRenderer renderer;
    [SerializeField] private Vector2 moveDir;
    [SerializeField] private Transform hand;
    [SerializeField] private float speed, runSpeed;
    void Start()
    {
        curSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Rotation();
        Move();
        CheckInput();
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            curSpeed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            curSpeed = speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            moveDir.y = 1;
            isGround = true;
        }
    }
    public void Jump()
    {
        if (isGround)
        {
            isGround = false;
            moveDir.y = 10;
        }
    }
    public void Move()
    {
        moveDir.x = Input.GetAxis("Horizontal") * curSpeed;
        if (!isGround)
        {
            moveDir.y -= Time.deltaTime * rb.gravityScale;
        }
        else
        {
            moveDir.y = 1;
        }
        rb.velocity = moveDir;
    }
    public void Rotation()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - hand.position.y, mousePos.x - hand.position.x) * Mathf.Rad2Deg;
        hand.eulerAngles = new Vector3(0,0,angle);
        if(angle < 90 && angle > -90)
        {
            renderer.flipX = false;
        }
        else
        {
            renderer.flipX = true;
        }
    }
}
