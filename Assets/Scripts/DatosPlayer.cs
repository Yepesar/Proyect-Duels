using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosPlayer : MonoBehaviour {

    //Variables serializadas
    [SerializeField]
    private GameObject sombrero;

    //Variables estaticas 

    private static Sprite sprite_sombrero;
    private static int dinero = 10000;

    //Variables comunes
    private SpriteRenderer sr;

    
    public static Sprite Sprite_sombrero
    {
        get
        {
            return sprite_sombrero;
        }

        set
        {
            sprite_sombrero = value;
        }
    }

    public static int Dinero
    {
        get
        {
            return dinero;
        }

        set
        {
            dinero = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        sr = sombrero.GetComponent<SpriteRenderer>();
        sr.sprite = Sprite_sombrero;
	}

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
       
	}
}
