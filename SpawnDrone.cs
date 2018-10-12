using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrone : MonoBehaviour {

    public GameObject dronePrefab;
    public float spanwHeight;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {

            Vector3 pos = new Vector3(transform.position.x, spanwHeight, transform.position.z);

            Quaternion spawnRot = transform.rotation;

            GameObject go = Instantiate(dronePrefab, pos, spawnRot);

        }
    }


}
