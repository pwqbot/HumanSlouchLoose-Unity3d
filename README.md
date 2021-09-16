

# 人类一团散沙 Human Slouch Loose 
2020 Spring 的 Unity 课程的期末项目作业. 
- 赶工痕迹明显, 游戏可玩性为0.
- 或许会在某段不那么忙的时间重构一下游戏.

# 1.项目简介

游戏灵感源于某日失眠, 莫名想起以前刮台风发洪水的时候,人会跳到洪水里, 手牵着手用肉身挡住水流……人类真是种可爱的生物. 

于是《人类一团散沙》诞生了---玩家可以在其中搭建人墙, 用角色的身体挡住,击打一些游戏道具, 如小球, 车辆等, 在此基础上设计有趣的关卡.

遇到的第一个难点是角色的身体控制, 我希望在角色控制上给予玩家尽可能多的自由度, 模拟出真实的骨骼和关节效果, 可以让角色摆出任何想要的姿势.

第二个难点是交互方式的设计, 因为角色控制的自由度极高, 所以必须设计出符合直觉的交互方式才能实现玩家对角色的身体控制.

第三个难点是关卡的设计, 实现了高自由度的角色的控制之后, 要如何设计出有趣巧妙的关卡与角色进行交互, 从而能让玩家在游戏里自由发挥他们的想象力和创造力.

经过这段时间的努力, 一二两点已经实现的比较成功了, 只是游戏关卡目前还只设计了三关, 除了第一关是新手关卡之外, 后面两关都具有一定的创意和可玩性, 也实现了我最开始所构想的效果. 后续还需增加关卡的数量和复杂性, 让高自由度的身体控制发挥真正有趣的效果. 

# 2.游戏创意

   玩家可以以极高的自由度控制角色的身体, 角色不仅可以移动, 旋转, 而且其手臂, 腿脚, 头部等都可以拖拉到任何玩家想要的姿势上. 

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image002.jpg" alt="img" style="zoom:67%;" />

在此高自由度身体控制的基础上, 玩家可以将角色以任何姿势吸附在地形上, 使角色扩展延展为地形道具的一部分. 再配合上精心设计的关卡道具, 既存在一定的难度, 需要玩家发挥自己的创意, 又十分有趣好玩. 

 ![image](http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image004.jpg)



# 3. 概要设计

游戏的设计主要分为三块.

1. 操作设计

   玩家如何控制角色.

2. 关卡设计

   主要是关卡模型的搭建和特殊道具.

3. 美术/UI/音效设计

   为ui和三个关卡都制作了简单好看的美术设计. 同时制作了基本的音效给予玩家反馈提示 

其中角色控制花了很多的时间, 一个是功能的实现, 另一个是交互的逻辑, 经历一个很长的尝试优化的过程.

关卡的设计主要来自莫名其妙的想法. 

美术和UI的设计是希望能在简洁美观的基础上做一些小创新.

> 使用的素材有 小人的3d模型, 天空盒以及音效. 

# 4. 详细设计

## 1. 操作设计

### 生成小人

点击右侧ui后再点击屏幕即可在对应位置产生一个小人.

### 摄像机控制

- 移动

  WASD 前后左右 QE 上下

- 旋转

  右键控制角度

当左键选中小人的时候, WASD控制的是小人的位置. 此时按住右键即在选中小人的同时移动摄像机.

### 小人控制

点击小人的躯干可以控制小人.

小人有两种控制模式, 按 G 可以互相切换

- 移动模式

  WASD前后左右, QE上下. 

  鼠标可以拖拽小人位置.

- 旋转模式

  WASDQE可以控制小人绕三个轴的旋转.

  鼠标可以控制旋转角度.

除了对躯干的控制, 玩家还可以使用鼠标控制小人的手和脚的位置, 当手或者脚贴近地形或者其他小人的身体时会抓在上面.  

- 躯干控制

  可以操控头部, 手臂和腿部. 用鼠标点击对应的部位并拖拽即可控制其关节角度. 

## 2. 关卡设计

### 关卡1 : KinderGarden

第一关是新手关卡, 主要在于熟悉游戏的操作

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image039.jpg" alt="img"  />

