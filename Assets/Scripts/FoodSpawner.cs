using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject food;
    public float spawntime = 10.0f;
    void Start()
    {

        InvokeRepeating("spawnFood", 2.0f, spawntime);
    }

    void spawnFood()
    {
        Instantiate(food, transform.position + new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f)), transform.rotation, transform);
    }
}
