using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public void retry()
    {
        //recarregar o nivel
        SceneManager.LoadScene("Teste");
    }

    public void Menu()
    {
        //Volta ao menu
        SceneManager.LoadScene("Menu");
    }
}
