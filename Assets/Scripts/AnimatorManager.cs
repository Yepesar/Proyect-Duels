using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour {

	public Animator anim;
	public int pupilas;
	public int boca;
	public int parpados;
	public int cejas;
	public int expresiones;
	public int ojos;
	public int arma;
	public int mano;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		anim.SetInteger ("EstadoParpadeo", parpados);
		anim.SetInteger ("EstadoBoca", boca);
		anim.SetInteger ("EstadoCejas", cejas);
		anim.SetInteger ("EstadoPupilas", pupilas);
		anim.SetInteger ("EstadoExpresion", expresiones);
		anim.SetInteger ("EstadoOjos", ojos);
		anim.SetInteger ("EstadoArma", arma);
		anim.SetInteger ("EstadoMano", mano);

		//Pupilas

		if (Input.GetKeyDown (KeyCode.Keypad1)) 
			pupilas = 1;

		if (Input.GetKeyDown (KeyCode.Keypad2)) 
			pupilas = 2;

		if (Input.GetKeyDown (KeyCode.Keypad3)) 
			pupilas = 3;

		if (Input.GetKeyDown (KeyCode.Keypad4)) 
			pupilas = 4;

		if (Input.GetKeyDown (KeyCode.Keypad0)) 
			pupilas = 0;

		//Cejas

		if (Input.GetKeyDown (KeyCode.Z)) 
			cejas = 1;

		if (Input.GetKeyDown (KeyCode.X)) 
			cejas = 2;

		if (Input.GetKeyDown (KeyCode.C)) 
			cejas = 0;

		//Bocas

		if (Input.GetKeyDown (KeyCode.Alpha1)) 
			boca = 0;

		if (Input.GetKeyDown (KeyCode.Alpha2)) 
			boca = 1;

		if (Input.GetKeyDown (KeyCode.Alpha3)) 
			boca = 2;

		if (Input.GetKeyDown (KeyCode.Alpha4)) 
			boca = 3;

		if (Input.GetKeyDown (KeyCode.Alpha5)) 
			boca = 4;

		if (Input.GetKeyDown (KeyCode.Alpha6)) 
			boca = 5;


		if (Input.GetKeyDown (KeyCode.Space)) {
			parpados = 1;
			StartCoroutine ("Parpadeo");
		}

		if (Input.GetKeyDown (KeyCode.A)) 
			arma = 0;

		if (Input.GetKeyDown (KeyCode.S)) 
			arma = 1;

		if (Input.GetKeyDown (KeyCode.D)) 
			arma = 2;

		if (Input.GetKeyDown (KeyCode.F)) 
			arma = 3;
		
		
	}

	public void Lengua() {
	
		boca = 5;
		ojos = 1;
		cejas = 2;
		StartCoroutine ("Idle");
	}

	public void Loco(){
	
		pupilas = 4;
		cejas = 1;
		boca = 1;
		StartCoroutine ("Idle");
	}

	public void Rascarse() {
		arma = 2;
		expresiones = 1;
		StartCoroutine ("Idle");
	}

	public void Victoria() {
	
		arma = 3;
		cejas = 2;
		boca = 3;
		pupilas = 0;
        ojos = 1;
		StartCoroutine ("Idle");
	}

	public void Apuntar() {

		arma = 1;
		cejas = 1;
		boca = 3;
		pupilas = 1;
		StartCoroutine ("Idle");
	}

    public void GRandom()
    {
        boca = Random.Range(2, 4);
        cejas = Random.Range(0, 3);
        pupilas = Random.Range(0, 5);
        ojos = Random.Range(0, 5);

        int rascar = Random.Range(0, 7);

        if (rascar == 1)
        


        StartCoroutine("Idle");
    }

    public IEnumerator Idle() {

		yield return new WaitForSeconds (2f);

		pupilas = 0;
		boca = 0;
		parpados = 0;
		cejas = 0;
		expresiones = 0;
		ojos = 0;
		arma = 0;
		mano = 0;
	}

	public IEnumerator Parpadeo() {

		yield return new WaitForSeconds (0.5f);
		parpados = 0;
	}

}
