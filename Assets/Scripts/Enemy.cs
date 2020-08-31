using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    Vector2 offset;
    public float shootingdistance;
    public GameObject bullet;
    public float speed;
    float shoottime;
    public float resetTime;

    Rigidbody2D rb;
    void Start()
    {
        shoottime = resetTime;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        offset = target.transform.position;
        Vector2 objectpos = transform.position;
        offset -= objectpos;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));
        shoottime -= Time.deltaTime;
        if (Vector2.Distance(transform.position, target.transform.position) < shootingdistance && shoottime <= 0)
        {
            Destroy(Instantiate(bullet, transform.position, this.transform.rotation), 5f);
            shoottime = resetTime;

        }

        Vector2 Distance = target.transform.position - transform.position;
        Distance.Normalize();
        rb.MovePosition((Vector2)transform.position + (Distance * speed * Time.deltaTime));



    }
}
