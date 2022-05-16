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
  [SerializeField] private float BreakdownAmount;
  [SerializeField] private float NewLoveAmount;

  private float _xStartPos;
  private float _yStartPos;



  // Start is called before the first frame update
  void Start()
  {
    _xStartPos = this.RightWall.transform.position.x;
    _yStartPos = this.TopWall.transform.position.y;
  }

  // Update is called once per frame
  void Update()
  {
    var horizontalMovement = Time.deltaTime * HorizontalSpeed;
    var verticalMovement = Time.deltaTime * VerticalSpeed;
    MoveLeftWall(horizontalMovement);
    MoveRightWall(horizontalMovement);
    MoveTopWall(verticalMovement);
    MoveBottomWall(verticalMovement);
  }

  public void DoMentalBreakdown()
  {
    MoveLeftWall(BreakdownAmount);
    MoveRightWall(BreakdownAmount);
    MoveTopWall(BreakdownAmount);
    MoveBottomWall(BreakdownAmount);
  }

  public void DoNewLove()
  {
    if (CanMoveWall(NewLoveAmount))
    {
      MoveLeftWall(NewLoveAmount);
      MoveRightWall(NewLoveAmount);
      MoveTopWall(NewLoveAmount);
      MoveBottomWall(NewLoveAmount);
    }
    else
    {
      MoveWallsToOrigPos();
    }

  }


  /** HELPER FUNCTIONS **/

  // Checks to see if moving by the param amount will result in position 
  // than overexceeds original position. 
  bool CanMoveWall(float amount)
  {
    Debug.Log("CAN MOVE WALL FOR NEW LOVE");
    var horizPos = RightWall.transform.position.x;
    var vertPos = TopWall.transform.position.y;
    if (horizPos - amount < _xStartPos && vertPos - amount < _yStartPos)
    {
      return true;
    }
    return false;

  }

  void MoveWallsToOrigPos()
  {
    Debug.Log("Moving walls to orig spot.");
    var leftWallPos = LeftWall.transform.position;
    var TopWallPos = TopWall.transform.position;
    RightWall.transform.position = new Vector3(_xStartPos, leftWallPos.y, leftWallPos.z);
    LeftWall.transform.position = new Vector3(-_xStartPos, leftWallPos.y, leftWallPos.z);
    TopWall.transform.position = new Vector3(TopWallPos.x, _yStartPos, TopWallPos.z);
    BottomWall.transform.position = new Vector3(TopWallPos.x, -_yStartPos, TopWallPos.z);


  }
  void MoveLeftWall(float moveDistance)
  {
    var leftWallVector = LeftWall.transform.position;
    LeftWall.transform.position = new Vector3(leftWallVector.x + moveDistance, leftWallVector.y, leftWallVector.z);
  }

  void MoveRightWall(float moveDistance)
  {
    var rightWallVector = RightWall.transform.position;
    RightWall.transform.position = new Vector3(rightWallVector.x - moveDistance, rightWallVector.y, rightWallVector.z);
  }

  void MoveTopWall(float moveDistance)
  {
    var pos = TopWall.transform.position;
    TopWall.transform.position = new Vector3(pos.x, pos.y - moveDistance, pos.z);
  }

  void MoveBottomWall(float moveDistance)
  {
    var pos = BottomWall.transform.position;
    BottomWall.transform.position = new Vector3(pos.x, pos.y + moveDistance, pos.z);
  }

  // Returns the y position of the top wall's edge. Used to ensure no assets get spawned outside of playing field.
  public float GetTopEdgePosition()
  {
    var yScale = TopWall.transform.localScale.y;
    Debug.Log("Y SCALE" + yScale);
    var yPos = TopWall.transform.position.y;
    Debug.Log("Y POS" + yPos);

    var edge = yPos - yScale / 2f;
    Debug.Log("TOP EDGE" + edge);
    return yPos - yScale / 2;
  }

  public float GetBottomEdgePosition()
  {
    var yScale = BottomWall.transform.localScale.y;
    var yPos = BottomWall.transform.position.y;
    return yPos + yScale / 2;
  }

  public float GetLeftEdgePosition()
  {
    var xScale = LeftWall.transform.localScale.x;
    var xPos = LeftWall.transform.position.x;
    return xPos + xScale / 2;
  }

  public float GetRightEdgePosition()
  {
    var xScale = RightWall.transform.localScale.x;
    var xPos = RightWall.transform.position.x;
    return xPos - xScale / 2;
  }



}