小球从台阶上滚下, 玩家需要在拐角出搭建人墙挡住小球, 让小球掉到右边的烟囱中.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image041.jpg" alt="img" style="zoom:80%;" />

 除了在拐角处搭建之外, 还需要在烟囱和左边的地形之间连出人桥让球通过.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627181253924.png" alt="image-20210627181253924" style="zoom: 25%;" />



### 关卡2 : Spin Crazy

第二关叫做 “Spin Crazy”. 玩家可以把小人挂在旋转的杆子上.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image043.jpg" alt="img"  />

小人旋转起来之后会击打小球, 目标是把球打过两个圆环.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image045.jpg" alt="img" style="zoom: 80%;" />

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image047.jpg" alt="img" style="zoom: 80%;" />



### 关卡3 : Mathematician

第三关名为 “Mathematician”, 灵感来自于经典的正态分布弹球实验.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image049.jpg" alt="img" style="zoom: 80%;" />

众所周知小球经过这样的装置之后, 在下方的落点呈现出正态分布.

这关需要玩家用小人堵上某些杆子之间的空隙, 使得小球在下方的落点为两边多中间少的分布.

 但胜利判定还未实装, 玩家可以先玩试试效果. 



## 3. UI/美术/音效

###  UI

   #### 开始界面

​     低对比度的纯色背景+渐变效果文字. 

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627183954514.png" alt="image-20210627183954514" style="zoom: 25%;" />

  关卡选择界面

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627184006553.png" alt="image-20210627184006553" style="zoom: 25%;" />

​     #### 游戏UI

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image010.jpg" alt="img"  />

游戏内的 UI 分为两个部分

#### 操作UI

第一部分是角色创建和控制的 UI, 分别位于屏幕的最左侧和最右侧.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627184112805.png" alt="image-20210627184112805" style="zoom: 67%;" />

当玩家点击White/Yellow/Black 三个按钮中的一个时, 下方会出现一个小勾, 提示玩家选中了该类型的角色, 接下来点击屏幕中的某个位置即可在对应的位置创建角色

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627184133250.png" alt="image-20210627184133250" style="zoom: 67%;" />

左侧的 MOVE/ROTATE 表示当前角色的控制模式. 点击按钮或者键盘上按下G键互相切换.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627184213701.png" alt="image-20210627184213701" style="zoom: 55%;" />

切换为ROTATE

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627184230307.png" alt="image-20210627184230307" style="zoom:55%;" />

#### UI

第二部分是游戏开始和退出的UI.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627184420818.png" alt="image-20210627184420818" style="zoom:67%;" />

点击右下角的Start按钮, 游戏开始, 场景内生成小球, 并且角色状态发生改变(如受到重力控制等), Start 按钮变为 Restart 按钮.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627184511093.png" alt="image-20210627184511093" style="zoom:67%;" />

点击Restart 按钮, 游戏回到建造状态, 生成的小球小时, 但是之前已经建造好的角色仍会保留, 让玩家可以继续在上一次的建造基础上继续建造.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627184524907.png" alt="image-20210627184524907" style="zoom:67%;" />

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627184534761.png" alt="image-20210627184534761" style="zoom:67%;" />

点击Restart后小球消失,玩家可以继续建造

右上角的Quit按钮点击之后可以回到开始界面.

### 美术

#### 第一关 : KinderGarden

第一关使用了阴天的天空盒加上垂直雾效果. 

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627183428007.png" alt="image-20210627183428007" style="zoom:25%;" />



#### 第二关 : Spin Crazy

使用了银河的天空盒, 场景犹如漂浮在宇宙之中,

<img src="../../../../../../AppData/Roaming/Typora/typora-user-images/image-20210627183536095.png" alt="image-20210627183536095" style="zoom: 25%;" />

给两个圆环加上了光环效果.

<img src="../../../../../../AppData/Roaming/Typora/typora-user-images/image-20210627183603433.png" alt="image-20210627183603433" style="zoom:25%;" />



#### 第三关 : Mathematician

第三关使用了半透明+雾+粉色场景, 少女心十足.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627183706661.png" alt="image-20210627183706661" style="zoom:25%;" />



> 除了天空盒和垂直雾的shader, 所有场景的创意和搭建和美术都是自己实现的.

 

### 音效

音效设计虽然简单但还是完成了基本的功能.

1. 玩家点击按钮会有音效提示

