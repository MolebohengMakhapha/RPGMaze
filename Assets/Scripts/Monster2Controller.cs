using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2Controller : MonoBehaviour
{
    public float speed = 3.0f;
    public float distance = 6.0f;

    private Vector2 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame.
    void Update()
    {
        // float newY = Mathf.PingPong(Time.time * speed, distance) + startPosition.y;
        // transform.position = new Vector2(transform.position.x, newY);

        float newX = Mathf.PingPong(Time.time * speed, distance) + startPosition.x;
        transform.position = new Vector2(newX,transform.position.y);
    }
}

