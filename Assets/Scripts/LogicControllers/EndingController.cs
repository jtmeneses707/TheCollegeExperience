using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingController : MonoBehaviour
{
  [SerializeField] private int _numBreakdowns = 0;
  [SerializeField] private int _numAssignments = 0;
  [SerializeField] private int _numProjects = 0;
  [SerializeField] private int _numLoves = 0;
  [SerializeField] private bool _completed;
  [SerializeField] private string _percent;

  [SerializeField]
  private float DelayBetweenChar = 0.1f;

  [SerializeField]
  private float DelayDoneWriting = 1f;

  [SerializeField] GameObject Title;
  [SerializeField] GameObject Duration;
  [SerializeField] GameObject Breakdown;
  [SerializeField] GameObject Assignments;
  [SerializeField] GameObject NewLoves;

  private string _percentOfDegree;

  private string _breakdown;

  private string _assignments;

  private string _loves;

  // Start is called before the first frame update
  void Awake()
  {
    _numAssignments = PlayerPrefs.GetInt("Assignments");
    _numBreakdowns = PlayerPrefs.GetInt("Breakdowns");
    _numProjects = PlayerPrefs.GetInt("Projects");
    _numLoves = PlayerPrefs.GetInt("Loves");
    _completed = bool.Parse(PlayerPrefs.GetString("Completed"));
    _percent = PlayerPrefs.GetString("Percent");

    _percentOfDegree = _completed ? $"Wow that was a long time huh? You completed your degree!." : $"Nice work! You got through {_percent} of your degree.";
    _breakdown = $"School is rough. But you held it together! You suffered from {_numBreakdowns} <color=#262222>breakdowns</color>.";
    _assignments = $"Holy crap that was a lot of work for a piece of paper. You were able to juggle {_numProjects} <color=#6FA139>projects</color> and {_numAssignments} <color=#9B375C>assignments</color>.";
    _loves = $"Whether it be baking, a new anime, or partner, you found new things to love. There were {_numLoves} <color=#F7FF00>new loves</color>.";

    Duration.GetComponent<Text>().text = _percentOfDegree;
    Breakdown.GetComponent<Text>().text = _breakdown;
    NewLoves.GetComponent<Text>().text = _loves;
    Assignments.GetComponent<Text>().text = _assignments;
    NewLoves.GetComponent<Text>().text = _loves;
  }


  // public IEnumerator WriteTextToContainer(string obj)


  // public IEnumerator WriteTextToObject(string inputText)
  // {
  //   // if (DoneWriting)
  //   // {
  //   CodecTextContainer.SetActive(true);

  //   ClearText();

  //   DoneWriting = false;

  //   foreach (var ch in inputText)
  //   {
  //     TargetText.text += ch;
  //     yield return new WaitForSecondsRealtime(DelayBetweenChar);
  //   }
  //   DoneWriting = true;
  //   if (WipeScreenAfterDelay)
  //   {
  //     yield return new WaitForSecondsRealtime(DelayBeforeClear);
  //     CodecTextContainer.SetActive(false);
  //   }


  // Update is called once per frame
  void Update()
  {

  }
}
