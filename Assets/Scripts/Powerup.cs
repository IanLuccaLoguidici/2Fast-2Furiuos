using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject CronometroGO;
    public Cronometros CronometroScript;

    public GameObject AudioFXGO;
    public AudioFX audioFXscript;

    // Start is called before the first frame update
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
            audioFXscript.FXS_POWER_UP();
            CronometroScript.Tiempo = CronometroScript.Tiempo + 20;
            Destroy(this.gameObject);
        }
    }
}
