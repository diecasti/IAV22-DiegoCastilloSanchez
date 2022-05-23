using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using UCM.IAV.Movimiento;

/*
 * Accion de seguir a la cantante, cuando la alcanza devuelve Success
 */

public class HuirTask : Action
{
    Necesidades necesities;

    public override float GetUtility()
    {
        return necesities.prioridadHuir();

    }
    public override void OnAwake()
    {
        necesities = GetComponent<Necesidades>();
    }
    public override void OnStart()
    {
        GetComponent<Huir>().enabled = true;
    }
    public override void OnEnd()
    {
        GetComponent<Huir>().enabled = false;
        base.OnEnd();
    }
    
    

    public override TaskStatus OnUpdate()
    {
        if (necesities.isSafe())
        {
            return TaskStatus.Success;
        }
        else return TaskStatus.Running;
    }
}