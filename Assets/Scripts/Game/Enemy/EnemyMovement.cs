using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rigidbody2D;
    private Vector2 movement;
    private int difficultyMode;
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        difficultyMode = PlayerPrefs.GetInt("Difficulty");
        SetDifficultyMode();
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    void SetDifficultyMode(){
        if(difficultyMode == 2){
            speed = speed + 1f;
        }else if(difficultyMode == 3) {
            speed = speed + 2f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg- 90f;
        rigidbody2D.rotation = angle; 
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter (Vector2 direction){
        rigidbody2D.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime)  );
    }
}
