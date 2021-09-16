using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class BuildManager : MonoBehaviour
{
    [SerializeField]
    Transform  moveCamera;
    public ManData yellowMan;
    public ManData blackMan;
    public ManData whiteMan;
    [SerializeField]
    private ManData selectedMan;
    public Transform sphere;

    [SerializeField, Range(1,100)]
    float createDepth;
    public bool onSelecting = false;
    
    public Toggle yellowToggle;
    public Toggle blackToggle;
    public Toggle whiteToggle;

    public Toggle open;
    // Start is called before the first frame update

    private void Update() {
        if(Input.GetKey("g"))
        {
            onSelecting = false;
            open.isOn = false;
        }
        if(Input.GetMouseButtonDown(0) && open != null && open.isOn && !GameController.gameStart)
        {
            if(EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("111");
            }
            else 
            {
                Vector3 mousePoint = Input.mousePosition;
                mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
                if(SceneManager.GetActiveScene().name == "Mathematician")
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    bool isCollider = Physics.Raycast(ray, out hit);
                    mousePoint = hit.point;
                }
                else 
                {
                    mousePoint.z = moveCamera.position.z;
                    mousePoint = mousePoint + moveCamera.forward * createDepth;
                    mousePoint.y -= 1f;
                }
                GameObject obj = Instantiate(selectedMan.manPrefab, mousePoint, moveCamera.rotation);
                obj.transform.Rotate(new Vector3(0,180,0));
                if(SceneManager.GetActiveScene().name == "Mathematician")
                {
                    Vector3 position = obj.transform.position;
                    position.z = sphere.position.z + 2f;
                    obj.transform.position = position;
                }
                else 
                {
                    obj.transform.Rotate(new Vector3(30,0,0));
                }

                onSelecting = false;
                open.isOn = false;
            }
        }
    }

    public void DisableOnSelecting(bool isOn)
    {
        onSelecting = false;
    }

    public void SelectYellow(bool isOn)
    {
        if(yellowToggle.isOn)
        {
            open = yellowToggle;
            selectedMan = yellowMan;
            onSelecting = true;
        }
    }

    public void SelectBlack(bool isOn)
    {
        if(blackToggle.isOn)
        {
            open = blackToggle;
            selectedMan = blackMan;
            onSelecting = true;
        }
    }

    public void SelectWhite(bool isOn)
    {
        if(whiteToggle.isOn)
        {
            open = whiteToggle;
            selectedMan = whiteMan;
            onSelecting = true;
        }
    }
}
