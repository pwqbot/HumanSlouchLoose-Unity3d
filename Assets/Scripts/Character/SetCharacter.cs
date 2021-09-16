using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacter : MonoBehaviour
{

    [SerializeField, Range(1,1000)]
    public float toughness = 1.0f;
    public PhysicMaterial mat;
    private Transform[] kids;
    // Start is called before the first frame update
    void Start()
    {
        kids = GetComponentsInChildren<Transform>();
        foreach(Transform child in kids)
        {
            // if(child.tag != "mesh_reserve")
            //     child.enabled = false;
            // child.breakForce = toughness * 1000f;
            // child.breakTorque = toughness * 1000f;
            GameObject gb = child.gameObject;
            var cj = gb.GetComponent<CharacterJoint>();
            if(cj != null)
            {
                // cj.breakForce = toughness * 100000f;
                // cj.breakTorque = toughness * 100000f;
                SoftJointLimitSpring sf = cj.twistLimitSpring;
                sf.spring = 300f;
                sf.damper = 100f;
                // cj.twistLimitSpring = SoftJointLimitSpring(10f,100f);  
            }
            var rb = gb.GetComponent<Rigidbody>();
            if(rb != null)
            {
                // rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
                rb.useGravity = false;
                rb.isKinematic = true;
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            }
            var cli = gb.GetComponent<Collider>();
            if(cli != null)
                cli.material = mat;
            // if(rb != null && rb.name != "mixamorig6:Head")
            // {
            //     // rb.isKinematic = true;
            // }
            print("???" + child);
        } 

        // foreach(Transform child in transform)
        //     print("???" + child);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
