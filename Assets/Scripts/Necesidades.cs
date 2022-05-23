using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necesidades : MonoBehaviour
{
    [SerializeField]
    float foodnecesity = 20;

    [SerializeField]
    public float comida { get; set; } = 0;
    [SerializeField]
    float espacio { get; set; } = 0;
    [SerializeField]
    float amenaza { get; set; } = 0;


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
            actions["Comer"] = (float)((foodnecesity - comida) / foodnecesity);
        }
        else actions["Comer"] = 0;



    }




    public bool foodSatisfied()
    {
        return comida > foodnecesity;
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
