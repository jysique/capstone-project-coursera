using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform transform;
    [SerializeField] private GameObject bulletPrefab;

    private float bulletforce = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shooting();
        }
    }

    void Shooting(){
        GameObject bullet = Instantiate(bulletPrefab, transform.position,transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bulletforce, ForceMode2D.Impulse);

    }
}
