using UnityEngine;

public class CameraController : MonoBehaviour
{
  GameObject player;

  void Start()
  {
    this.player = GameObject.Find("cat");
  }

  void Update()
  {
    transform.position = new Vector3(transform.position.x, this.player.transform.position.y, transform.position.z);
  }
}
