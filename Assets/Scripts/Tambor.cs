using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tambor : MonoBehaviour {


	[SerializeField]
	private float velocidad_giro;
	[SerializeField]
	private float limite_velocidad;
	[SerializeField]
	private float aceleracion;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Girar()
	{

		if(velocidad_giro < limite_velocidad)
		{
			velocidad_giro+= aceleracion;
		}

		transform.Rotate(new Vector3(0,0,Time.deltaTime * -velocidad_giro));
	}

	private void Parar()
	{
		if (velocidad_giro > 0)
		{
			velocidad_giro -= aceleracion * 10;
		}

		transform.Rotate(new Vector3(0, 0, Time.deltaTime * -velocidad_giro));
	}
}
