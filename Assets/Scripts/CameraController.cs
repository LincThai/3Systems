using UnityEngine;

namespace ThreeSystems.Player
{
    public class CameraController : MonoBehaviour
    {
        // Set variables
        [Header("Mouse Variable")]
        // this is for the camera sensitivity
        public float mouseSensitvity = 100f;

        [Header("Reference Variable")]
        // referencing the player transform for rotation based on camera
        public Transform playerBody;

        // a float to store the rotation value
        float xRotation = 0f;

        // Start is called before the first frame update
        void Start()
        {
            // this is to lock the cursor so the player's mouse is not moving everywhere in the screen
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            // make a local variable that stores the mouse input multiplies it by the sensitivity and then the time 
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitvity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitvity * Time.deltaTime;

            // this is to assign y mouse value up/down of camera to a variable we will clamp
            xRotation -= mouseY;

            // this is to stop the player from looking too far up or down meaning looking inside the mesh
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // to apply the rotation to this objects transform.
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            // to apply this rotation to both the player and camera on the y axis
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}