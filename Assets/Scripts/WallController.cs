using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
  [SerializeField] private GameObject LeftWall;
  [SerializeField] private GameObject RightWall;
  [SerializeField] private GameObject TopWall;
  [SerializeField] private GameObject BottomWall;
  [SerializeField] private float VerticalSpeed;
  [SerializeField] private float HorizontalSpeed;



  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    MoveLeftWall();
    MoveRightWall();
    MoveTopWall();
    MoveBottomWall();
  }


  /** HELPER FUNCTIONS **/
  void MoveLeftWall()
  {
    var leftWallVector = LeftWall.transform.position;
    LeftWall.transform.position = new Vector3(leftWallVector.x + Time.deltaTime * HorizontalSpeed, leftWallVector.y, leftWallVector.z);
  }

  void MoveRightWall()
  {
    var rightWallVector = RightWall.transform.position;
    RightWall.transform.position = new Vector3(rightWallVector.x - Time.deltaTime * HorizontalSpeed, rightWallVector.y, rightWallVector.z);
  }

  void MoveTopWall()
  {
    var pos = TopWall.transform.position;
    TopWall.transform.position = new Vector3(pos.x, pos.y - Time.deltaTime * VerticalSpeed, pos.z);
  }

  void MoveBottomWall()
  {
    var pos = BottomWall.transform.position;
    BottomWall.transform.position = new Vector3(pos.x, pos.y + Time.deltaTime * VerticalSpeed, pos.z);
  }

  // Returns the y position of the top wall's edge. Used to ensure no assets get spawned outside of playing field.
  float GetTopEdgePosition()
  {
    var yScale = TopWall.transform.localScale.y;
    var yPos = TopWall.transform.position.y;
    return yPos - yScale / 2;
  }

  float GetBottomEdgePosition()
  {
    var yScale = BottomWall.transform.localScale.y;
    var yPos = BottomWall.transform.position.y;
    return yPos + yScale / 2;
  }

  float GetLeftEdgePosition()
  {
    var xScale = LeftWall.transform.localScale.x;
    var xPos = LeftWall.transform.position.x;
    return xPos + xScale / 2;
  }

  float GetRightEdgePosition()
  {
    var xScale = RightWall.transform.localScale.x;
    var xPos = RightWall.transform.position.x;
    return xPos - xScale / 2;
  }



}
