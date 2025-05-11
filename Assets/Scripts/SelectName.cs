using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectName : MonoBehaviour
{
    public InputField inputText;

    public Text textoNombre;
    public Image luz;
    public GameObject boton;

    private void Awake()
    {
        luz.color = Color.red;
    }

    private void Update()
    {
        if (textoNombre.text.Length < 3)
        {
            luz.color = Color.red;
            boton.SetActive(false);
        }

        if (textoNombre.text.Length >= 3)
        {
            luz.color = Color.green;
            boton.SetActive(true);
        }
    }

    public void aceptar()
    {
        PlayerPrefs.SetString("Nombre", inputText.text);
        SceneManager.LoadScene("Top");
    }
}
