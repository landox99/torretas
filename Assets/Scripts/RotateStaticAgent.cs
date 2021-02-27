using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStaticAgent : FunctionsFSM
{
    //Metodo que se manda llamar cuando se entra al estado de Idle
    public override void EnterState(AgenteEstatico agent)
    {
        Debug.Log("Entro a estado rotar"); //Mensaje en consola de Unity
        agent.agentStatus = AgentState.OnMovement; //Se cambia la variable para indicar el estado en que se encuentra el agente
    }

    //Metodo que se manda llamar cada frame
    public override void UpdateState(AgenteEstatico agent)
    {
        //Si se detecto al agente
        if(agent.targetDetected)
        {
            agent.TransitionToState(agent.attackState); //Hacer la transicion al estado de atacar
        }
        else
        {
            //Sino, realizar el comportamiento de rotar
            //Esta linea es la que permite rotar de forma suave al agente, llendo de su rotación actual hacia el angulo indicado en el 
            //arreglo, se le añade la variable de velocidad para la rotación
            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, Quaternion.Euler(agent.angles[agent.angleIndex]), Time.deltaTime * agent.speedRotation);
            

            //Debug.Log(agent.transform.eulerAngles.y); //Mensaje en consola para ver los angulos

            //Si el agente llego a la rotación que se encuentra en el arreglo
            if(agent.transform.eulerAngles.y >= (agent.angles[agent.angleIndex].y - 1))
            {
          
                agent.angleIndex = (agent.angleIndex + 1) % agent.angles.Length; //Pasar al siguiente angulo, recorriendo el arreglo de angulos, va a recorre siempre de 0 - el tamaño del arreglo
                agent.TransitionToState(agent.idleState); //Una vez llegado ahí queremos que espere un momento antes de rotar, por eso se hace la transición al estado Idle
            }
        }
    }
}
