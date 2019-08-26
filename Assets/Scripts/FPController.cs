using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;

    [SerializeField] private float speed=5f;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ChangeCursorMode();
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        x *= Time.deltaTime;
        z *= Time.deltaTime;
        _rigidbody.MovePosition(new Vector3(gameObject.transform.position.x+x*speed, gameObject.transform.position.y, gameObject.transform.position.z + z * speed));
        Debug.Log(x+","+z);
    }

    private static void ChangeCursorMode()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
