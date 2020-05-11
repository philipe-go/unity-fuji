using UnityEngine;

namespace Assets.Scripts
{
    public class BallCharacter : MonoBehaviour
    {
        [SerializeField] private GameObject plattform;
        private GameManager manager;
        private Rigidbody2D rb;
        private Vector3 initialPos;
        private bool initState = true;
        private float applyForce = 200f;
        [Range(0,15f)] public float applyVelocity = 2f;
        private Vector2 newVel;
        private float maxVeloc = 6f;
        public float velXRatio = 2.5f;
        public float velYRatio = 2.5f;

        private AudioSource audioS;
        [SerializeField] private AudioClip sfx;
        public bool ballSound;

        private void Start()
        {
            audioS = GetComponent<AudioSource>();
            plattform = GameObject.Find("BallPlaceHolder");
            rb = GetComponent<Rigidbody2D>();
            manager = FindObjectOfType<GameManager>();
            InitializeBall();
        }

        private void Update()
        {
            if (!manager.pause)
            {
                if ((Input.GetButtonDown("Jump")) && (initState))
                {
                    initState = false;
                    rb.simulated = true;
                    rb.transform.parent = null;
                    rb.AddForce(new Vector2(applyForce * (transform.position.x + 1.5f) * Time.deltaTime, applyForce));
                }
            }
            else
            {
                Time.timeScale = 0;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Plattform")
            {
                float varPosX = transform.position.x - collision.transform.position.x;
                
                if (rb.velocity.x < velXRatio)
                {
                    rb.velocity  = new Vector2(applyVelocity, rb.velocity.y * applyVelocity);
                }
                else if (rb.velocity.y < velYRatio)
                {
                    rb.velocity = new Vector2(rb.velocity.x * applyVelocity, applyVelocity);
                }

                if (varPosX > 0.9)
                {
                    rb.velocity = new Vector2(2f * Mathf.Abs(rb.velocity.x), rb.velocity.y * applyVelocity);
                }
                else if (varPosX > 0.75)
                {
                    rb.velocity = new Vector2(1.5f * Mathf.Abs(rb.velocity.x), rb.velocity.y * applyVelocity);
                }
                else if (varPosX < -0.9)
                {
                    rb.velocity = new Vector2(-2f * Mathf.Sign(rb.velocity.x), rb.velocity.y * applyVelocity);
                }
                else if (varPosX < -0.75)
                {
                    rb.velocity = new Vector2(-1.5f * Mathf.Sign(rb.velocity.x), rb.velocity.y * applyVelocity);
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * applyVelocity);
                }
            }

            if (collision.gameObject.tag == "Field")
            {
                if (rb.velocity.y < velYRatio)
                {
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * applyVelocity);
                }
            }


            //rb.AddForce(rb.velocity, ForceMode2D.Force);
            MaxVelCheck();
            Debug.Log(rb.velocity.normalized);
            if (ballSound) audioS.PlayOneShot(sfx);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "DeathZone")
            {
                manager.LifesHandler();
                if (manager.lives > 0)
                {
                    manager.AddScore(-50);
                    InitializeBall();
                }
                else { Destroy(gameObject); }
            }
        }

        public void InitializeBall()
        {
            rb.transform.SetParent(plattform.transform, true);
            transform.localScale = Vector3.one;
            transform.localPosition = new Vector3(transform.parent.position.x, initialPos.y, 0);
            rb.simulated = false;
            rb.velocity = new Vector2(0, 0);
            manager.currentBall = this.gameObject;
            initState = true;
        }

        public void MaxVelCheck()
        {
            if (rb.velocity.x > maxVeloc) rb.velocity = new Vector2(maxVeloc, rb.velocity.y); 
            if (rb.velocity.y > maxVeloc) rb.velocity = new Vector2(rb.velocity.x, maxVeloc);
        }
    }

}
