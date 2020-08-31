using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwanlocation : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 offset;
    public GameObject target;
    public GameObject[] enemies;
    Vector2 center,size;
    public float reset;
    float timer;
    void Start()
    {
        offset = this.transform.position - target.transform.position;
        size = GetComponent<SpriteRenderer>().bounds.size;
        timer = reset;
    }

    public void spwan()
    {   //Debug.Log("function called");
        if(timer<=0)
        {int enemyindex = Random.Range(0,2);
        //Debug.Log(enemyindex);
        Vector2 pos = center + new Vector2(Random.Range(-size.x/2, size.x/2), Random.Range(-size.y/2,size.y/2));
        Instantiate(enemies[enemyindex], pos, Quaternion.identity );
        timer = reset;
        }
    }
    void LateUpdate()
    {   center = GetComponent<SpriteRenderer>().bounds.center;
        timer -= Time.deltaTime;
        Vector2 currpos = target.transform.position;
        transform.position = currpos + offset;
    }
}
