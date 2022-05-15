using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectController : AssignmentController
{

  // Start is called before the first frame update
  private void OnPlayerCollision()
  {
    StartCoroutine(Flasher());
    _numPlayerTouches++;
    if (_numPlayerTouches >= _numPlayerTouchesBeforeDestroy)
    {
      _scoreController.IncrementNumProjects();
      _playerController.IncreaseHealthFromProject();
      Destroy(this.gameObject);
    }
  }
}
