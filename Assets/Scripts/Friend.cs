using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Vector2 Distance;
        if (other.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Distance = transform.position - other.transform.position;
            Distance.Normalize();
            rb.MovePosition((Vector2)transform.position + (Distance * 4 * Time.deltaTime));
        }

        

    }

     void OnCollisionEnter2D(Collision2D other)
    {

         if (other.gameObject.CompareTag("bullet1")|| other.gameObject.CompareTag("bullet2"))
        {
            
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
       
    }
}
