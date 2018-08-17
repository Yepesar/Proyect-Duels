using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerTime : MonoBehaviour {
    private float timer;
    private float ShootTime;
    [SerializeField]
    private GameObject go;

    public GameObject shoot;

    public bool shooting;
    private bool CanShoot = false;

    private bool disparo;
    private bool disparoEnemigo;

    private float tiempoDisparo = 0;
    private float tiempoDisparoEnemigo = 0;

    public AnimatorManager AnimatorManager;
    public AnimatorManager AnimatorManagerEnemigo;

    public GameObject jugador;
    public GameObject enemigo;
    public GameObject congeladoImage;
    public GameObject congeladoImageEnemigo;

    private bool resultado = false;
    public bool congelado = false;
    public bool congeladoEnemigo = false;

    public Text tiempoJugador;
    public Text tiempoEnemigo;


    // Use this for initialization
    void Start()
    {

        timer = Random.Range(2f, 4f);
        go.SetActive(false);
        shoot.SetActive(false);

        ShootTime = Random.Range(2f, 4f);
        botonDiparar.SetActive(false);
        tiempoEnemigo.gameObject.SetActive(false);
        tiempoJugador.gameObject.SetActive(false);
        congeladoImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        timer -= Time.deltaTime;


        if (timer <= 0 && (!go == false))
        {
            go.SetActive(true);

            Destroy(go, 2f);

        }

        if (shooting == true)
        {
            ShootTime -= Time.deltaTime;
        }

        if (ShootTime <= 0)
        {
            shoot.SetActive(true);
            CanShoot = true;

        }

        if (!disparo && CanShoot)
        {
            tiempoDisparo += Time.deltaTime;
        }

        if (!disparoEnemigo && CanShoot)
        {
            tiempoDisparoEnemigo += Time.deltaTime;
        }

        if ((disparoEnemigo || congeladoEnemigo) && (disparo || congelado) && !resultado)
        {
            Invoke("Resultado", 1.5f);
            resultado = true;
        }

    }

    public void Shoot()
    {
        shooting = true;
    }



    public void TapPlayer()
    {
        if (CanShoot && !congelado)
        {
            disparo = true;
            AnimatorManager.Apuntar();
        }
        else
        {
            congelado = true;
            congeladoImage.SetActive(true);
        }
    }

    public void TapEnemy()
    {
        if (CanShoot && !congeladoEnemigo)
        {
            disparoEnemigo = true;
            AnimatorManagerEnemigo.Apuntar();
        }
        else
        {
            congeladoEnemigo = true;
            congeladoImage.SetActive(true);
        }
    }


    private void Resultado()
    {

        if (congelado)
            jugador.SetActive(false);

        if (congeladoEnemigo)
            enemigo.SetActive(false);



        if ((tiempoDisparo < tiempoDisparoEnemigo) && (!congelado && !congeladoEnemigo))
        {
            enemigo.SetActive(false);
        } else
        {
            jugador.SetActive(false);
        }

    }



}
