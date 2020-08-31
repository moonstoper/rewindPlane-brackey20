using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 offset;
    public GameObject target;
    Vector2 targetstableposition;
    void Start()
    {
        offset = transform.position - target.transform.position;
       
    }

    // Update is called once per frame
    void LateUpdate()
    {    targetstableposition = target.transform.position;
        transform.position = new Vector2(targetstableposition.x + offset.x, targetstableposition.y + offset.y);
    }
}
