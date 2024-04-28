using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    public GameObject weapon;
    public GameObject bullet;
    public GameObject point_1;
    private List<GameObject> points;
    public Player player;
    public GameObject upgrades;

    public float cool_down = 1f;
    private bool isCoolDown = false;
    public Vector2 down_pos = new Vector2(-25, -25);
    public Vector2 up_pos = new Vector2(25, 25);
    private float bullet_speed = 10f;
    public bool isRemoved = false;
    private void Start()
    {
        points = new List<GameObject>(50);
        upgrades.SetActive(false);
        for (int i = 0; i < 50; i++)
        {
            instantPoint();
        }
    }

    public void instantPoint()
    {
        GameObject clone = Instantiate(point_1);
        clone.transform.position = new Vector2(Random.Range(down_pos.x, up_pos.x), Random.Range(down_pos.y, up_pos.y));
        points.Add(clone);
    }
    private void FixedUpdate()
    {
        if (player.level >= 10)
        {
            upgrades.SetActive(true);
        }

        if (isRemoved)
        {
            instantPoint();
            isRemoved = false;
        }

        
    }
    public void fire()
    {
        if (!isCoolDown)
        {
            GameObject gameobject = Instantiate(bullet);
            gameobject.GetComponent<Bullet>().speed = bullet_speed;
            gameobject.transform.position = new Vector2(weapon.transform.position.x, weapon.transform.position.y);
            StartCoroutine(sleep(5f, gameobject));
            StartCoroutine(StartCooldown());
        }
    }

    IEnumerator sleep(float sec, GameObject gb)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gb);
    }

    private IEnumerator StartCooldown()
    {
        isCoolDown = true;

        yield return new WaitForSeconds(cool_down);

        isCoolDown = false;

    }

    public void speed_of_bullet()
    {
        bullet_speed += 5f;
        upgrades.SetActive(false);
        player.level -= 10f;
    }
    public void speed_of_player()
    {
        player.upSpeed(1f);
        upgrades.SetActive(false);
        player.level -= 10f;
    }

    public void reduce_cd()
    {
        cool_down -= 0.1f;
        upgrades.SetActive(false);
        player.level -= 10f;
    }

}
