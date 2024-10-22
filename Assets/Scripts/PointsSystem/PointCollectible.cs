using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollectible : MonoBehaviour
{
     private PointSystem pointSystem; 

    void Start()
    {
        pointSystem = FindObjectOfType<PointSystem>();
    }

       void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySoundEffect(Sounds.STONECOLLECT);
            pointSystem.AddPoint();
            Destroy(gameObject);    
        }
    }
}
