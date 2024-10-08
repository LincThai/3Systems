using UnityEngine;

namespace ThreeSystems.Player
{
    public class PlayerController : MonoBehaviour
    {
        // set variables
        // this is cause we are using the character controller for our movement
        [Header("References")]
        public CharacterController controller;

        // this is for the numerical values of both movement and jump 
        [Header("Movement")]
        public float speed = 5f;
        public float jumpHeight = 2f;
        // this is the value of gravity for moving the player back down
        public float gravity = -9.8f;

        // the variables are for us to chack if the player is grounded
        // meaning they are touching/on the ground
        [Header("Ground")]
        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        // this is local variables to check and apply some of the float values above
        Vector3 velocity;
        bool isGrounded;

        // Update is called once per frame
        void Update()
        {
            // this is to assign a true or false value to the bool isGrounded based on
            // whether or not there was something found in the checksphere
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            // this is to ensure that player object is firmly on the ground
            if (isGrounded && velocity.y < 0f)
            {
                velocity.y = -2f;
            }

            // Get variables for imput values
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            // asign a vector 3 variable with the movement input
            Vector3 move = transform.right * x + transform.forward * y;

            // I am using the Move function on the Character Controller to move based on input
            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            // this will push the player down to the ground
            velocity.y += gravity * Time.deltaTime;

            // use the move function to apply gravity
            controller.Move(velocity * Time.deltaTime);
        }
    }
}