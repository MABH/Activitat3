using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {
    public MotoControl motorista;
    public Text recordText;
    public Button startButton;
    public int segundosParaEmpezar = 3;
    private Text timeText;
    private float tiempoInicial;
    private float tiempoRecord;
    public Button siguenteNivelButton;
    string textoSiguiente;
    public int escenaActual; //SceneManager.GetActiveScene().name no acaba de funcionar bien

    // Use this for initialization
    void Start () {
        Debug.Log("Inicio");
        //siguenteNivelButton.enabled = false;
        motorista.eliminado += Reiniciar;
        motorista.finalNivel += Final;
        motorista.enabled = false;
        timeText = startButton.GetComponentInChildren<Text>();
        textoSiguiente = "Inicio";

        //if (escenaActual==1)
        if (SceneManager.GetActiveScene().name.CompareTo("Escena 2") != 0)
        {
            tiempoRecord = PlayerPrefs.GetFloat("tiempo record", 0);
        }
        else
            tiempoRecord = PlayerPrefs.GetFloat("tiempo record 2", 0);

        if (tiempoRecord > 0) recordText.text = "Record: " + tiempoRecord.ToString("##.##");
        recordText.enabled = false;

        /*if (SceneManager.GetActiveScene().name.CompareTo("Escena 2") == 0)
        {
            StartGame();
        }*/

    }
	
	void Reiniciar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.
            SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {       
        startButton.enabled = false;
        timeText.text = "" + segundosParaEmpezar;
        InvokeRepeating("CuentaAtras", 1, 1);
    }

    void CuentaAtras()
    {
        segundosParaEmpezar--;
        if (segundosParaEmpezar <= 0)
        {
            CancelInvoke();
            JuegoEmpezado();
        }
        else timeText.text = "" + segundosParaEmpezar;
    }

    void JuegoEmpezado()
    {
        motorista.enabled = true;
        tiempoInicial = Time.time;
        if (tiempoRecord > 0) recordText.enabled = true;
    }

    private void Update()
    {        
            if (motorista.enabled)
            {
                timeText.text = "Tiempo: " + (Time.time -
                    tiempoInicial).ToString("##.##");
            }
      
    }

    void Final()
    {
        Debug.Log("Final ");
        motorista.enabled = false;
        timeText.text = "Final! " + (Time.time - tiempoInicial);

        if (SceneManager.GetActiveScene().name.CompareTo("Escena 2") != 0) //Si no es escena 2 guarda el tiempo y activa el botón siguiente
        {
            Debug.Log("Boton siguiente para escena 1");
            PlayerPrefs.SetFloat("tiempo record", (Time.time - tiempoInicial));
            siguenteNivelButton.gameObject.SetActive(true);
        }
        else                                                               //Si es escena 2 guarda el tiempo 2 y activa el botón siguiente
        {
            Debug.Log("Boton siguiente para escena 2");
            PlayerPrefs.SetFloat("tiempo record 2", (Time.time - tiempoInicial));
            siguenteNivelButton.gameObject.SetActive(true);
            siguenteNivelButton.gameObject.GetComponentInChildren<Text>().text = textoSiguiente;
        }
    }

    public void CargarEscena(int nivel)
    {
        Debug.Log("Cargar escena: " + nivel);
        if (nivel == 2)
        {
            SceneManager.LoadScene("Escena 2");
        }
        else
        {            
            SceneManager.LoadScene("Escena 1");
        }
    }
}
