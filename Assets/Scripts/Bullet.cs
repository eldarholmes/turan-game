using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;

    public float speed = 10f;
    private float x, y;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        x = player.x;
        y = player.y;
        Debug.Log(x + " " + y);
    }

    private void Update()
    {

        if (x == 0 && y == 0)
        {
            rb.velocity = new Vector2(0, speed);
        }
        else rb.velocity = new Vector2(x, y) * speed;
    }
}
