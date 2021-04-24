using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  Rigidbody2D rigid2D;
  Animator animator;
  float jumpForce = 780.0f;
  float walkForce = 30.0f;
  float maxWalkSpeed = 2.0f;

  void Start()
  {
    //跳跃
    this.rigid2D = GetComponent<Rigidbody2D>();
    this.animator = GetComponent<Animator>();
  }

  void Update()
  {
    //跳跃
    if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
    {
      //施加一个向上的力
      this.rigid2D.AddForce(transform.up * this.jumpForce);
    }

    //左右移动
    int key = 0;
    if (Input.GetKey(KeyCode.RightArrow))
    {
      key = 1;
    }
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      key = -1;
    }
    //角色的移动速度
    float speedx = Mathf.Abs(this.rigid2D.velocity.x);
    //限制速度
    if (speedx < this.maxWalkSpeed)
    {
      this.rigid2D.AddForce(transform.right * key * this.walkForce);
    }
    //根据运动方向翻转
    if (key != 0)
    {
      // 通过缩放率来翻转图片
      transform.localScale = new Vector3(key, 1, 1);
    }

    //根据角色的移动速度改变动画的播放速度
    this.animator.speed = speedx / 2.0f;

    //掉到画面以外就恢复到最初状态
    if (transform.position.y < -10)
    {
      SceneManager.LoadScene("GameScene");
    }
  }

  //到达目的地
  void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("到达目的地");
    SceneManager.LoadScene("ClearScene");
  }
}
