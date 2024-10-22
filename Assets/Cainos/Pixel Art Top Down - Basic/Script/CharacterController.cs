using UnityEngine;
public class CharacterController : MonoBehaviour
    {

        public float speed;

        private Animator animator;
        int playerHealth = 2;
        [SerializeField] private UnityEngine.UI.Image[] healthSprite;
        [SerializeField] private GameUI gameUI;
        

        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }

     public void HealthDecrease()
    {
        if (playerHealth >= 0)
        {
            Debug.Log(playerHealth);
            healthSprite[playerHealth].enabled = false;
            playerHealth--;
            this.transform.position = new Vector3(-7, -8, 0);
        }

        if(playerHealth<0)
        {
            SoundManager.Instance.PlaySoundEffect(Sounds.GAMEOVER);
            Debug.Log("GameOver");
            gameUI.GameOverScreen();
        }
    }
    }

