using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BotonCambioNivel : MonoBehaviour {

    [SerializeField]
    private string nombre_nivel;

    public void CambiarNivel()
    {
        SceneManager.LoadScene(nombre_nivel);
    }
}
