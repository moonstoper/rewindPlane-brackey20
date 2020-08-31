using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * 3f;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Respawn") && !this.gameObject.CompareTag("Respawn"))
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("Respawn"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        
       

        
    }

    
}
