using UnityEngine;
using System.Collections;


namespace TMPro.Examples
{
    
    public class CameraController : MonoBehaviour
    {
        private bool doMovement = true;
        public float panSpeed = 30f;
        public float panBorderThickness = 10f;
        public float scrollSpeed = 10f;

        public float minZ = -10f;
        public float maxZ = -70f;
        private void Update()
        {
            if (GameManager.gameIsOver)
            {
                this.enabled = false;
                return;
            }


            if (Input.GetKeyDown(KeyCode.Escape))
                doMovement = !doMovement;
           
            if (!doMovement)
                return;

            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                transform.Translate(Vector2.up * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            {
                transform.Translate(Vector2.down * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                transform.Translate(Vector2.right * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            {
                transform.Translate(Vector2.left * panSpeed * Time.deltaTime, Space.World);
            }

            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
            Vector3 pos = transform.position;

            pos.z -= -scrollWheel * 300 * scrollSpeed * Time.deltaTime;
            pos.z = Mathf.Clamp(pos.z, maxZ, minZ); 
            transform.position = pos;

        }
    }
}