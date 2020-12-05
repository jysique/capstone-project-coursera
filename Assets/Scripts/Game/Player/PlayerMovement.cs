using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float speed = 5f;
    private Rigidbody2D rigidbody2D;
    private Camera camera;

    Vector2 movement;
    Vector2 mousePosition;
    void Start()
    {
        camera = Camera.main;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position+ movement * speed * Time.fixedDeltaTime);

        Vector2 lookdirection = mousePosition - rigidbody2D.position;
        float angle = Mathf.Atan2(lookdirection.y,lookdirection.x) * Mathf.Rad2Deg - 90f;
        rigidbody2D.rotation = angle;


        Vector3 clampetposition = transform.position;
        clampetposition.y = Mathf.Clamp(clampetposition.y,-5f,5f);
        clampetposition.x = Mathf.Clamp(clampetposition.x,-9f,9f);
        transform.position = clampetposition;
    }
}
