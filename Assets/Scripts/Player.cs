using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float hp = 100f;
    private float speed = 5f;
    public float x, y;

    public Joystick joystick;

    Rigidbody2D rb;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        x = joystick.Direction.x;
        y = joystick.Direction.y;
        if (joystick.Direction.y != 0)
        {
            rb.velocity = new Vector2(joystick.Direction.x * speed, joystick.Direction.y * speed);
        }
        else rb.velocity = Vector2.zero;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, findAngle(joystick.Direction.x, -joystick.Direction.y)));
        
    }

    private float findAngle(float x, float y)
    {
        return Mathf.Atan2(x, y) * Mathf.Rad2Deg - 90;
    }
}
