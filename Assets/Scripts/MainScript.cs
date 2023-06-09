using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public bool isdead = false;
    
    public float timeRemaining = 0.1f;
    private IEnumerator coroutine;
    [SerializeField] private GameObject mon;
    [SerializeField] private GameObject goal;
    GameObject objectGoal;
    MeshRenderer redLightMesh;    
    [SerializeField] Material redLightMaterial, greenLightMaterial;
    Material monLightMaterial;
    [SerializeField] private GameObject[] itemsArray;
    [SerializeField] private GameObject itemsParent;
 
    private int _totalItems = 0;

    [SerializeField] Text scoreText;
    [SerializeField] Text scoreMissText;
    void Start()
    {
        _totalItems = itemsParent.transform.childCount;
 
        itemsArray = new GameObject[_totalItems];
 
        for(int i = 0; i < _totalItems; i++)
        {
            itemsArray[i] = itemsParent.transform.GetChild(i).gameObject;
        }
    }

    void OnCollisionEnter(Collision collision)
    {	if(collision.relativeVelocity.magnitude >= 3)
	    {
 	        Destroy(gameObject);

            objectGoal = collision.gameObject;
            if ( objectGoal == goal)
            {
                monLightMaterial = greenLightMaterial;
                //score = Convert.ToInt32(scoreText);
                Score.score++;
                scoreText.text = Score.score.ToString();
            }
            else
            {
                monLightMaterial = redLightMaterial;
                Score.scoreMiss++;
                scoreMissText.text = Score.scoreMiss.ToString();
            }

	        GetComponent<Rigidbody>().isKinematic = false;
	            foreach(GameObject i in itemsArray)
	            {
	                i.GetComponent<MeshRenderer>().material = monLightMaterial;
  	                i.GetComponent<Rigidbody>().isKinematic = false;
	            }

              Vector3 pos = gameObject.transform.position;
              isdead = true;
              Instantiate(mon,pos, Quaternion.identity);
        }
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