using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public float speed = 5.0f;
    public Camera camera;

    void Update()
    {
        if (!isLocalPlayer)
        {
            camera.gameObject.SetActive(false);
            return;
        }

        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
    }
}
