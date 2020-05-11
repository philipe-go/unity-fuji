using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class PaddleCharacter : MonoBehaviour
    {
        private float speed = 10f;
        private GameManager manager;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            manager = GameManager.instance;
        }

        void FixedUpdate()
        {
            Movement();
        }

        void Movement()
        {
            if (Input.GetButton("Horizontal"))
            {
                Vector3 inputPlat = new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);

                this.transform.Translate(inputPlat * Time.deltaTime);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}