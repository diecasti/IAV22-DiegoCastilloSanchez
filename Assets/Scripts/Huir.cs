/*    
   Copyright (C) 2020-2021 Federico Peinado
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
    /// Clase para modelar el comportamiento de HUIR a otro agente
    /// </summary>
    public class Huir : ComportamientoAgente
    {
        public float RotationSpeed = 30;
        private Quaternion targetRotation;


        /// <summary>
        /// Obtiene la dirección
        /// </summary>
        /// <returns></returns>
        public override Direccion GetDireccion()
        {
        
            //encontraral enemigo mas cercano
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




            Direccion direccion = new Direccion();
            direccion.lineal = /*objetivo.transform.position - */transform.forward;
            direccion.lineal.Normalize();
            direccion.lineal *= agente.aceleracionMax;

            // Podríamos meter una rotación automática en la dirección del movimiento, si quisiéramos

            targetRotation = Quaternion.LookRotation(transform.position - objetivo.transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
            return direccion;
        }
    }
}
