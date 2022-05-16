using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
  [SerializeField] private GameObject _playingField;
  [SerializeField] private GameObject _breakdown;
  [SerializeField] private GameObject _newLove;
  [SerializeField] private GameObject _assignment;
  [SerializeField] private GameObject _project;
  // Buffer distance from edge of each wall to spawn an object within. 
  [SerializeField] private WallController _wallController;
  [SerializeField] private float _bufferDistance;
  [SerializeField] private float _baseTimeBetweenSpawns;
  [SerializeField] private float _upperLimitTime;

  private float _zPos;
  private float _timePassed = 0f;

  void GenerateRandomObject()
  {
    // Probabilities
    // Projects & Assignments: 50 percent
    // New Loves: 10%
    // Mental Breakdowns: 40%
    // var topEdge = _wallController.GetTopEdgePosition();
    // var rightEdge = _wallController.GetRightEdgePosition();
    var choice = Random.Range(0f, 1f);
    // var xPos = Random.Range(-rightEdge + _bufferDistance, rightEdge - _bufferDistance);
    // var yPos = Random.Range(-topEdge + _bufferDistance, topEdge - _bufferDistance);
    // var pos = new Vector3(xPos, yPos, _zPos);
    // Debug.Log("POS" + pos);
    // Debug.Log(pos);
    if (choice < 0.10)
    {
      Debug.Log("Creating New Love");
      InstantiateObjectInBounds(_newLove);
    }
    else if (choice > 0.10 && choice < 0.65)
    {
      Debug.Log("Creating Assignment or Project");

      var assignType = Random.Range(0, 1f);
      if (assignType < 0.65)
      {
        InstantiateObjectInBounds(_assignment);
      }
      else
      {
        InstantiateObjectInBounds(_project);
      }
    }
    else
    {
      Debug.Log("Creating Mental Breakdown");
      InstantiateObjectInBounds(_breakdown);
    }
  }

  void Awake()
  {
    _zPos = _playingField.transform.position.z;
  }
  // Start is called before the first frame update


  // Update is called once per frame
  void Update()
  {
    _timePassed += Time.deltaTime;
    if (_timePassed >= _baseTimeBetweenSpawns)
    {
      _timePassed = 0f;
      GenerateRandomObject();
    }
  }

  void InstantiateObjectInBounds(GameObject obj)
  {
    // Get inside and between buffer. 
    var topEdge = _wallController.GetTopEdgePosition();
    var rightEdge = _wallController.GetRightEdgePosition();
    var xPos = Random.Range(-rightEdge + _bufferDistance, rightEdge - _bufferDistance);
    var yPos = Random.Range(-topEdge + _bufferDistance, topEdge - _bufferDistance);
    var pos = new Vector3(xPos, yPos, _zPos);
    Debug.Log(pos);

    Instantiate(obj, pos, Quaternion.identity);
  }
}
