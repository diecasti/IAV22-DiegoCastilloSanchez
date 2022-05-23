using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deshove : MonoBehaviour
{
   public void huevada()
    {


        GetComponent<Necesidades>().comida -= 20;
        //dos huevicos
        Instantiate(this,this.transform.parent);
        GetComponent<Necesidades>().comida -= 20;

        Instantiate(this,this.transform.parent);
    }
}
