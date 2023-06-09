using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroedMan : MonoBehaviour
{
    public bool isdead = false;
    public float timeRemaining = 0.1f;
    [SerializeField] private GameObject mon;
    // Переменные для хранения MeshRenderer'a сигналов светофора
    [SerializeField] MeshRenderer redLightMesh;
    // Переменные для хранения материалов
    [SerializeField] float switchingSpeed = 2f;
    // IEnumerator для смены цветов
    private IEnumerator coroutine;
    [SerializeField] Material redLightMaterial;
    [SerializeField] private GameObject[] itemsArray;
    [SerializeField] private GameObject itemsParent;

    private int _totalItems = 0;

    // Start is called before the first frame update
    void Start()
    {

        _totalItems = itemsParent.transform.childCount;

        itemsArray = new GameObject[_totalItems];

        for (int i = 0; i < _totalItems; i++)
        {
            itemsArray[i] = itemsParent.transform.GetChild(i).gameObject;
        }
        //GetComponent<Rigidbody>().isKinematic = true;
        // Присваиваем переменной coroutine, IEnumerator СhangeСolorsTrafficLight
        coroutine = СhangeСolorsTrafficLight();
        // Запускаем IEnumerator СhangeСolorsTrafficLight
        StartCoroutine(coroutine);
        //Debug.Log(Resources.Load<GameObject>("itemsArray") as GameObject);
    }
    private IEnumerator СhangeСolorsTrafficLight()
    {

        redLightMesh.material = redLightMaterial;
        yield return new WaitForSeconds(1f * switchingSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude>=5)
        {
            Destroy(gameObject);
          //  СhangeСolorsTrafficLight();
            Vector3 pos = gameObject.transform.position;
            isdead = true;
            Instantiate(mon, pos, Quaternion.identity);

            print("Cnjk");
        }
    }

     void OnCollisionExit(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }

    void Update()
    {
	Debug.Log(Resources.Load<GameObject>("mon") as GameObject);
	    if(isdead)
	    {
	      timeRemaining -= Time.deltaTime;
	      if(timeRemaining < 0)
	      {
	        Destroy(gameObject); 
	      }
	    }
    }
}