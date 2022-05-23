using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using UCM.IAV.Movimiento;

/*
 * Accion de seguir a la cantante, cuando la alcanza devuelve Success
 */

public class AtackTask : Action
{
    Necesidades necesities;
    GameObject objetivo;

    public override float GetUtility()
    {
        return necesities.prioridadAtacar();

    }

    public override void OnAwake()
    {
        necesities = GetComponent<Necesidades>();
    }
    public override void OnStart()
    {
        foreach (Agente co in transform.parent.GetComponent<contrario>().contra.GetComponentsInChildren<Agente>())
        {
            if (objetivo == null)
            {
                objetivo = co.gameObject;
            }
            else
            {
                //medir la distancia
                float distanceObjetivo = Vector3.Distance(objetivo.transform.position, transform.position);
                float distanceCo = Vector3.Distance(co.gameObject.transform.position, transform.position);
                if (distanceCo < distanceObjetivo)
                {
                    objetivo = co.gameObject;
                }
            }
        }
        GetComponent<Seguir>().objetivo = objetivo;
        GetComponent<Seguir>().enabled = true;
    }
    public override void OnEnd()
    {
        GetComponent<Seguir>().enabled = false;
        base.OnEnd();
    }
    
    

    public override TaskStatus OnUpdate()
    {
        if (necesities.foodSatisfied())
        {
            return TaskStatus.Success;
        }
        else return TaskStatus.Running;
    }
}