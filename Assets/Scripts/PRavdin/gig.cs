using UnityEngine;
using UnityEngine.UI;

public class gig: MonoBehaviour {
    [SerializeField] Button _button;

  public float MoveSpeed = 0.5f;

  public float frequency = 3.0f; // Скорость виляния по синусоиде
  public float magnitude = 0.5f; // Размер синусоиды (радиус, по сути..можно заменить на "R")

  private Vector3 axis;
  private Vector3 pos;

  void Start() {
    pos = transform.position;
    axis = transform.right;
    _button.onClick.AddListener(Gig); 
  }

  void Gig() {
    pos += transform.up * Time.deltaTime * MoveSpeed;
    transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
  }
}