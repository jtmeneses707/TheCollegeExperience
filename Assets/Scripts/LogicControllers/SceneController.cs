using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
  // Start is called before the first frame update
  private string _sceneName;
  void Awake()
  {
    _sceneName = SceneManager.GetActiveScene().name;
  }
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      switch (_sceneName)
      {
        case "Title":
          Application.Quit();
          return;
        case "Gameplay":
        case "Ending":
          SceneManager.LoadScene("Title");
          return;
      }
    }

    if (Input.GetKeyDown(KeyCode.Space))
    {
      switch (_sceneName)
      {
        case "Title":
          SceneManager.LoadScene("Gameplay");
          return;
      }
    }
  }
}
