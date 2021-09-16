

# 人类一团散沙 Human Slouch Loose 
2021Spring 的 Unity 课程的期末项目作业. 
- 赶工痕迹明显, 游戏可玩性为0. :sweat_smile:
- 或许会在某段不那么忙的时间重构一下游戏. :sweat_smile:
- 想体验一下的下载 .rar 文件就好了 :sweat_smile:
- 不过只有windows版的.. :sweat_smile:
- 其他平台可以把这个project down下来玩, 前提是你有unity :sweat_smile:
## Hi 

游戏灵感源于某日失眠, 莫名想起以前刮台风发洪水的时候,人会跳到洪水里, 手牵着手用肉身挡住水流……人类真是种可爱的生物. 

于是《人类一团散沙》诞生了---玩家可以在其中搭建人墙, 用角色的身体挡住,击打一些游戏道具, 如小球, 车辆等, 在此基础上设计有趣的关卡.

遇到的第一个难点是角色的身体控制, 因为我想模拟出真实的骨骼和关节效果, 让角色摆出任意姿势, 研究了很久, 最后使用 Unity 里的Character Joint 和 力矩来实现的.

第二个难点是交互方式的设计, 因为角色控制的自由度比较高, 所以得设计好符合直觉的交互方式, 不然很难玩....

最后是是关卡的设计, 考验想象力的时候到了!

## 玩法
  大致玩法如下.
  - 高自由度控制角色的身体, 角色不仅可以移动, 旋转, 还可以拖拉手臂和腿脚关节. 
    
    <img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image002.jpg" alt="img" style="zoom:67%;" />

  - 把角色吸附在地形上, 使角色扩展延展为地形道具的一部分, 然后和落下的小球碰撞, 使小球滚到该去的地方....
    
    ![image](http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image004.jpg)

## 游戏设计

### 关卡设计

#### KinderGarden

第一关是新手关卡, 主要在于熟悉游戏的操作

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image039.jpg" alt="img"  />

小球从台阶上滚下, 玩家需要在拐角出搭建人墙挡住小球, 让小球掉到右边的烟囱中.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image041.jpg" alt="img" style="zoom:80%;" />

 除了在拐角处搭建之外, 还需要在烟囱和左边的地形之间连出人桥让球通过.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627181253924.png" alt="image-20210627181253924" style="zoom: 25%;" />

#### Spin Crazy

第二关叫做 “Spin Crazy”. 玩家可以把小人挂在旋转的杆子上.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image043.jpg" alt="img"  />

小人旋转起来之后会击打小球, 目标是把球打过两个圆环.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image045.jpg" alt="img" style="zoom: 80%;" />

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image047.jpg" alt="img" style="zoom: 80%;" />

#### Mathematician

第三关名为 “Mathematician”, 灵感来自于经典的正态分布弹球实验.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/clip_image049.jpg" alt="img" style="zoom: 80%;" />

众所周知小球经过这样的装置之后, 在下方的落点呈现出正态分布.

这关需要玩家用小人堵上某些杆子之间的空隙, 使得小球在下方的落点为两边多中间少的分布.

但胜利判定还未实装, 玩家可以先玩试试效果. 

### 操作设计
#### 控制视角

- 移动

  WASD 前后左右 QE 上下

- 旋转

  右键控制角度

当左键选中小人的时候, WASD控制的是小人的位置. 此时按住右键即在选中小人的同时移动摄像机.

#### 生成小人

点击右侧ui后再点击屏幕即可在对应位置产生一个小人.

#### 控制小人

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

## 美术
###  UI

  - 开始界面
    
    <img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627183954514.png" alt="image-20210627183954514" style="zoom: 25%;" />

  - 关卡选择界面
    
    <img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627184006553.png" alt="image-20210627184006553" style="zoom: 25%;" />

### 关卡美术
#### KinderGarden

使用了阴天的天空盒加上垂直雾效果. 

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627183428007.png" alt="image-20210627183428007" style="zoom:25%;" />

#### Spin Crazy

使用了银河的天空盒, 场景犹如漂浮在宇宙之中,

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627183536095.png" alt="image-20210627183536095" style="zoom: 25%;" />

给两个圆环加上了光环效果.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627183603433.png" alt="image-20210627183603433" style="zoom:25%;" />

#### Mathematician

使用了半透明+雾+粉色场景.

<img src="http://ding-typora.oss-cn-beijing.aliyuncs.com/img/image-20210627183706661.png" alt="image-20210627183706661" style="zoom:25%;" />

## 音效

实现了基本的音效.

1. 玩家点击按钮会有音效提示

2. 小球碰撞音效

3. 当手或者脚靠近其他物体时会有音效提示吸附成功.

4. 背景音乐

   分别为三个关卡按照其美术效果选择了不同的背景音乐

## 运行测试

- 测试平台

  显卡:   GTX 1060 (6GB)

  CPU:   intel 10600kf

  内存:   32GB

  分辨率:  3840 * 2160

- 游戏测试

  测试下来已有的三个关卡都能流畅运行, 偶有物理效果方面的bug, 玩家点击游戏内的 Restart 按钮之后即可解决.

  前两个关卡均可通过. 第三关的话, 首先还没制作胜利结果判定, 其次做了我也玩不过…

## 项目总结

  做出来了想要的样子.
  
  可是太难玩了. 
  
  GG. :smile::smile: 