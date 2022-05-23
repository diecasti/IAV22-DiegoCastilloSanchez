using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject food;
    public float spawntime = 30.0f;
    void Start()
    {

        InvokeRepeating("spawnFood", 2.0f, spawntime);
    }

    void spawnFood()
    {
        Instantiate(food, this.transform);
    }
}