2. 小球碰撞音效

3. 当手或者脚靠近其他物体时会有音效提示吸附成功.

4. 背景音乐

   分别为三个关卡按照其美术效果选择了不同的背景音乐

 

# 5.编程实现 

### 1. 移动旋转控制

实现了键盘控制和鼠标拖拽

``` c#
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
```



### 2.   肢体控制

把鼠标输入转换为力矩. 

为了让操作更简单. 拖拽肢体的时候只检测水平或者垂直一个方向的输入.

用了一个先进先出的队列实现, 检测最近五次鼠标在水平和垂直方向移动距离的累计值来选择检测x方向还是y方向的输入.

实现效果还是不错的, 切换起来很平滑.

``` c#
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
```



### 3.   角色创建

创建时让角色正对着当前摄像机.

第三关只在平面内创建.

 ``` c#
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

 ```



### 4.地形吸附

碰撞检测, 在碰撞点添加关节.

 ``` c#
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

 ```



### 5.断肢效果(未实装)

当关节断裂的时候设置Scale为0. 然后换上新的模型.

``` c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    [SerializeField] Limb[] childLimbs;
    [SerializeField] GameObject limbPrefab;

    // Start is called before the first frame update
    public void GetHit()
    {
        if(childLimbs.Length > 0)
        {
            foreach(Limb limb in childLimbs)
            {
                if(limb != null)
                    limb.GetHit();
            }
        }
        transform.localScale = Vector3.zero;

        if(limbPrefab != null)
        {
            GameObject limb = Instantiate(limbPrefab,transform.position, transform.rotation);
            Component copyComponent = gameObject.GetComponent<Rigidbody>();
            UnityEditorInternal.ComponentUtility.CopyComponent(copyComponent);
            UnityEditorInternal.ComponentUtility.PasteComponentAsNew(limb);

            copyComponent = gameObject.GetComponent<Collider>();
            UnityEditorInternal.ComponentUtility.CopyComponent(copyComponent);
            UnityEditorInternal.ComponentUtility.PasteComponentAsNew(limb);
        }


        Destroy(this);
        this.GetComponent<Rigidbody>().isKinematic = true;
    }

    void OnJointBreak(float breakForce)
    {
        Debug.Log("A joint has just been broken!, force: " + breakForce);
        GetHit();
    }
}

```



### 6. 总控代码

控制游戏开始结束, 检测鼠标选择等.

``` c#
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
```





# 6. 运行环境配置及游戏测试

- 测试平台

  显卡 GTX 1060 (6GB)

  CPU intel 10600kf

  内存 32GB

  分辨率 3840 * 2160

- 游戏测试

  测试下来已有的三个关卡都能流畅运行, 偶有物理效果方面的bug, 玩家点击游戏内的 Restart 按钮之后即可解决.

  前两个关卡均可通过. 第三关的话, 首先还没制作胜利结果判定, 其次做了我也玩不过…



# 7. 课程小结

设计这款游戏的初衷是希望赋予玩家尽可能高的自由度,为他们提供一个能自由探索, 思考, 实践自己的想法的平台. 最后实现的效果也基本如一开始所设想, 可惜的是因为时间不够充裕, 目前还只有三个关卡, 并且解法的自由度也不是很高. 后续希望能够设计出更加复杂, 巧妙的关卡展现出这个游戏真正的魅力.

只是, 虽然实现了高自由度的控制, 但受限于只能用键盘鼠标来操作身体, 游戏的操作难度相当之大, 导致操作体验并不是很好. 制作完这个游戏之后, 我也理解了为什么大多数游戏的操作都比较简单, 毕竟玩家的输入方式的限制在这, 就算实现了更复杂的操作方式玩家也操作不来.

 虽然制作这个游戏的过程确实十分有趣. 但我也同时感受到了技术上的限制. 所以现在更想做的是探索游戏底层技术的创新, 实现更真实的游戏引擎, 更丰富的交互方式, 用技术的进步去真正带动玩法上的创新.

 感谢游戏项目实践这门课让我完整地体验了一个游戏的制作过程. 感谢晨辉老师用心准备的课程内容和耐心的实践指导, 一个学期下来收获了很多, 希望这门课能一直开下去, 让更多的同学感受到游戏制作的魅力.