using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonTienda : MonoBehaviour {

    private static bool b_siguiente = false;
    private static bool b_anterior = false;
    private static bool b_comprar = false;
    private static bool b_equipar = false;

    public bool B_siguiente
    {
        get
        {
            return b_siguiente;
        }

        set
        {
            b_siguiente = value;
        }
    }

    public bool B_anterior
    {
        get
        {
            return b_anterior;
        }

        set
        {
            b_anterior = value;
        }
    }

    public bool B_comprar
    {
        get
        {
            return b_comprar;
        }

        set
        {
            b_comprar = value;
        }
    }

    public bool B_equipar
    {
        get
        {
            return b_equipar;
        }

        set
        {
            b_equipar = value;
        }
    }

    public void Siguiente()
    {
        B_siguiente = true;
    }

    public void Anterior()
    {
        B_anterior = true;
    }

    public void Comprar()
    {
        B_comprar = true;
    }

    public void Equipar()
    {
        B_equipar = true;
    }
}
