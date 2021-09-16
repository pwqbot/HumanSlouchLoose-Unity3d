using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ForceControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform moveCamera;
    private float mzCoord;
    private Vector3 mOffset;

    public Transform moveObj;

    private Rigidbody[] kids;
    public CharacterJoint[] joints;
    public Transform spin;

    public SoftJointLimit[] joints2;
    private Rigidbody myRb;
    bool notOnMouse = true;
    private int mode = 0;
    private float mx = 0f;
    private float my = 0f;
    private Queue<float> qx;
    private Queue<float> qy;
    private Quaternion rotated;
    private Vector3 from;
    private void Awake() {
        spin = this.transform.root;
        rotated = new Quaternion();
        // from = transform.rotation;
        qx = new Queue<float>();
        qy = new Queue<float>();
        // spin = GameObject.Find("spine_03").transform;
        moveCamera = GameObject.Find("Move Camera").transform;
        // kids = moveObj.GetComponentsInChildren<Rigidbody>();
        kids = moveObj.GetComponentsInChildren<Rigidbody>();
        joints = moveObj.GetComponentsInChildren<CharacterJoint>();
        joints2 = new SoftJointLimit[joints.Length * 4];
        // joints2 = (CharacterJoint [])joints.Clone();
        for(int i = 0; i < joints.Length; i++)
        {
            joints2[i * 4] = joints[i].lowTwistLimit;
            joints2[i * 4 + 1] = joints[i].highTwistLimit;
            joints2[i * 4 + 2] = joints[i].swing1Limit;
            joints2[i * 4 + 3] = joints[i].swing2Limit;
        }
        myRb = moveObj.GetComponent<Rigidbody>();
        // Debug.Log(kids.Length);
    }

    private void Update() {
        // if(notOnMouse && Vector3.Distance(transform.localScale, tarScale2) > 0.01f)
        // {
        //     transform.localScale = Vector3.Lerp(transform.localScale, tarScale2, Time.deltaTime * 5f);
        // }
    }

    public Vector3 GetMouseWorldPos()
    {
        Vector3 mousepoint = Input.mousePosition;
        mousepoint.z = mzCoord;
        return Camera.main.ScreenToWorldPoint(mousepoint);
    }

    public Quaternion getJointRotation(CharacterJoint joint)
    {
        Debug.Log(joint.connectedBody.transform.rotation.eulerAngles);
        return(Quaternion.FromToRotation(joint.axis, joint.connectedBody.transform.rotation.eulerAngles));
    }

    public void OnMouseDown() {
        GameController.state2 = false;
        Debug.Log("down");
        // CharacterJoint joint = ComponentExtensions.GetCopyOf(joint, this.GetComponent<CharacterJoint>());
        // from = joint.axis;
        // Debug.Log(getJointRotation(joint).eulerAngles);
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
        foreach(Rigidbody rb in kids)
        {
            if(rb.gameObject != this.gameObject)
            {
                rb.isKinematic = false;
                // ;
            }
            // else 
            // {
            //     Destroy(rb.gameObject.GetComponent<CharacterJoint>());
            //     // rb.gameObject.Component
            //     // rb.freezeRotation = true;
            //     // rb.gameObject.GetComponent<CharacterJoint>().connectedBody = null;
            // }
            // // rb.isKinematic = false;
            // rb.freezeRotation = true;
        }
        foreach(CharacterJoint jt in joints)
        {
            if(jt.gameObject == this.gameObject)
                continue;
            // Quaternion angle = Quaternion.FromToRotation(jt.axis, jt.transform.rotation.eulerAngles);
            var njt = jt.lowTwistLimit;
            // Debug.Log(angle.eulerAngles);
            // njt.limit = rotated.eulerAngles.x;
            // jt.
            njt.limit = 0f;
            jt.lowTwistLimit = njt;
            // jt.enablePreprocessing = false;
            jt.highTwistLimit = njt;
            jt.swing1Limit = jt.swing2Limit = njt;
        }
        myRb.isKinematic = false;
        notOnMouse = false;
        mzCoord = Camera.main.WorldToScreenPoint(moveObj.transform.position).z;
        mOffset = moveObj.transform.position - GetMouseWorldPos();
        // mOffset = transform.position - GetMouseWorldPos();
    }


    private void OnMouseUp() {
        // rotated = Quaternion.FromToRotation(from.eulerAngles, transform.rotation.eulerAngles);
        // Debug.Log(rotated.eulerAngles);
        GameController.state2 = true;
        mx = my = 0f;
        qx.Clear();
        qy.Clear();
        // for(int i = 0; i < joints.Length; i++)
        // {
        //     joints[i].gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //     CharacterJoint jt = joints[i];
        //     if(jt.gameObject == this.gameObject)
        //         continue;
        //     gameObject.AddComponent<CharacterJoint>();
        // }
        foreach(Rigidbody rb in kids)
        {
            rb.isKinematic = true;
        }
        for(int i = 0; i < joints.Length; i++)
        {
            CharacterJoint jt = joints[i];

            jt.lowTwistLimit = joints2[i * 4];
            jt.highTwistLimit = joints2[i * 4 + 1];
            jt.swing1Limit = joints2[i * 4 + 2];
            jt.swing2Limit = joints2[i * 4 + 3];
        }
        myRb.isKinematic = true;
        notOnMouse = true;
        mode = 0;


    }

    private void OnMouseDrag() {
        // moveObj.transform.position = GetMouseWorldPos() + mOffset;
        Vector3 forceDirection = Vector3.zero;
        Rigidbody body = moveObj.GetComponent<Rigidbody>(); 
        float mass = body.mass;
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        qx.Enqueue(Mathf.Abs(x));
        qy.Enqueue(Mathf.Abs(y));
        mx += Mathf.Abs(x);
        my += Mathf.Abs(y);
        if(qx.Count > 10)
        {
            mx -= qx.Dequeue();
            my -= qy.Dequeue();
        }
        
        if(mode == 0 && (Mathf.Abs(mx) > 2f || Mathf.Abs(my) > 2f))
        {
            if(Mathf.Abs(mx) > 2f)
                mode = 1;
            else 
                mode = 2;
            qx.Clear();
            qy.Clear();
            mx = my = 0;
        }
        else if(mode == 1 && Mathf.Abs(my) > Mathf.Abs(mx) + 4f)
        {
            mode = 2;
            qx.Clear();
            qy.Clear();
            mx = my = 0;
            // mx = my = 0f;
        }
        else if(mode == 2 && Mathf.Abs(mx) > Mathf.Abs(my) + 4f)
        {
            mode = 1;
            qx.Clear();
            qy.Clear();
            mx = my = 0;
            // mx = my = 0f;
        }
        // Debug.Log(mx);
        // Debug.Log("x:" + x);
        // Debug.Log("y:" + y);
        if(mode == 2)
        {
            // forceDirection += Input.GetAxis("Mouse Y") * mass * 5f * moveCamera.forward;
            Vector3 force = new Vector3(0,0,Input.GetAxis("Mouse Y") * 50000f);
            force.y = force.x = 0;
            if(transform.name == "upperarm_r" || transform.name == "thigh_r" || transform.name == "calf_r" || transform.name == "lowerarm_r")
                force *= -1;
            forceDirection += force;
        }
        else 
        {
            // Debug.Log(moveCamera.forward);
            // Vector3 force = -1 * Input.GetAxis("Mouse X") * 50000f * (spin.forward - moveCamera.forward);
            Vector3 rotation = Quaternion.FromToRotation(spin.right,moveCamera.forward).eulerAngles;
            // if(rotation.y > 180)
            //     rotation.y -= 360;
            // Debug.Log(rotation.y);
            if(rotation.y > 90 && rotation.y < 270)
                rotation.y -= 90;
            else if(rotation.y < 90)
                rotation.y = -rotation.y - 90;
            else 
                rotation.y = -rotation.y + 270;
            // Debug.Log(rotation.y);
            // Debug.Log(spin.forward);
            Vector3 force = new Vector3(Input.GetAxis("Mouse X") * 50000f,0,0);
            if(transform.name == "thigh_l" || transform.name == "upperarm_l" || transform.name == "head1")
                force *= -1;
            forceDirection += force;
        }
        // forceDirection.x = -Input.GetAxis("Mouse X") * 500f;
            // Debug.Log(transform.name);
        // forceDirection.z = Input.GetAxis("Mouse Y") * 500f;
        // Debug.Log(forceDirection);
        // Debug.Log(forceDirection);
        // forceDirection = moveObj.transform.forward * 1000f;
        // moveObj.GetComponent<Rigidbody>().AddRelativeForce(forceDirection,ForceMode.Impulse);
        moveObj.GetComponent<Rigidbody>().AddRelativeTorque(forceDirection,ForceMode.VelocityChange);
    }

    // private void OnMouseEnter() {
    //     transform.localScale = Vector3.Lerp(transform.localScale, tarScale1, Time.deltaTime);
    // }



}
