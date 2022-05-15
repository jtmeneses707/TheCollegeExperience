using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectControllerInterface
{
  void OnWallCollision();

  void Bounce();

  void OnPlayerCollision();
}
