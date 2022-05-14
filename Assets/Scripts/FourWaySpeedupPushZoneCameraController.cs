using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obscura
{

  public class FourWaySpeedupPushZoneCameraController : AbstractCameraController
  {
    [SerializeField] private float PushRatio;
    [SerializeField] private Vector3 TopLeft, BottomRight;

    private Camera ManagedCamera;
    private LineRenderer CameraLineRenderer;

    private void Awake()
    {
      this.ManagedCamera = this.gameObject.GetComponent<Camera>();
      this.CameraLineRenderer = this.gameObject.GetComponent<LineRenderer>();
    }

    private void Start()
    {
      // var targetPosition = this.Target.transform.position;
      // var cameraPosition = this.ManagedCamera.transform.position;
      // this.ManagedCamera.transform.position = new Vector3(targetPosition.x, targetPosition.y, cameraPosition.z);
      // Debug.Log("Start Pos" + this.StartPos);
      var targetPos = this.Target.transform.position;
      var cameraPos = this.ManagedCamera.transform.position;

      // Calculate the position that resutls in the camera spawning directly on the 
      // player's position.
      var cameraSpawnPos = new Vector3(targetPos.x, targetPos.y, cameraPos.z);

      // Place the camera on the target.
      this.ManagedCamera.transform.position = cameraSpawnPos;
    }


    // While player is not past push zone border, move at 
    // player speed * push ratio. 
    // If the player is touching the border, move in 2 speeds.
    // On direction touching border, moving at player speed. 
    // On direction not touching border, move at PushRatio speed.
    void LateUpdate()
    {   // Get the positioning of the camera and target's current locations.
      var targetPosition = this.Target.transform.position;

      var cameraPosition = this.ManagedCamera.transform.position;

      var playerController = this.Target.GetComponent<PlayerController>();

      // Get player's speed
      var speed = playerController.GetCurrentSpeed();

      // Get the player's movement direction on the x axis.
      var xMovement = playerController.GetMovementDirection().x;

      // Get the player's movement direction on the y axis.
      var yMovement = playerController.GetMovementDirection().y;


      // Main camera logic: 
      // If player is touching parts of the border, move at player speed. 
      // If the player remains within the camera border, move at PushRatio * player speed.

      // If player is touching either y borders, move the camera at player's speed.
      if ((targetPosition.y >= cameraPosition.y + TopLeft.y) || (targetPosition.y <= cameraPosition.y + BottomRight.y))
      {
        var cameraMovement = new Vector3(0f, yMovement, 0f);
        this.ManagedCamera.transform.Translate(Time.deltaTime * cameraMovement * speed);
      }

      // Else if camera is within the y border, move in the y direction at push ratio * player speed.
      else if ((targetPosition.y < cameraPosition.y + TopLeft.y) && (targetPosition.y > cameraPosition.y + BottomRight.y))
      {
        var cameraMovement = new Vector3(0f, yMovement, 0f);
        this.ManagedCamera.transform.Translate(Time.deltaTime * cameraMovement * speed * this.PushRatio);
      }

      // If player is touching either x borders, move camera at player's speed.
      if ((targetPosition.x <= cameraPosition.x + TopLeft.x) || (targetPosition.x >= cameraPosition.x + BottomRight.x))
      {
        var cameraMovement = new Vector3(xMovement, 0f, 0f);
        this.ManagedCamera.transform.Translate(Time.deltaTime * cameraMovement * speed);
      }

      // If player remains within the x borders, move in x direction at push ratio * player speed.
      if ((targetPosition.x > cameraPosition.x + TopLeft.x) && (targetPosition.x < cameraPosition.x + BottomRight.x))
      {
        // Debug.Log("YES");
        var cameraMovement = new Vector3(xMovement, 0f, 0f);
        this.ManagedCamera.transform.Translate(Time.deltaTime * cameraMovement * speed * this.PushRatio);
      }


      if (this.DrawLogic)
      {
        this.CameraLineRenderer.enabled = true;
        this.DrawCameraLogic();
      }
      else
      {
        this.CameraLineRenderer.enabled = false;
      }
    }

    public override void DrawCameraLogic()
    {
      this.CameraLineRenderer.positionCount = 5;
      this.CameraLineRenderer.useWorldSpace = false;
      this.CameraLineRenderer.SetPosition(0, TopLeft);
      this.CameraLineRenderer.SetPosition(1, new Vector3(BottomRight.x, TopLeft.y, TopLeft.z));
      this.CameraLineRenderer.SetPosition(2, BottomRight);
      this.CameraLineRenderer.SetPosition(3, new Vector3(TopLeft.x, BottomRight.y, BottomRight.z));
      this.CameraLineRenderer.SetPosition(4, TopLeft);
    }
  }

}