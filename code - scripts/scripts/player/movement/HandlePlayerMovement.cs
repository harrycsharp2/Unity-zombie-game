using System.Xml.Serialization;
using UnityEngine;
using TMPro;

public class HandlePlayerMovement : MonoBehaviour
{
     float mouseSensitivity = 2f;
    public Transform playercamera;
    public GameObject arm;
    public float armMoveAmount = 0.5f;
    Vector3 armStartPosition;
    float xrotation = 0f;

    bool isrunning = false;
    public TMP_Text stamtext;
    public static float stamina = 100f;

     float speed = 0f;
     float walkspspeed = 5f;
     float runspeed = 10f;

    float xinput;
    float zinput;
    Rigidbody rb;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        speed = walkspspeed;
         rb = GetComponent<Rigidbody>();
        armStartPosition = arm.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        playercamera.localRotation = Quaternion.Euler(xrotation, 0f, 0f);

        float lookamount = xrotation / 90f;
        Vector3 armpostition = armStartPosition;
        armpostition.y += lookamount * armMoveAmount;
        arm.transform.localPosition = armpostition;

        xinput = 0;
        zinput = 0;
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && stamina >= 10)
        {
            speed = runspeed;
            isrunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkspspeed;
            isrunning = false;
        }
        if (stamina <=10)
        {
            speed = walkspspeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            zinput = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            zinput = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xinput = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xinput = 1;
        }

    }

    void FixedUpdate()
    {
        stamtext.text = $"{stamina.ToString()}";
        if (isrunning)
        {
            if (stamina >= 0)
            {
                stamina--;
            }
        }
        if (!isrunning)
        {
            if (stamina <=99)
            {
                stamina++;
            }
        }
        Vector3 movement = transform.right * xinput + transform.forward * zinput;

        rb.linearVelocity = new Vector3(
            movement.x * speed,
            rb.linearVelocity.y,
            movement.z * speed
        );
    }
}
