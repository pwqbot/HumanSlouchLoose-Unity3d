using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AddJoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) {
        SpringJoint old = GetComponent<SpringJoint>();
        if(old != null)
        {
            Destroy(old);
        }
        if(GameController.gameStart)
            return;
        // if(!GameController.state2)
        //     return;
        if(other.gameObject.transform.root == transform.root)
            return;
        Debug.Log(other.gameObject.name);
        if(SceneManager.GetActiveScene().name == "SpinCrazy")
        {
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = other.rigidbody;
            joint.breakForce = transform.root.gameObject.GetComponent<SetCharacter>().toughness * 1000f; 
        }
        else 
        {
            HingeJoint joint = gameObject.AddComponent<HingeJoint>();
            joint.connectedBody = other.rigidbody;
            joint.breakForce = transform.root.gameObject.GetComponent<SetCharacter>().toughness * 10f; 
        }
        // joint.limits = 0;
        // joint.maxDistance = .1f;
        // joint.minDistance = .2f;
        // joint.spring = 100f;    
        // joint.damper = 100f;
        FindObjectOfType<AudioManager>().Play("Grab1");
        GameController.state2 = false;
    }
}
