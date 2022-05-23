using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using UCM.IAV.Movimiento;

/*
 * Accion de seguir a la cantante, cuando la alcanza devuelve Success
 */

public class DeambualrTask : Action
{
    Necesidades necesities;

    public override float GetUtility()
    {
        return necesities.prioridadMerodear();

    }

    public override void OnAwake()
    {
        necesities = GetComponent<Necesidades>();
    }
    public override void OnStart()
    {
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