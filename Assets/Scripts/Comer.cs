
using UnityEngine;

namespace UCM.IAV.Movimiento
{

    /// <summary>
    /// Clase para modelar el comportamiento de SEGUIR a otro agente
    /// </summary>
    public class Comer : ComportamientoAgente
    {
        public GameObject arrayComida;
        public float RotationSpeed = 1;
        private Quaternion targetRotation;

        /// <summary>
        /// Obtiene la dirección
        /// </summary>
        /// <returns></returns>
        public override Direccion GetDireccion()
        {
            //encontrar la comida mas cercana dentro del array de comida
            foreach (Comida co in arrayComida.transform.GetComponentsInChildren<Comida>())
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

            targetRotation = Quaternion.LookRotation(objetivo.transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);

            return direccion;
        }

        private void OnDisable()
        {

        }
    }
}
