using UnityEngine;

namespace UCM.IAV.Movimiento
{

    /// <summary>
    /// Clase para modelar el comportamiento de SEGUIR a otro agente
    /// </summary>
    public class Separacion : ComportamientoAgente
    {

        public float RotationSpeed = 40;
        private Quaternion targetRotation;
        Vector3 targetPosition;

        public override Direccion GetDireccion()
        {

            Direccion direccion = new Direccion();

            int i = 0;

            //hay que darle una rotacion en torno a un punto intermedio entre sus compañeros
            //este code             transform.position.x = josh.position.x + (mark.position.x - josh.position.x) / 2;
            foreach (Agente co in transform.parent.GetComponentsInChildren<Agente>())
            {
                if (co.gameObject != gameObject)
                {
                    if (Vector3.Distance(co.gameObject.transform.position, transform.position) < 1.0f)
                    {
                        if (i == 0)
                        {
                            targetPosition = co.transform.position + ((co.transform.position - transform.position) / 2);
                            i++;
                        }
                        else
                        {
                            targetPosition = targetPosition + ((co.transform.position - targetPosition) / 2 );
                        }
                    }

                }
            }



            targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);

            return direccion;
        }

        private void OnDisable()
        {

        }
    }
}
