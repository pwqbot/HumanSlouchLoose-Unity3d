using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    private float mzCoord;
    private Vector3 mOffset;

    public Transform moveObj;
    public Transform wangding;
    public Transform moveCamera;

    [SerializeField]
    Vector3 tarScale1;
    [SerializeField]
    Vector3 tarScale2;
    private Rigidbody[] kids;
    public bool state;
    bool notOnMouse = true;
    float tarRotateX = 0f;
    float tarRotateY = 0f;
    [SerializeField,Range(.1f,.3f)]
    private float sensitivityX = .1f;

    [SerializeField,Range(.1f,.3f)]
    private float sensitivityY = .1f;
    [Range(.1f, 1f)]
    public float speed = .2f;
    private Vector3 oriPosition;
    private Quaternion oriRotation;
    private void Update() {
        // oriPosition = transform.localPosition;
        // if(GameController.gameStart)
        // {
        //     wangding.position = transform.position - oriPosition;
        //     // transform.RotateAround(transform.position,transform.forward,-oriRotation.eulerAngles.z);
        //     // transform.RotateAround(transform.position,transform.right,-oriRotation.eulerAngles.x);
        //     // transform.RotateAround(transform.position,transform.up,-oriRotation.eulerAngles.y);
        //     // wangding.rotation = transform.rotation;
        //     transform.localPosition = oriPosition;
        //     transform.localRotation = oriRotation;
        // }
    }

    private void Start() {
        oriRotation = transform.localRotation;
        oriPosition = transform.localPosition;
        wangding = transform.root;
        moveCamera = GameObject.Find("Move Camera").transform;
        tarScale1 = transform.localScale * 1f;    
        tarScale2 = transform.localScale;
        kids = moveObj.GetComponentsInChildren<Rigidbody>();
        state = false;
        // Debug.Log(kids.Length);
    }

    public void Move() {
        if(GameController.rotate)
        {
            if(Input.GetKey("a"))
            {
                Vector3 rotation = new Vector3(0,speed,0);
                moveObj.transform.Rotate(rotation);
            }
            else if(Input.GetKey("d"))
            {
                Vector3 rotation = new Vector3(0,-speed,0);
                moveObj.transform.Rotate(rotation);
            }
            else if(Input.GetKey("w"))
            {
                Vector3 rotation = new Vector3(-speed,0,0);
                moveObj.transform.Rotate(rotation);
            }
            else if(Input.GetKey("s"))
            {
                Vector3 rotation = new Vector3(speed,0,0);
                moveObj.transform.Rotate(rotation);
            }
            else if(Input.GetKey("q"))
            {
                Vector3 rotation = new Vector3(0,0,speed);
                moveObj.transform.Rotate(rotation);
            }
            else if(Input.GetKey("e"))
            {
                Vector3 rotation = new Vector3(0,0,-speed);
                moveObj.transform.Rotate(rotation);
            }
        }
        else 
        {
            if(Input.GetKey("a"))
            {
                Vector3 rotation = -speed * moveCamera.right * Time.deltaTime * 3f;
                moveObj.transform.Translate(rotation, Space.World);
            }
            else if(Input.GetKey("d"))
            {
                Vector3 rotation = speed * moveCamera.right * Time.deltaTime * 3f;
                moveObj.transform.Translate(rotation, Space.World);
            }
            else if(Input.GetKey("w"))
            {
                Vector3 rotation = speed * moveCamera.forward * Time.deltaTime * 3f;
                rotation.y = 0;
                moveObj.transform.Translate(rotation, Space.World);
            }
            else if(Input.GetKey("s"))
            {
                Vector3 rotation = -speed * moveCamera.forward * Time.deltaTime * 3f; 
                rotation.y = 0;
                moveObj.transform.Translate(rotation, Space.World);
            }
            else if(Input.GetKey("q"))
            {
                Vector3 rotation = -speed * moveCamera.up * Time.deltaTime * 3f;
                moveObj.transform.Translate(rotation, Space.World);
            }
            else if(Input.GetKey("e"))
            {
                Vector3 rotation = speed * moveCamera.up * Time.deltaTime * 3f;
                moveObj.transform.Translate(rotation, Space.World);
            }
            
        }
    }

    public void OnMouseDown() {
        // foreach(Rigidbody rb in kids)
        // {
        //     rb.isKinematic = false;
        // }
        notOnMouse = false;
        mzCoord = Camera.main.WorldToScreenPoint(moveObj.transform.position).z;
        mOffset = moveObj.transform.position - GetMouseWorldPos();
        FixedJoint[] fjoints = GetComponentsInChildren<FixedJoint>();
        HingeJoint[] spjoints = GetComponentsInChildren<HingeJoint>();
        foreach(HingeJoint sp in spjoints)
        {
            Destroy(sp);
        }
        foreach(FixedJoint sp in fjoints)
        {
            Destroy(sp);
        }
        // mOffset = transform.position - GetMouseWorldPos();
    }

    public Vector3 GetMouseWorldPos()
    {
        Vector3 mousepoint = Input.mousePosition;
        mousepoint.z = mzCoord;
        return Camera.main.ScreenToWorldPoint(mousepoint);
    }

    private void OnMouseDrag() {
        // moveObj.transform.localScale = Vector3.Lerp(transform.localScale, tarScale1, Time.deltaTime);
        if(!GameController.rotate)
            moveObj.transform.position = GetMouseWorldPos() + mOffset;
        else 
        {
            tarRotateX += Input.GetAxis("Mouse X") * sensitivityX / 100f;
            tarRotateY -= Input.GetAxis("Mouse Y") * sensitivityY / 100f;


            // Quaternion tarRotation = Quaternion.Euler(tarRotateY,tarRotateX,0);  
            Vector3 rotation = Vector3.zero;
            rotation = Input.GetAxis("Mouse Y") * 3f * moveCamera.right;
            rotation -= Input.GetAxis("Mouse X") * moveCamera.forward;
            moveObj.Rotate(rotation, relativeTo:Space.World);
            // moveObj.transform.rotation = Quaternion.Slerp(transform.rotation, tarRotation, Time.deltaTime);
        }
    }

    // private void OnMouseEnter() {
    //     transform.localScale = Vector3.Lerp(transform.localScale, tarScale1, Time.deltaTime);
    // }

    private void OnMouseUp() {
        // foreach(Rigidbody rb in kids)
        // {
        //     rb.isKinematic = true;
        // }
        notOnMouse = true;
    }


}
