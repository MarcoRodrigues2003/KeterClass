using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{

    public AudioMixer MainAudioMixer;

    public GameObject PlayButton;
    public GameObject MenuButton;
    public GameObject QuitButton;
    public GameObject LoadButton;

    public GameObject MainSoundSlider;
    public GameObject MusicSlider;
    public GameObject SFXSlider;
    public GameObject MainSoundText;
    public GameObject MusicSoundText;
    public GameObject SFXText;
    public GameObject BackToMenuButton;


    public void Start()
    {
        //código para assinalar os valores iniciais dos objetos de jogo
        PlayButton.SetActive(true);
        MenuButton.SetActive(true);
        QuitButton.SetActive(true);
        LoadButton.SetActive(true);

        MainSoundSlider.SetActive(false);
        MusicSlider.SetActive(false);
        SFXSlider.SetActive(false);
        MainSoundText.SetActive(false);
        MusicSoundText.SetActive(false);
        SFXText.SetActive(false);
        BackToMenuButton.SetActive(false);
    }


    public void PlayGame()
    {
        //Carregar o primeiro nivel
        SceneManager.LoadScene("Level1");
    }

    public void LoadGame()
    {
        //Carregar o save file se este existir
        PlayerData data = SaveSystem.LoadLevel();
        SceneManager.LoadScene(data.Level);
    }

    public void OptionsMenu()
    {
        //Carrega o menu das opções
        PlayButton.SetActive(false);
        MenuButton.SetActive(false);
        QuitButton.SetActive(false);
        LoadButton.SetActive(false);

        MainSoundSlider.SetActive(true);
        MusicSlider.SetActive(true);
        SFXSlider.SetActive(true);
        MainSoundText.SetActive(true);
        MusicSoundText.SetActive(true);
        SFXText.SetActive(true);
        BackToMenuButton.SetActive(true);
    }

    public void SetMainVolume(float volume)
    {
        //Slider do volume geral
        MainAudioMixer.SetFloat("volume", volume);
    }

    public void SetMusicVolume(float MusicVolume)
    {
        //Slider do volume da música
        MainAudioMixer.SetFloat("Music", MusicVolume);
    }

    public void SetSFXVolume(float SFXVolume)
    {
        //Slider do volume dos efeitos sonoros
        MainAudioMixer.SetFloat("SFX", SFXVolume);
    }

    public void BackToMenu ()
    {
        //Código de voltar ao menu principal
        PlayButton.SetActive(true);
        MenuButton.SetActive(true);
        QuitButton.SetActive(true);
        LoadButton.SetActive(true);

        MainSoundSlider.SetActive(false);
        MusicSlider.SetActive(false);
        SFXSlider.SetActive(false);
        MainSoundText.SetActive(false);
        MusicSoundText.SetActive(false);
        SFXText.SetActive(false);
        BackToMenuButton.SetActive(false);
    }

    public void Quit()
    {
        //Sair do jogo
        Debug.Log("Sair");
        Application.Quit();
    }

}
