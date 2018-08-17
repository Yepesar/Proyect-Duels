using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {

	public GameObject manager;

	public float MaxtimeSwipe;
	public float MindistanceSwipe;
	private float starttime;
	private float endtime;
	private float SwipeDistance;
	private float SwipeTime;

    private float starttimeDos;
    private float endtimeDos;
    private float SwipeDistanceDos;
    private float SwipeTimeDos;

	private Vector3 Startposicion;
	private Vector3 Endposicion;
    private Vector3 StartposicionDos;
    private Vector3 EndposicionDos;

    public AnimatorManager AnimatorManager;
    public AnimatorManager AnimatorManagerEnemigo;

    public Text tiempoJugador;
	public Text TiempoEnemigo;

    public Tambor tambor;
    public Tambor tamborEnemigo;
	private bool swipe;
    private bool swipeEnemigo;

	public GameObject particulas;
    public GameObject particulasDos;

    public float puntuacion;
	public float puntuacionEnemigo;

	private bool llamado;

    private bool toquePrimero;
    private bool toqueSegundo;

    private Touch touch;
    private Touch touchDos;

    private GameObject congelado;
    private GameObject congeladoEnemigo;

	// Use this for initialization
	void Start()
	{
		tiempoJugador.gameObject.SetActive (false);
		TiempoEnemigo.gameObject.SetActive (false);
		particulas.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if(manager.GetComponent<ManagerTime>().timer <= 0 && !llamado)
		{
			Invoke("StartShootTimer", Random.Range(1f, 1.6f));
			llamado = true;
		}

		if (Input.touchCount > 0)
		{
            if (!toquePrimero)
            {
                touch = Input.GetTouch(0); // toma el primer toque y lo almacena en touch
                toquePrimero = true;
            }
            else
            {
                touchDos = Input.GetTouch(1);
                toqueSegundo = true;
            }

			if (touchDos.phase == TouchPhase.Began)
			{  // cuando empieza a tcar la pantalla
				starttimeDos = Time.time;              // almacena el momento en que la tocó
				StartposicionDos = touch.position;     // almacena la posicion en que la tocó
				particulasDos.SetActive(true);

			}
			else if (touchDos.phase == TouchPhase.Ended)
			{ // cuando deja de tocar la pantalla
				endtimeDos = Time.time;
				EndposicionDos = touch.position;

				SwipeDistanceDos = (EndposicionDos - StartposicionDos).magnitude;
				SwipeTimeDos = endtimeDos - starttimeDos;

				if (SwipeTimeDos < MaxtimeSwipe && SwipeDistance > MindistanceSwipe)
				{
                    if (Startposicion.x < 0)
                    {
                        Swipe(SwipeDistance, SwipeTime);
                    } else
                    {
                        SwipeEnemigo(SwipeDistance, SwipeTime);
                    }
				}

				particulasDos.SetActive(false);

			}

            if (touch.phase == TouchPhase.Began)
            {  // cuando empieza a tcar la pantalla
                starttime = Time.time;              // almacena el momento en que la tocó
                Startposicion = touchDos.position;     // almacena la posicion en que la tocó
                particulas.SetActive(true);

            }
            else if (touch.phase == TouchPhase.Ended)
            { // cuando deja de tocar la pantalla
                endtime = Time.time;
                Endposicion = touch.position;

                SwipeDistance = (Endposicion - Startposicion).magnitude;
                SwipeTime = endtime - starttime;

                if (SwipeTime < MaxtimeSwipe && SwipeDistance > MindistanceSwipe)
                {
                    if (Startposicion.x < 0)
                    {
                        Swipe(SwipeDistance, SwipeTime);
                    }
                    else
                    {
                        SwipeEnemigo(SwipeDistance, SwipeTime);
                    }
                }

                particulas.SetActive(false);

            }

            particulas.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 1));
            particulasDos.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1));

        }
	}

	private void Swipe(float distancia, float tiempo)
	{
		if (manager.GetComponent<ManagerTime> ().timer <= 0 && !swipe) {

			puntuacion = (distancia / (tiempo/2)) / 99000f;
			tiempoJugador.text = puntuacion.ToString ("F2");
			tiempoJugador.gameObject.SetActive (true);


			AnimatorManager.Apuntar ();
			swipe = true;

		}
	}

    private void SwipeEnemigo(float distancia, float tiempo)
    {
        if (manager.GetComponent<ManagerTime>().timer <= 0 && !swipeEnemigo)
        {

            puntuacionEnemigo = (distancia / (tiempo)) / 99000f;
            TiempoEnemigo.text = puntuacion.ToString("F2");
            AnimatorManagerEnemigo.Apuntar();
            swipeEnemigo = true;

        }
    }

    private void StartShootTimer() {

        if (!swipe)
		{
			puntuacion = 0;
            congelado.SetActive(true);
		}

        if (!swipeEnemigo)
        {
            puntuacionEnemigo = 0;
            congeladoEnemigo.SetActive(true);
        }

        manager.GetComponent<ManagerTime>().Shoot();
        manager.GetComponent<ManagerTime>().congelado = congelado;
        manager.GetComponent<ManagerTime>().congeladoEnemigo = congeladoEnemigo;
    }


}


