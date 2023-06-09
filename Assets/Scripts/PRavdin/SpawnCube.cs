using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnCube : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject prefab1;
    [SerializeField] Transform pos;


    void Start()
    {
    }

    

    // Update is called once per frame
    public void Spawn()
    {
        Instantiate(prefab1, pos.position, pos.rotation);
            }
}
