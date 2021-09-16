using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject moveCamera;
    public GameObject mainCamera;
    public Transform spawn;
    public GameObject ball;
    public static Transform selected;
    [SerializeField, Range(1,100)]
    public float initSpeed;
    public GameObject button;
    public GameObject startButton;
    public GameObject restartButton;
    public GameObject sucesstext;
    bool flag = false;
    public static bool rotate = false;
    public static bool onCatch = false;
    public static bool gameStart = false;
    public static bool state2 = false;

    private float totalTime = 0f;
    public GameObject spin;
    // Start is called before the first frame update
    void Awake()
    {
        moveCamera.SetActive(!flag);
        mainCamera.SetActive(flag);
        // gameStart();
        onCatch = false;
    }

    public void GameStart()
    {
        if(spin != null)
        {
            spin.GetComponent<HingeJoint>().useMotor = true;
            spin.GetComponent<Rigidbody>().isKinematic = false;
        }
        Vector3 spawnPosition = spawn.position;
        spawnPosition.z += 1.5f;
        GameObject rball = Instantiate(ball, spawnPosition, spawn.rotation);
        if(SceneManager.GetActiveScene().name == "SpinCrazy")
        {
            rball.GetComponent<Rigidbody>().mass = 1f;
            Debug.Log("123123123");
        }
        // rball.GetComponent<Rigidbody>().velocity = rball.transform.forward * initSpeed;
        gameStart = true;
        GameObject[] prefabs =  GameObject.FindGameObjectsWithTag("character");
        foreach(GameObject gb in prefabs)
        {
            Rigidbody[] bodys =  gb.GetComponentsInChildren<Rigidbody>();
            foreach(Rigidbody rb in bodys)
            {
                if(rb.transform == rb.transform.root)
                    continue;
                if(rb.name == "head1" && SceneManager.GetActiveScene().name != "SpinCrazy")
                {
                    ConstantForce force =  rb.gameObject.AddComponent<ConstantForce>();
                    if(force != null)
                        force.force = new Vector3(0,1600f,0f);
                }
                rb.useGravity = true;
                rb.isKinematic = false;
            }
        }
        FindObjectOfType<AudioManager>().Play("ButtonUp");
        restartButton.SetActive(true);
        startButton.SetActive(false);
    }

    public void GameRestart()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("restart");
        restartButton.SetActive(false);
        startButton.SetActive(true);
        gameStart = false;
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach(GameObject gb in balls)
            Destroy(gb);
        GameObject[] spins = GameObject.FindGameObjectsWithTag("Spin");
        foreach(GameObject gb in spins)
        {
            gb.GetComponent<HingeJoint>().useMotor = false;
            gb.GetComponent<Rigidbody>().isKinematic = true;
        }

        GameObject[] prefabs =  GameObject.FindGameObjectsWithTag("character");
        foreach(GameObject gb in prefabs)
        {
            Rigidbody[] bodys =  gb.GetComponentsInChildren<Rigidbody>();
            foreach(Rigidbody rb in bodys)
            {
                if(rb.transform == rb.transform.root)
                    continue;
                rb.useGravity = false;
                rb.isKinematic = true;
            }
            // HingeJoint jt = GetComponentsInChildren<HingeJoint>();
            // FixedJoint jt = GetComponentsInChildren<FixedJoint>();

        }
    }
    public void sucessGame()
    {
        Debug.Log("???");
        sucesstext.SetActive(true);
    }

    public void QuitGame()
    {
        GameRestart();
        SceneManager.LoadScene("StartScene");
    }
    // Update is called once per frame
    void Update()
    {
        // swtich camera
        if(gameStart && SceneManager.GetActiveScene().name == "SpinCrazy")
        {
            totalTime += Time.deltaTime;
            if(totalTime > 4f)
            {
                totalTime -= 4f;
                Vector3 spawnPosition = spawn.position;
                spawnPosition.z += 1.5f;
                GameObject rball = Instantiate(ball, spawnPosition, spawn.rotation);
                rball.GetComponent<Rigidbody>().mass = 1f;
            }
        }
        if(gameStart && SceneManager.GetActiveScene().name == "Mathematician")
        {
            totalTime += Time.deltaTime;
            if(totalTime > 2f)
            {
                totalTime -= 2f;
                Vector3 spawnPosition = spawn.position;
                // spawnPosition.z += 1.5f;
                GameObject rball = Instantiate(ball, spawnPosition, spawn.rotation);
                rball.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5f,5f),-20f,0);
                // rball.transform.localScale = new Vector3(5f,5f,5f);
                // rball.GetComponent<Rigidbody>().mass /= 10f;
            }
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            flag = !flag;
            moveCamera.SetActive(!flag);
            mainCamera.SetActive(flag);
        }
        if(Input.GetKeyDown("g"))
        {
            // rotate = !rotate;
            button.GetComponent<SwitchButton>().Switch();
        }

        // mouse selection
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layermasek = (1 << 3);
            bool isCollider = Physics.Raycast(ray, out hit, maxDistance: Mathf.Infinity, layermasek);
            Debug.Log(isCollider);
            if(isCollider && !EventSystem.current.IsPointerOverGameObject())
            {
                // Debug.Log(hit.collider.gameObject.name);
                Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject.layer == 3)
                {
                    onCatch = true;
                    selected = hit.collider.gameObject.transform.root;
                }
                else
                    onCatch = false;
            }       
        }

        if(Input.GetMouseButton(1))
        {
            moveCamera.GetComponent<MoveCameraController>().Move();
            Debug.Log(1);
        }
        else 
        {
            if(onCatch)
            {   
                selected.gameObject.GetComponentInChildren<MoveCharacter>().Move();
            }
            else 
            {
                moveCamera.GetComponent<MoveCameraController>().Move();
            }
        }
    }

    public void SetRotate()
    {
        rotate = !rotate;
        button.GetComponent<SwitchButton>().Switch();
    }
}
