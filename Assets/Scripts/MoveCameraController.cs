using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Range(1,100)]
    private float speed = 1f;
    [SerializeField,Range(0f,2f)]
    private float sensitivityX = 1f;

    [SerializeField,Range(0f,2f)]
    private float sensitivityY = 1f;
    [SerializeField, Range(0,150)]
    private float limitAngleY = 120f;

    [SerializeField]
    Vector3 limitPos;

    [SerializeField]
    Vector3 beginPos;
    private Vector3 limitField;


    float tarRotateX = 0f;
    float tarRotateY = 0f;
    float tarHeight;

    void Start()
    {
        // transform.position = beginPos;
        tarRotateY = transform.position.y;
        tarRotateX = transform.position.x;
        tarHeight = transform.position.y;
        beginPos = transform.position;
    }

    // Update is called once per frameM
    void Update()
    {
        // Debug.Log(Input.GetMouseButtonDown(1));
        if(Input.GetMouseButton(1))
            Move();
    }

    public void Move() 
    {
        if (Input.GetMouseButton(1))
        {
            rotateCamera();
        }
        moveCamera();

        // done!
    }

    private void rotateCamera()
    {
        tarRotateX += Input.GetAxis("Mouse X") * sensitivityX;
            tarRotateY -= Input.GetAxis("Mouse Y") * sensitivityY;

            tarRotateY = Mathf.Clamp(tarRotateY, -limitAngleY, limitAngleY);

            Quaternion tarRotation = Quaternion.Euler(tarRotateY,tarRotateX,0);  
            transform.rotation = Quaternion.Slerp(transform.rotation, tarRotation, Time.deltaTime * 2f);
    }

    private void moveCamera()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float oriY = transform.position.y;
        transform.Translate(new Vector3(h,0,v) * Time.deltaTime * speed);
        transform.Translate(Vector3.forward* scroll * speed * 10f * Time.deltaTime);
        float gap = transform.position.y - oriY;
        tarHeight += gap;

        if(Input.GetKey("e"))
        {
            tarHeight += speed / 2 * Time.deltaTime;
            // transform.Translate(Vector3.up * speed / 5 * Time.deltaTime, Space.World);
        }
        else if(Input.GetKey("q"))
        {
            tarHeight -= speed / 2 * Time.deltaTime;
            // transform.Translate(-Vector3.up * speed / 5 * Time.deltaTime, Space.World);
        }
        transform.position = new Vector3(transform.position.x,Mathf.Lerp(transform.position.y, tarHeight, Time.deltaTime * 6f),transform.position.z);

        var x = Mathf.Clamp(transform.position.x, beginPos.x -limitPos.x, beginPos.x + limitPos.x);
        var y = Mathf.Clamp(transform.position.y, beginPos.y -limitPos.y, beginPos.y + limitPos.y);
        var z = Mathf.Clamp(transform.position.z, beginPos.z -limitPos.z, beginPos.z + limitPos.z);
        transform.position = new Vector3(x,y,z);
    }
}
