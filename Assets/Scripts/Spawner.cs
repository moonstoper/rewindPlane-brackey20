using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    List<int> indexes;
    int numbertoexclude;
    public GameObject target;
    public GameObject[] spawns;

    public float resetTime;
    float spawntime;
    void Start()
    {
        indexes = new List<int>(new int[] { 1, 2, 3, 4 });
        spawntime = resetTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.WorldToViewportPoint(target.transform.position);
        if (pos.x >= 0 && pos.y >= 0)
        {
            numbertoexclude = 1;
        }
        if (pos.x < 0 && pos.y > 0)
        {
            numbertoexclude = 2;
        }

        if (pos.x < 0 && pos.y < 0)
        {
            numbertoexclude = 3;
        }
        if (pos.x > 0 && pos.y < 0)
        {
            numbertoexclude = 4;
        }

        indexes.Remove(numbertoexclude);

        int randomnum = indexes[Random.Range(0, indexes.Count)];
        indexes.Add(numbertoexclude);

        spawntime -= Time.deltaTime;
        if(spawntime<=0)
        switch (randomnum)
        {
            case 1:
                spawns[1 - 1].GetComponent<spwanlocation>().spwan();
                break;
            case 2:
                spawns[2 - 1].GetComponent<spwanlocation>().spwan();
                break;
            case 3:
                spawns[3 - 1].GetComponent<spwanlocation>().spwan();
                break;
            case 4:
                spawns[4 - 1].GetComponent<spwanlocation>().spwan();
                break;
        }


    }
}
