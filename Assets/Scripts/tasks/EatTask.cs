using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using UCM.IAV.Movimiento;

/*
 * Accion de seguir a la cantante, cuando la alcanza devuelve Success
 */

public class EatTask : Action
{
    Necesidades necesities;

    public override float GetUtility()
    {
        return necesities.prioridadComer();

    }

    public override void OnAwake()
    {
        necesities = GetComponent<Necesidades>();
    }
    public override void OnStart()
    {
        GetComponent<Comer>().enabled = true;
    }
    public override void OnEnd()
    {
        GetComponent<Comer>().enabled = false;
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