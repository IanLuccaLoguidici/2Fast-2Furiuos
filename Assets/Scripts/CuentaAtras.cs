using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public GameObject MotorCarreteraGO;
    public MotorCarreteras MotorCarreteraScript;

    public Sprite[] Numeros;

    public GameObject ContadorNumerosGO;
    public SpriteRenderer ContadorNumerosComp;

    public GameObject ControladorJugadorGO;
    public GameObject JugadorGO;
    // Start is called before the first frame update
    void Start()
    {
        InicioComponentes();
    }

    void InicioComponentes()
    {
        MotorCarreteraGO = GameObject.Find("MotorCarretera");
        MotorCarreteraScript = MotorCarreteraGO.GetComponent<MotorCarreteras>();

        ContadorNumerosGO = GameObject.Find("ContadorNumeros");
        ContadorNumerosComp = ContadorNumerosGO.GetComponent<SpriteRenderer>();

        JugadorGO = GameObject.Find("Jugador");
        ControladorJugadorGO = GameObject.Find("ControladorJugador");

        InicioCuentaAtras();
    }

    void InicioCuentaAtras()
    {
        StartCoroutine(Contando());
    }

    IEnumerator Contando()
    {
        ControladorJugadorGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        ContadorNumerosComp.sprite = Numeros[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        ContadorNumerosComp.sprite = Numeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        ContadorNumerosComp.sprite = Numeros[3];
        MotorCarreteraScript.Iniciojuego = true;
        JugadorGO.GetComponent<AudioSource>().Play();
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        ContadorNumerosGO.SetActive(false);
    }

    void Update()
    {
        
    }
}
