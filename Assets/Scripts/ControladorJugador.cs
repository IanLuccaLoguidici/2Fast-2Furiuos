using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    public GameObject JugadorGO;

    public float AngulodeGiro;
    public float Velocidad;

    // Start is called before the first frame update
    void Start()
    {
        JugadorGO = GameObject.FindObjectOfType<Jugador>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float giroenz=0;
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal")*Velocidad * Time.deltaTime);
        giroenz = Input.GetAxis("Horizontal")* -AngulodeGiro;

        JugadorGO.transform.rotation = Quaternion.Euler(0,0,giroenz);
    }
}
