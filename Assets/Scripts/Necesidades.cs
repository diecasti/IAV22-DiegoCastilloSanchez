using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necesidades : MonoBehaviour
{
    [SerializeField]
    float foodnecesity = 20;
    [SerializeField]
    float minAmenaza = 20;
    [SerializeField]
    float minEspacio = 20;

    [SerializeField]
    public float comida { get; set; } = 15;
    [SerializeField]
    float espacio { get; set; } = 100;
    [SerializeField]
    float amenaza { get; set; } = 25;


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
    }


    void actualiceNumbers()
    {
        comida -= 1;
    }
    void Update()
    {
        //primero actualizar las estadisticas
        //que pierda hambre;

        //cada x segundos
      //  comida += -1;



        //vamsoa  aordenar aqui las diferentes prioridades segun los parametros dados


        if (comida < foodnecesity)
        {
            actions["Comer"] = (float)(((foodnecesity - comida) / foodnecesity) * 100.0f);
        }
        else actions["Comer"] = 0.0f;
        if (amenaza > minAmenaza)
        {
            actions["Huir"] = (float)(((amenaza - minAmenaza) / minAmenaza) * 100.0f);
        }
        else actions["Huir"] = 0.0f;
        if (espacio < minEspacio)
        {
            actions["Explorar"] = (float)(((minEspacio - espacio) / minEspacio) * 100.0f);
        }
        else actions["Explorar"] = 0.1f;


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
