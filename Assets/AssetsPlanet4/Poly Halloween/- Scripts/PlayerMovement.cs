using UnityEngine;

namespace Polyperfect.Universal
{
    public class PlayerMovement : MonoBehaviour
    {

        public CharacterController controller;
        public float speed = 12f;
        public float gravity = -9.81f;
        public float jumpHeight = 3f;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;


        Vector3 velocity;
        bool isGrounded;

        // Update is called once per frame
        void Update()
        {
            controller = GetComponent<CharacterController>();
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                controller.slopeLimit = 45.0f;
                velocity.y = -2f;
            }


            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            if (move.magnitude > 1)
                move /= move.magnitude;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)

            {
                controller.slopeLimit = 100.0f;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }



            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);




        }
    }
}