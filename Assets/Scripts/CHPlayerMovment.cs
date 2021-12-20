using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHPlayerMovment : MonoBehaviour
{
    [SerializeField] CharacterController CH;
    [SerializeField] float MoveSpeed;
    [SerializeField] float RunSpeed;
    private Vector3 dir;
    void Start()
    {
        
    }

    
    void Update()
    {
        PlayerMovment();
    }

    private void PlayerMovment()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        dir = transform.right * horiz  + transform.forward * vert ;
        if(dir.magnitude != 0)
        {
            CH.Move(dir.normalized * MoveSpeed * Time.deltaTime);
        }
        Running();


    }

    private void Running()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            CH.Move(dir.normalized * RunSpeed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            CH.Move(dir.normalized * MoveSpeed * Time.deltaTime);
        }
    }
}
