using System.Collections;
using System.Collections.Generic;
using UCM.IAV.Movimiento;
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
        else if (other.GetComponent<Agente>())
        {
            //es del equipo contrario
            if (!other.transform.IsChildOf(transform.parent.transform.parent))
            {
                //Le restamos comida y le metemos un empuje en señal de que ah sido un ataque
                other.GetComponent<Necesidades>().comida -= 20;
                other.GetComponent<Rigidbody>().AddForce(this.transform.forward * 10);
            }

        }
    }



}
