using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fundidos : MonoBehaviour
{
    public Image Fundido;
    public string[] Escenas;


    void Start()
    {
        Fundido.CrossFadeAlpha(0,0.5f,false);
    }

    public void FadeOut(int s)
    {
        Fundido.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine(CambiarEscena(Escenas[s]));
    }

    IEnumerator CambiarEscena(string Escena)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Escena);
    }
}
