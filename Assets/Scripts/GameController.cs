using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
        SoundManager.Instance.PlaySoundEffect(Sounds.BUTTONCLICK);

            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        SoundManager.Instance.PlaySoundEffect(Sounds.BUTTONCLICK);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        SoundManager.Instance.PlaySoundEffect(Sounds.BUTTONCLICK);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
