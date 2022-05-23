using System.Collections;
using System.Collections.Generic;
using UCM.IAV.Movimiento;
using UnityEngine;

public class Necesidades : MonoBehaviour
{
    [SerializeField]
    float foodnecesity = 50;
    [SerializeField]
    float minAmenaza = 20;
    [SerializeField]
    float minEspacio = 20;
    [SerializeField]
    float minComidaReproduccion = 50;
    [SerializeField]
    float distSegura = 5;
    [SerializeField]
    public float comida  = 40;
    [SerializeField]
    float espacio = 100;
    [SerializeField]
    float amenaza = 0;
    [SerializeField]
    public float extres = 0;

    [SerializeField]
    float minExtres = 10;
    

    public GameObject comidaGO;

    GameObject contrarios;

    Hashtable actions;

    private void OnAwake()
    {
    }

    void Start()
    {
        actions = new Hashtable();

        actions.Add("Comer", 0.0f);
        actions.Add("Huir", 0.0f);
        actions.Add("Atacar", 0.0f);
        actions.Add("Deshovar", 0.0f);
        actions.Add("Explorar", 0.0f);
        InvokeRepeating("actualiceNumbers", 2.0f, 3f);

        contrarios = transform.parent.GetComponent<contrario>().contra;


    }


    void actualiceNumbers()
    {
        comida -= 1;
        if (GetComponent<Comer>().arrayComida.transform.childCount <= 0)
        {
            extres += 1;
        }
        if (comida < foodnecesity / 2)
            extres += 1;


    }
    void Update()
    {
        //primero actualizar las estadisticas
        //que pierda hambre;

        //cada x segundos
        //  comida += -1;



        //vamsoa  aordenar aqui las diferentes prioridades segun los parametros dados


        //el nivel de amenza se medira por la proximidad a alos enemigos
        //encontraral enemigo mas cercano
        foreach (Agente co in contrarios.GetComponentsInChildren<Agente>())
        {
                float distanceCo = Vector3.Distance(co.gameObject.transform.position, transform.position);
                if (distanceCo < distSegura)
                {
                    amenaza += (distSegura - distanceCo / distSegura) * 100.0f;
                }
        }


        //el espacio por la proximidad a los aliados
        foreach (Agente co in transform.parent.GetComponentsInChildren<Agente>())
        {
            float distanceCo = Vector3.Distance(co.gameObject.transform.position, transform.position);
            if (distanceCo < distSegura)
            {
                espacio -= (distSegura - distanceCo / distSegura) * 100.0f;
            }
        }





        if (comida < foodnecesity)
        {
            actions["Comer"] = (float)(((foodnecesity - comida) / foodnecesity) * 100.0f);
        }
        else actions["Comer"] = 0.0f;
       
        if (espacio < minEspacio)
        {
            actions["Explorar"] = (float)(((minEspacio - espacio) / minEspacio) * 100.0f);
        }
        else actions["Explorar"] = 0.1f;

        if (comida > minComidaReproduccion)
        {
            actions["Deshovar"] = 1.0f;
        }
        else actions["Deshovar"] = 0.0f;

        if (extres > minExtres)
        {
            actions["Huir"] = 0.0f;
            actions["Atacar"] = (float)(((extres - minExtres) / minExtres) * 100.0f);
        }
        else
        {
            actions["Atacar"] = 0.0f;
            if (amenaza > minAmenaza)
            {
                actions["Huir"] = (float)(((amenaza - minAmenaza) / minAmenaza) * 100.0f);
            }
            else actions["Huir"] = 0.0f;

        }




        amenaza = 0;
        espacio = 100;



        if (comida < 0)
        {
            Destroy(this.gameObject);

            Instantiate(comidaGO,transform.position,transform.rotation, GetComponent<Comer>().arrayComida.transform);
            Instantiate(comidaGO,transform.position,transform.rotation, GetComponent<Comer>().arrayComida.transform);


        }


    }




    public bool foodSatisfied()
    {
        return comida > foodnecesity;
    }
    public bool isSafe()
    {
        return amenaza < minAmenaza;
    }


    public float prioridadComer()
    {
        return (float)actions["Comer"];
    }

    public float prioridadHuir()
    {
        return (float)actions["Huir"];

    }

    public float prioridadAtacar()
    {
        return (float)actions["Atacar"];

    }

    public float prioridadDeshovar()
    {
        return (float)actions["Deshovar"];

    }
    public float prioridadMerodear()
    {
        return (float)actions["Explorar"];

    }

}
