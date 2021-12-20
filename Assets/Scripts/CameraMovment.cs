using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField] float CameraSpeed;
    [SerializeField] float MaxYLook;
    [SerializeField] float MinYLook;
    [SerializeField] Transform Player;
    private float  yAxis;
    private bool FreezeCamera = true;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yAxis = 0 ;
      
    }
    void Start()
    {
        Invoke("UnfreezeCamera", 0.5f);
    }
    void LateUpdate()
    {
        if (FreezeCamera) return;
        float mouseX = Input.GetAxis("Mouse X") * CameraSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * CameraSpeed * Time.deltaTime;
        
         yAxis -= mouseY;
         yAxis = Mathf.Clamp(yAxis, MinYLook, MaxYLook);
      
        transform.localRotation = Quaternion.Euler(yAxis, 0, 0);
        
        Player.Rotate(Vector3.up * mouseX);
    }
    private void UnfreezeCamera()
    {
        FreezeCamera = false;
    }
}
