using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float hp = 100f;
    private float speed = 5f;
    public float x = 0, y = 0;
    public float level = 0;

    public Joystick joystick;

    Rigidbody2D rb;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        float x0 = joystick.Direction.x;
        float y0 = joystick.Direction.y;

        if (joystick.Direction.x != 0 && joystick.Direction.y != 0)
        {
            x = joystick.Direction.x;
            y = joystick.Direction.y;
        }
        if (joystick.Direction.y != 0)
        {
            rb.velocity = new Vector2(joystick.Direction.x * speed, joystick.Direction.y * speed);
        }
        else rb.velocity = Vector2.zero;
        if (findAngle(joystick.Direction.x, -joystick.Direction.y) == 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, findAngle(x0, -y0)));
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, findAngle(x, -y)));
        
    }

    private float findAngle(float x, float y)
    {
        return Mathf.Atan2(x, y) * Mathf.Rad2Deg - 90;
    }

    public void levelUp(float exp)
    {
        level += exp;
        Debug.Log(level);
    }
    public void upSpeed(float speed)
    {
        this.speed += speed;
    }
}
