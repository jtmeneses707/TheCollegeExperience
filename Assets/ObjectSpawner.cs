using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
  [SerializeField] private GameObject PlayingField;
  [SerializeField] private GameObject Breakdown;
  [SerializeField] private GameObject NewLove;
  [SerializeField] private GameObject Assignment;

  private float zPos;

  void Awake()
  {
    zPos = PlayingField.transform.position.z;
  }
  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("INSTANTIATE");
    Instantiate(Breakdown, new Vector3(0f, 0f, zPos), Quaternion.identity);
    Instantiate(NewLove, new Vector3(0f, 0f, zPos), Quaternion.identity);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
