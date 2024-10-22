using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // For scene loading

public class PointSystem : MonoBehaviour
{
    public int totalPointsNeeded = 10;
    private int currentPoints = 1;   
    [SerializeField] Text text;
    [SerializeField] GameUI gameUI;


    void Start()
    {
        currentPoints = 0; 
    }

    public void AddPoint()
    {
        totalPointsNeeded--;
        text.text = "Remaining : " + totalPointsNeeded.ToString() ;
     
        Debug.Log("Points Collected: " + currentPoints);
        if (totalPointsNeeded<=0)
        {
            SoundManager.Instance.PlaySoundEffect(Sounds.LevelCOMPLETE);
          gameUI.NextLevel();
        }
    }


}
