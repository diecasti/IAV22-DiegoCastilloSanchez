/*    
   Copyright (C) 2020 Federico Peinado
   http://www.federicopeinado.com

   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).

   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/
using UnityEngine;

namespace UCM.IAV.Movimiento
{

    /// <summary>
    /// Clase para modelar el comportamiento de SEGUIR a otro agente
    /// </summary>
    public class Mirar : ComportamientoAgente
    {
        /// <summary>
        /// Obtiene la dirección
        /// </summary>
        /// <returns></returns>
        public float RotationSpeed = 1;
        private Quaternion targetRotation;


        public void doRotate()
        {
            // Si fuese un comportamiento de dirección dinámico en el que buscásemos alcanzar cierta velocidad en el agente, se tendría en cuenta la velocidad actual del agente y se aplicaría sólo la aceleración necesaria
            // Vector3 deltaV = targetVelocity - body.velocity;
            // Vector3 accel = deltaV / Time.deltaTime;


            targetRotation = Quaternion.LookRotation(objetivo.transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);

            // Podríamos meter una rotación automática en la dirección del movimiento, si quisiéramos





        }
    }
}
