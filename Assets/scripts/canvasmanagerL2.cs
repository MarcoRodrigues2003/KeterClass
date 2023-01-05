using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class canvasmanagerL2 : MonoBehaviour
{
    public string thisScene;

    public static bool GameIsPaused = false;

    public GameObject Menu;

    public GameObject Player2;

    public Image CoopButton;

    public bool CoopBool;

    public PlayerMovement Player;

    public GameObject ResumeButton;

    public Text GameOverText;

    public Text Lives;
    public string livesText;


    private void Update()
    {
        //Código para ativar/desativar o menu de pausa ou o menu de Game Over bem como atualizar o numero de vidas
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameOverText.text = "Pause Menu";

            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Player.Isdead == true)
        {
            GameOverText.text = "Game Over";
            ResumeButton.SetActive(false);
        }

        LifesText();
    }

    public void Start()
    {
        //código para assinalar os valores iniciais de certas variáveis
        GameIsPaused = false;
        Time.timeScale = 1f;
        thisScene = (SceneManager.GetActiveScene().name);
        SaveSystem.SaveLevel(this);
    }

    public void menu()
    {
        //Código relativo ao carregamento do menu 
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    { 
        //recarregar o nivel
        SceneManager.LoadScene(thisScene);
    }


    public void Resume()
    {
        //Código relativo a recomeçar o jogo após a pausa
        Menu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        //Código relativo a pausa do jogo
        Menu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Coop()
    {
        //Código relativo ao botão de coop
        if (CoopBool == false)
        {
            CoopButton.color = Color.green;
            Player2.SetActive(true);
            CoopBool = true;
        }
        else
        {
            CoopButton.color = Color.red;
            Player2.SetActive(false);
            CoopBool = false;
        }
    }

    public void LifesText()
    {
        //Código para o texto das vidas

        livesText = Player.life.ToString();

        Lives.text = "Lives: " + livesText;
    }
}
