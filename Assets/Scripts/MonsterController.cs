using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class MonsterController : MonoBehaviour
{
    public float speed = 3.0f;
    public float distance = 6.0f;

    private Vector2 startPosition;

    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            float newY = Mathf.PingPong(Time.time * speed, distance) + startPosition.y;
            transform.position = new Vector2(transform.position.x, newY);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        playerController.canMove = false;
    }
}
