using UnityEngine;
using UnityEngine.UI;

public class spawnObject : MonoBehaviour
{
    [SerializeField] GameObject _prefab; //Ссылка на ваш префаб
    [SerializeField]  Button _button;
     [SerializeField]  Transform _pos;

    void Start()
    {
        _button.onClick.AddListener(Spawn);
    }

   public void Spawn()
    {
         Instantiate(_prefab, _pos.position, _pos.rotation);
         Vector3 vec = new Vector3(46,46,46);
        _prefab.transform.localScale = Vector3.Lerp(vec, vec, 0);
    }
}
