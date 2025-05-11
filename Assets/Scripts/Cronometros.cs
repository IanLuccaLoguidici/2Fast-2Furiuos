using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cronometros : MonoBehaviour
{
    public GameObject MotorCarreteraGO;
    public MotorCarreteras MotorCarreteraScript;

    public float Tiempo;
    public float Distancia;
    public Text txtTiempo;
    public Text txtDistancia;
    public Text txtDistanciaFinal;


    void Start()
    {
        MotorCarreteraGO = GameObject.Find("MotorCarretera");
        MotorCarreteraScript = MotorCarreteraGO.GetComponent<MotorCarreteras>();

        txtTiempo.text = "2:00";
        txtDistancia.text = "0";

        Tiempo = 120;
    }

    void Update()
    {
        if(MotorCarreteraScript.Iniciojuego==true && MotorCarreteraScript.JuegoTerminado==false)
        {
            CalculoTiempo_Distancia();
        }

        if(Tiempo <= 0 && MotorCarreteraScript.JuegoTerminado== false)
        {
            MotorCarreteraScript.JuegoTerminado = true;
            MotorCarreteraScript.JuegoTerminadoEstados();
            txtDistanciaFinal.text = ((int)Distancia).ToString() + "M";
            txtTiempo.text = "0:00";
        }

    }

    void CalculoTiempo_Distancia()
    {
        Distancia += Time.deltaTime * MotorCarreteraScript.Velociadad;
        txtDistancia.text=((int)Distancia).ToString();

        Tiempo -= Time.deltaTime;
        int minutos = (int)Tiempo/60;
        int segundos = (int)Tiempo%60;
        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2,'0');
    }

    public void Metros()
    {

        PlayerPrefs.SetFloat("Metros", Distancia);
    }
}
