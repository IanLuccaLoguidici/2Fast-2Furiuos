using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour
{
    public GameObject ContenedorCallesGO;
    public GameObject[] ContenedorCallesGOArray;

    public float Velociadad;
    public bool Iniciojuego;
    public bool JuegoTerminado;

    public int Contadorcalles = 0;
    public int NumeroSelectorCalles;

    public GameObject CalleAnterior;
    public GameObject CalleNueva;

    public float TamañoCalle;

    public Vector3 MedidaLimitePantalla;
    public bool SalirPantalla;
    public GameObject mCamGo;
    public Camera mCamComp;

    public GameObject JugadorGO;
    public GameObject AudioFXGO;
    public AudioFX AudioFXscript;
    public GameObject bgFinalGO;

    // Start is called before the first frame update
    void Start()
    {
        InicioJuego();
    }

    void InicioJuego()
    {
        ContenedorCallesGO = GameObject.Find("ContenedorCalles");
        mCamGo = GameObject.Find("MainCamera");
        mCamComp = mCamGo.GetComponent<Camera>();

        bgFinalGO = GameObject.Find("PanelFinal");
        bgFinalGO.SetActive(false);

        AudioFXGO = GameObject.Find("AudioFX");
        AudioFXscript = AudioFXGO.GetComponent<AudioFX>();

        JugadorGO = GameObject.FindObjectOfType<Jugador>().gameObject;

        VelocidadMotorCarretera();
        MedirPantalla();
        BuscoCalles();
        
    }

    public void JuegoTerminadoEstados()
    {
        JugadorGO.GetComponent<AudioSource>().Stop();
        AudioFXscript.FXSMusic();
        bgFinalGO.SetActive(true);
    }

    void VelocidadMotorCarretera()
    {
        Velociadad = 18;
    }

    void BuscoCalles()
    {
        ContenedorCallesGOArray = GameObject.FindGameObjectsWithTag("Calle");
        for(int i=0; i<ContenedorCallesGOArray.Length; i++)
        {
            ContenedorCallesGOArray[i].gameObject.transform.parent=ContenedorCallesGO.transform;
            ContenedorCallesGOArray[i].SetActive(false);
            ContenedorCallesGOArray[i].gameObject.name = "CalleOff_" + i;
        }
        CrearCalles();
    }

    void CrearCalles()
    {
        Contadorcalles++;
        NumeroSelectorCalles = Random.Range(0, ContenedorCallesGOArray.Length);
        GameObject Calle = Instantiate(ContenedorCallesGOArray[NumeroSelectorCalles]);
        Calle.SetActive(true);
        Calle.name = "Calle" + Contadorcalles;
        Calle.transform.parent = gameObject.transform;
        PosicionCalles();
    }

    void PosicionCalles()
    {
        CalleAnterior = GameObject.Find("Calle" + (Contadorcalles - 1));
        CalleNueva = GameObject.Find("Calle" + Contadorcalles);
        MedirCalles();
        CalleNueva.transform.position = new Vector3(CalleAnterior.transform.position.x, CalleAnterior.transform.position.y + TamañoCalle, 0);
    }

    void MedirCalles()
    {
        for(int i = 0; i<CalleAnterior.transform.childCount;i++)
        {
            if(CalleAnterior.transform.GetChild(i).gameObject.GetComponent<Piezas>() != null)
            {
                float TamañoPieza = CalleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                TamañoCalle = TamañoCalle + TamañoPieza;
            }
        }
    }

    void MedirPantalla()
    {
        MedidaLimitePantalla = new Vector3(0,mCamComp.ScreenToWorldPoint(new Vector3(0,0,0)).y-0.5f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Iniciojuego==true && JuegoTerminado == false) 
        {
            transform.Translate(Vector3.down * Velociadad * Time.deltaTime);
            if (CalleAnterior.transform.position.y + TamañoCalle < MedidaLimitePantalla.y && SalirPantalla == false)
            {
                SalirPantalla = true;
                DestruyoCalles();
            }
        }
        
    }

    void DestruyoCalles()
    {
        Destroy(CalleAnterior);
        TamañoCalle = 0;
        CalleAnterior = null;
        SalirPantalla=false;
        CrearCalles();
    }
}
