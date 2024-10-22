using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
  [SerializeField] GameObject gameoverUI;
  [SerializeField] GameObject gameUI;

  [SerializeField] Button restart;
  [SerializeField] Button mainMenu;
    [SerializeField] GameObject nextLevel;

    [SerializeField] Button pause;
    [SerializeField] Button resume;

    [SerializeField] GameController gameController;

  void Start()
  {
    restart.onClick.AddListener(RestartButton);
    mainMenu.onClick.AddListener(MainMenuButton);
    pause.onClick.AddListener(PauseButton);
    resume.onClick.AddListener(ResumeButton);
  }

    private void ResumeButton()
    {
        gameController.ResumeGame();
    }

    private void PauseButton()
    {
        gameController.PauseGame();

    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SoundManager.Instance.PlaySoundEffect(Sounds.BUTTONCLICK);
        SceneManager.LoadScene(0);
    }

    private void RestartButton()
    {
        SoundManager.Instance.PlaySoundEffect(Sounds.BUTTONCLICK);
        SceneManager.LoadScene(1);
    }

    public void GameOverScreen()
  {
    gameoverUI.SetActive(true);
    gameUI.SetActive(false);
  }

  public void NextLevel()
  {
    nextLevel.SetActive(true);
    gameUI.SetActive(false);
  }


  public void Quit()
  {
        SoundManager.Instance.PlaySoundEffect(Sounds.BUTTONCLICK);
        Application.Quit();
  }
}
