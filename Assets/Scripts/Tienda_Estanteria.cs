using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tienda_Estanteria : MonoBehaviour {

    [SerializeField]
    private Image imagen;
    [SerializeField]
    BotonTienda boton_compra;
    [SerializeField]
    BotonTienda boton_siguiente;
    [SerializeField]
    BotonTienda boton_anteriro;
    [SerializeField]
    BotonTienda boton_equipar;
    [SerializeField]
    private Sprite sombrero00;
    [SerializeField]
    private Sprite sombrero01;
    [SerializeField]
    private Sprite sombrero02;
    [SerializeField]
    private Text precio;
    [SerializeField]
    private Text dineroHud;
      
    [SerializeField]
    private SpriteRenderer sombreroPlayer;

    private int precioC = 0;
    private Sprite[] sombreros;
    private int indice = 0;

    private static bool compra00 = false;
    private static bool compra01 = false;
    private static bool compra02 = false;
    private  int dinero;



    // Use this for initialization
    void Start ()
    {
        CrearArreglo();
        imagen.sprite = sombreros[indice];
        Precios();
        dinero = DatosPlayer.Dinero;

    }
	
	// Update is called once per frame
	void Update ()
    {
        dineroHud.text = "$" + dinero;
        imagen.sprite = sombreros[indice];
        sombreroPlayer.sprite = sombreros[indice];
        DatosPlayer.Dinero = dinero;

        if (boton_siguiente.B_siguiente)
        {
            Siguiente();
        }

        if (boton_anteriro.B_anterior)
        {
            Anterior();
        }

        if (indice > 2)
        {
            indice = 0;
        }

        if (indice < 0)
        {
            indice = 2;
        }

        if (boton_compra.B_comprar)
        {
            Comprar();
        }

        if(boton_equipar.B_equipar)
        {
            Equipar();
        }

	}

    private void CrearArreglo()
    {
        sombreros = new Sprite[3];
        sombreros[0] = sombrero00;
        sombreros[1] = sombrero01;
        sombreros[2] = sombrero02;
    }

    private void Siguiente()
    {
        indice +=1;
        boton_siguiente.B_siguiente = false;
        Precios();
    }

    private void Anterior()
    {
       indice -= 1;
       boton_anteriro.B_anterior= false;
       Precios();
    }

    private void Equipar()
    {
        if (indice == 0 && compra00)
        {
            DatosPlayer.Sprite_sombrero = sombreros[indice];
            boton_equipar.B_equipar = false;
        }

        if (indice == 1 && compra01)
        {
            DatosPlayer.Sprite_sombrero = sombreros[indice];
            boton_equipar.B_equipar = false;
        }

        if (indice == 2 && compra02)
        {
            DatosPlayer.Sprite_sombrero = sombreros[indice];
            boton_equipar.B_equipar = false;
        }

       
    }

    private void Precios()
    {

        // Si no los ha comprado
        if (indice == 0 && !compra00)
        {
            precioC = 1000;
            precio.text = "$" + precioC;         
        }
        
        if (indice == 1 && !compra01)
        {
            precioC = 3000;
            precio.text = "$" + precioC;
          
        }

        if (indice == 2 && !compra02)
        {
            precioC = 2000;
            precio.text = "$" + precioC;           
        }

        //Si ya los compró
        if (indice == 0 && compra00)
        {
            precio.text = "COMPRADO";
        }

        if (indice == 1 && compra01)
        {
            precio.text = "COMPRADO";

        }

        if (indice == 2 && compra02)
        {
            precio.text = "COMPRADO";
        }

    }

    private void Comprar()
    {
        

        if (dinero >= precioC)
        {

            if (indice == 0)
            {     
                if (!compra00)
                {
                    dinero -= precioC;
                   
                    compra00 = true;
                    Precios();
                }
            }

            if (indice == 1)
            {
               
                if (!compra01)
                {
                    dinero -= precioC;
                 
                    compra01 = true;
                    Precios();
                }
            }

            if (indice == 2)
            {             

                if (!compra02)
                {
                    dinero -= precioC;
                  
                    compra02 = true;
                    Precios();
                }
            }

           
        }

       

        boton_compra.B_comprar = false;
    }


}
