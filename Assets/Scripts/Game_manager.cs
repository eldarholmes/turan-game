using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    public Player player;
    public GameObject bullet;


    public void fire()
    {
        GameObject gameobject = Instantiate(bullet);
        gameobject.transform.position = new Vector2(player.transform.position.x + 0.2f, player.transform.position.y + 0.5f);
        StartCoroutine(sleep(5f, gameobject));
    }

    IEnumerator sleep(float sec, GameObject gb)
    {
        yield return new WaitForSeconds(sec);

        Destroy(gb);
    }
}
