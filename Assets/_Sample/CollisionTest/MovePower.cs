using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class MovePower : MonoBehaviour
    {
        private Rigidbody rb;
        [SerializeField] private float movePower = 5f;
        private float moveX;

        public Renderer playerRenderer;
        private Color originalColor;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            playerRenderer = rb.GetComponent<Renderer>();
            originalColor = playerRenderer.material.color;
            MoveRight(moveX);
            //rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);
        }

        // Update is called once per frame
        void Update()
        {
            //입력
            //moveX = Input.GetAxis("Horizontal");
            
        }
        private void FixedUpdate()
        {
            //rb.AddForce(Vector3.right * moveX * movePower, ForceMode.Force);  //계속적인 힘
        }
        public void MoveRight(float move)
        {
            rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);
        }
        public void Moveleft(float move)
        {
            rb.AddForce(Vector3.left * movePower, ForceMode.Impulse);
        }
        public void ColorChage(Color color)
        {
            playerRenderer.material.color = color;
        }
        public void ResetColor()
        {
            playerRenderer.material.color = originalColor;
        }
    }

}
