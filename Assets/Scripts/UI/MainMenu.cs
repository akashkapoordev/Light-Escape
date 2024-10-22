using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{

    [SerializeField] Button play;
    [SerializeField] Button quit;
    [SerializeField] Button back;
    [SerializeField] GameObject instruction;
    [SerializeField] Button instructionButton;
    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(PlayGame);
        quit.onClick.AddListener(QuitGame);
        back.onClick.AddListener(BackButton);
        instructionButton.onClick.AddListener(InstructionButton);
    }

    private void BackButton()
    {
        SoundManager.Instance.PlaySoundEffect(Sounds.BUTTONCLICK);
    }

    void PlayGame()
    {
        SoundManager.Instance.PlaySoundEffect(Sounds.BUTTONCLICK);
        SceneManager.LoadScene(1);
    }

    void InstructionButton()
    {
        SoundManager.Instance.PlaySoundEffect(Sounds.BUTTONCLICK);
        instruction.SetActive(true);

    }

    void QuitGame()
    {
        SoundManager.Instance.PlaySoundEffect(Sounds.BUTTONCLICK);        
        Application.Quit();
    }
}
