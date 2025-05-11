using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour
{
    public GameObject CronometroGO;
    public Cronometros CronometroScript;

    public GameObject AudioFXGO;
    public AudioFX audioFXscript;

    void Start()
    {
        CronometroGO = GameObject.FindObjectOfType<Cronometros>().gameObject;
        CronometroScript = CronometroGO.GetComponent<Cronometros>();

        AudioFXGO = GameObject.FindObjectOfType<AudioFX>().gameObject;
        audioFXscript = AudioFXGO.GetComponent<AudioFX>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Jugador>() != null)
        {
            audioFXscript.FXSChoque();
            CronometroScript.Tiempo = CronometroScript.Tiempo - 15;
            Destroy(this.gameObject);
        }
    }
}
