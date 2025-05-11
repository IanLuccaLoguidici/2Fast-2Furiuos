using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Top : MonoBehaviour
{

    public Text uno;
    public Text dos;
    public Text tres;

    public float D_uno = 0;
    public float D_dos = 0;
    public float D_tres = 0;
    

    public void Awake()
    {
        Loaddata();
        float Metros=PlayerPrefs.GetFloat("Metros");
        string Name= PlayerPrefs.GetString("Nombre");

        if (D_uno < Metros)
        {
            if (uno.text != "1")
            {
                if(dos.text != "2") 
                {
                 tres.text = dos.text;
                }
                dos.text = uno.text;
            }

            D_uno = Metros;
            uno.text = Name + " " + (int)Metros;


        }
        else
        {
            if (D_dos < Metros)
            {
                if (dos.text != "2")
                {
                    tres.text = dos.text;
                }
                D_dos = Metros;
                dos.text = Name + " " + (int)Metros;

            }
            else
            {
                if (D_tres < Metros)
                {
                    D_tres = Metros;
                    tres.text = Name + " " + (int)Metros;

                }
            }
        }




    }

    private void OnDestroy()
    {
        Savedata();
    }

    private void Savedata()
    {
        PlayerPrefs.SetString("Uno",uno.text);
        PlayerPrefs.SetString("Dos", dos.text);
        PlayerPrefs.SetString("Tres", tres.text);

        PlayerPrefs.SetFloat("D1", D_uno);
        PlayerPrefs.SetFloat("D2", D_dos);
        PlayerPrefs.SetFloat("D3", D_tres);
    }

    private void Loaddata()
    {
        uno.text = PlayerPrefs.GetString("Uno");
        dos.text = PlayerPrefs.GetString("Dos");
        tres.text = PlayerPrefs.GetString("Tres");

        D_uno = PlayerPrefs.GetFloat("D1");
        D_dos = PlayerPrefs.GetFloat("D2");
        D_tres = PlayerPrefs.GetFloat("D3");
    }

    public void reset()
    {
        uno.text = "1";
        dos.text = "2";
        tres.text = "3";
        D_uno = 0;
        D_dos = 0;
        D_tres = 0;

    }
}
