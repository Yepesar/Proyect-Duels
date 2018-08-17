using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDia : MonoBehaviour {

    [SerializeField]
    private Light luz00;
    [SerializeField]
    private Light luz01;
    [SerializeField]
    private GameObject fondo;
    [SerializeField]
    private Material difuso;
    [SerializeField]
    private Material normal;

    private Color32 color;
    private int random = 0;
    private Material material;
    private SpriteRenderer rend;

    // Use this for initialization
    void Start ()
    {
        rend = fondo.GetComponent<SpriteRenderer>();
        random = Random.Range(1, 4);

        Noche();     
    }
	

    public void Dia()
    {
        luz00.gameObject.SetActive(false);
        luz01.gameObject.SetActive(false);

        rend.material = normal;   
    }

    public void Atardecer()
    {

        // color = new Color(R , G, B, ALPHA);
        color = new Color32(251, 140, 89, 255);

        luz00.gameObject.SetActive(true);
        luz01.gameObject.SetActive(true);

        luz00.color = color;
        luz01.color = color;
    }

    public void Noche()
    {
        /* luz00.gameObject.SetActive(false);
         luz01.gameObject.SetActive(false);

         rend.material = difuso;*/

        // color = new Color(R , G, B, ALPHA);
        color = new Color32(20, 8, 41, 255);

        luz00.gameObject.SetActive(true);
        luz01.gameObject.SetActive(true);

        luz00.color = color;
        luz01.color = color;

    }
}
