using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isGround;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    [SerializeField] private GunManager gunManager;
    [SerializeField] private Vector2 moveDir;
    [SerializeField] private Transform hand;
    [SerializeField] private float speed, hp, jumpForce;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    public void Update()
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
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground") || collision.transform.CompareTag("Object"))
        {
            moveDir.y = 0;
            isGround = true;
        }
    }
    public void Jump()
    {
        if (isGround)
        {
            isGround = false;
            moveDir.y = jumpForce;
        }
    }
    public void Move()
    {
        moveDir.x = Input.GetAxis("Horizontal") * speed;
        if (!isGround)
        {
            moveDir.y -= Time.deltaTime * rb.gravityScale;
        }
        else
        {
            moveDir.y = 0;
        }
        rb.velocity = moveDir;
    }
    public void GetDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Rotation()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - hand.position.y, mousePos.x - hand.position.x) * Mathf.Rad2Deg;
        hand.eulerAngles = new Vector3(0,0,angle);
        if(angle < 90 && angle > -90)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }
}
