using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BocaPez : MonoBehaviour
{
    // Start is called before the first frame update
    Necesidades necesities;


    void Start()
    {
        necesities = GetComponentInParent<Necesidades>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Comida>())
        {
            necesities.comida += other.GetComponent<Comida>().cantidadComida;

            Destroy(other.gameObject);
        }
    }



}
