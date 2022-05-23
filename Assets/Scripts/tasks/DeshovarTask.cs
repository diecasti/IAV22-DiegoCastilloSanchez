using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using UCM.IAV.Movimiento;

/*
 * Accion de seguir a la cantante, cuando la alcanza devuelve Success
 */

public class DeshovarTask : Action
{
    Necesidades necesities;
    GameObject objetivo;

    public override float GetUtility()
    {
        return necesities.prioridadDeshovar();

    }

    public override void OnAwake()
    {
        necesities = GetComponent<Necesidades>();
    }
    public override void OnStart()
    {
        GetComponent<Seguir>().enabled = true;
        //encontrar el punto de deshove mas cercano
        for (int i = 0; i < transform.parent.GetComponent<contrario>().deshove.transform.childCount; i++)
        {
            if (i == 0)
            {
                GetComponent<Seguir>().objetivo = transform.parent.GetComponent<contrario>().deshove.transform.GetChild(i).gameObject;    
            }
            else
            {
                //medir la distancia
                float distanceObjetivo = Vector3.Distance(GetComponent<Seguir>().objetivo.transform.position, transform.position);
                float distanceCo = Vector3.Distance(transform.parent.GetComponent<contrario>().deshove.transform.GetChild(i).gameObject.gameObject.transform.position, transform.position);
                if (distanceCo < distanceObjetivo)
                {
                    objetivo = GetComponent<Seguir>().objetivo = transform.parent.GetComponent<contrario>().deshove.transform.GetChild(i).gameObject;    
                }
            }
        }




    }
    public override void OnEnd()
    {
        GetComponent<Seguir>().enabled = false;
        base.OnEnd();
    }
    
    

    public override TaskStatus OnUpdate()
    {
        if (Vector3.Distance(GetComponent<Seguir>().objetivo.transform.position, transform.position) < 1.0f)
        {
            //spawnear dos peces

            GetComponent<deshove>().huevada();

            return TaskStatus.Success;
        }
        else return TaskStatus.Running;
    }
}