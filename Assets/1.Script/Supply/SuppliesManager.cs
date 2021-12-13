using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppliesManager : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    private bool isGround = false;
    void Update()
    {
        if(!isGround)
            gameObject.transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGround = true;
    }

    public void ClickSupplies()
    {
        Debug.Log("º¸±Þ È¹µæ");
        Destroy(gameObject);
    }
}
