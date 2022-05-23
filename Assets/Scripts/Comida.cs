using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
   public enum tipoComida { vegetal, carne };


    public tipoComida tipo = tipoComida.vegetal;
    public int cantidadComida = 20;


}
