using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManagerL3 : MonoBehaviour
{

    public void menu()
    {
        //Código relativo ao carregamento do menu 
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        //recarregar o nivel
        SceneManager.LoadScene("CausticLevel");
    }
}
