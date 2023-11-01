using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject  tutoria;
    public GameObject teclado;
    public GameObject controle;
    void Start()
    {
        Time.timeScale = 0;  
    }

   public void sairtutorial()
    {
        tutoria.SetActive(false);
        Time.timeScale = 1;
    }
    public void abrirteclado()
    {
        teclado.SetActive(true);
       
    }
    public void sairteclado()
    {
        teclado.SetActive(false);
        tutoria.SetActive(true);
    }
    public void  abrircontrole()
    {
        controle.SetActive(true);
       
    }
    public void saircontrole()
    {
        controle.SetActive(false);
        tutoria.SetActive(true);
    }
    void Update()
    {
        
    }
}
