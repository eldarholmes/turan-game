using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    private float hp = 100f;
    private float speed = 5f;
    public float x = 0, y = 0;
    public float exp = 0;
    public float max_exp = 1f;
    public float up_chance = 0;
    public int currentLevel = 1;

    public Joystick joystick;
    public Slider level_bar;
    public TextMeshProUGUI text_level;

    Rigidbody2D rb;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        level_bar.maxValue = 1f;
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

        if (exp >= max_exp)
        {
            up_chance++;
            exp = 0;
            level_bar.maxValue += 3;
            max_exp = level_bar.maxValue;
            level_bar.value = 0;
            currentLevel++;
            text_level.text = "Level " + currentLevel.ToString();
        }
        
    }

    private float findAngle(float x, float y)
    {
        return Mathf.Atan2(x, y) * Mathf.Rad2Deg - 90;
    }

    public void levelUp(float exp)
    {
        this.exp += exp;
        level_bar.value = this.exp;

    }
    public void upSpeed(float speed)
    {
        this.speed += speed;
    }
}
