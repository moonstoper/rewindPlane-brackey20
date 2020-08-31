using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    //GameObject cam; 
    Vector2 mpos;
    float x, y;
    public float speedfactor;
    Rigidbody2D rb;
    public float rotaionoffset;
    [SerializeField] GameObject[] orbits;
    [SerializeField] int[] bulletcount;
    //int a = 0;
    [SerializeField] GameObject[] bullet;
    int num = 1;

    [SerializeField] bool[] orbitchk;
    private Vector2 screenbounds;

    float objectwidth;
    float objectheight;
    Vector2 offsets = new Vector2(21f, 7.5f);

    public float Timer, resettimer;
    void Start()
    {
        //cam = GameObject.FindGameObjectWithTag("MainCamera");
        mpos = Input.mousePosition;
        rb = GetComponent<Rigidbody2D>();
        for (int a = 0; a < orbitchk.Length; a++)
        {
            orbitchk[a] = false;
        }
        screenbounds = Camera.main.ViewportToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));


        objectwidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectheight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;



    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = Input.mousePosition;
        Vector2 objectPos = Camera.main.WorldToScreenPoint(this.transform.position);
        mouse -= objectPos;
        float angle = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotaionoffset));
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = new Vector2(move.x * speedfactor, move.y * speedfactor);

        if (Input.GetMouseButton(3))
        {
            if (num == 1)
            {
                num = 2;
            }
            else num = 1;
        }


        Timer -= Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (num == 1 && bulletcount[0] != 0 && Timer <= 0)
            {
                Destroy(Instantiate(bullet[0], transform.position, this.transform.rotation), 10f);
                bulletcount[0] -= 1;
                Timer = resettimer;
                if (bulletcount[0] == 0)
                {
                    Destroy(GameObject.FindGameObjectWithTag("orbit1"));
                    orbitchk[0] = false;
                }
            }
            //Debug.Log(bulletcount[0]);




            if (num == 2 && bulletcount[1] != 0 && Timer <= 0)
            {
                Destroy(Instantiate(bullet[1], transform.position, this.transform.rotation), 10f);
                bulletcount[1] -= 1;
                Timer = resettimer;
                if (bulletcount[1] == 0)
                {
                    Destroy(GameObject.FindGameObjectWithTag("orbit2"));
                    orbitchk[1] = false;
                }
            }


        }

        mpos = Input.mousePosition;
        if(Timer <= 0)
        {
            Timer = 0;
        }


    }

    //Debug.Log("mpos"+ mpos);



    private void LateUpdate()
    {

        Vector2 pos = transform.position;

        if (Camera.main.transform.position.x - pos.x > offsets.x || Camera.main.transform.position.y - pos.y > offsets.y)
            transform.position = new Vector2(transform.position.x - 1f, transform.position.y - 1f);
    }





    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet1"))
        {
            if (!orbitchk[0])
            {
                GameObject bulletorbit1 = Instantiate(orbits[0], this.transform.position, Quaternion.identity);
                bulletorbit1.transform.parent = this.gameObject.transform;
                //bulletorbit1.tag = "Weapon";
                orbitchk[0] = !orbitchk[0];
            }
            if (bulletcount[0] <= 30)
                bulletcount[0] += 1;

            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("bullet2"))
        {
            if (!orbitchk[1])
            {
                GameObject bulletorbit2 = Instantiate(orbits[1], this.transform.position, Quaternion.identity);
                bulletorbit2.transform.parent = this.gameObject.transform;
                orbitchk[1] = !orbitchk[1];
            }
            // bulletorbit2.tag = "Weapon";
            if (bulletcount[0] <= 30)
                bulletcount[1] += 1;
            Destroy(other.gameObject);
        }
    }
}

