using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    Game_manager gm;
    public float speed = 10f;
    private float x, y;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Game_manager>();
        x = player.x;
        y = player.y;
    }

    private void Update()
    {

        if (x == 0 && y == 0)
        {
            rb.velocity = new Vector2(0, speed);
        }
        else rb.velocity = new Vector2(x, y) * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            Destroy(collision.gameObject);
            player.levelUp(1);
            Destroy(gameObject);
            gm.isRemoved = true;
        }
        
    }
}
