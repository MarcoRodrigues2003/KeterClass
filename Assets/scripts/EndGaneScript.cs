using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGaneScript : MonoBehaviour
{
    public void Start()
    {
        SaveSystem.DeleteSave();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Debug.Log("Sair");
        Application.Quit();
    }

}
