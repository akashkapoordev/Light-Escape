using UnityEngine;

public class RandomLightController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Vector2 minPosition = new Vector2(-5, -5);
    [SerializeField] private Vector2 maxPosition = new Vector2(5, 5);
    [SerializeField] private CharacterController characterController;
    
    private Vector2 targetPosition;

    void Start()
    {
        SetRandomTargetPosition();
    }

    void Update()
    {
        MoveLight();
    }

    void MoveLight()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(minPosition.x, maxPosition.x);
        float randomY = Random.Range(minPosition.y, maxPosition.y);
        targetPosition = new Vector2(randomX, randomY);
        Debug.Log("New target position: " + targetPosition);
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySoundEffect(Sounds.HIT);
            characterController.HealthDecrease();
            Debug.Log("Player died with random Light");
        }
    }
}
