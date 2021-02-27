using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStaticState : FunctionsFSM
{
    //Metodo de inicio en el estado Idle
    public override void EnterState(AgenteEstatico agent)
    {
        Debug.Log("Entro a estado Idle");
        agent.agentStatus = AgentState.Idle; //Se cambia la variable para saber el estado en que esta el agente
        agent.Coroutine(Wait(agent));       //Se llama la corutina para iniciar la espera de x segundos
    }

    //Corutina, nos permite hacer una "pausa" antes de ejecutar cierto código
    IEnumerator Wait(AgenteEstatico agent)
    {
        yield return new WaitForSeconds(agent.timeIdle); //Espera x segundos, depende del valor de la variable timeIdle
        agent.TransitionToState(agent.rotateState); //Cambia al estado de rotación
    }

    public override void UpdateState(AgenteEstatico agent)
    {
        //necesario preguntar si se ha detectado al jugador
            //agent.StopAllCoroutines();//Esto detiene la corutina de Wait que esta en este código
            //Si es verdad, cambiar al estado de atacar
        if(agent.targetDetected)
        {
            agent.StopAllCoroutines();
            agent.TransitionToState(agent.attackState);
        }
    }
}
