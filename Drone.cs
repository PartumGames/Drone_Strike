using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {

    public float lookSpeed = 2f;

    public float thrustForce;
    public float blastRadius;
    public float explosiveForce;
    public float upwardsModifier;

    private GameObject player;
    private float xRot = 0f;
    private float yRot = 0f;


    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
    }


    private void Update()
    {
        thrustForce += Time.deltaTime;

        xRot += lookSpeed * Input.GetAxis("Mouse X");
        yRot -= lookSpeed * Input.GetAxis("Mouse Y");

        yRot = Mathf.Clamp(yRot, 70f, 90f);

        transform.eulerAngles = new Vector3(yRot, xRot, 0f);

        transform.Translate(Vector3.forward * thrustForce);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Building" || collision.gameObject.tag == "Enemy")
        {
            Explode();
        }
    }


    private void Explode()
    {
        player.SetActive(true);

        Collider[] coll = Physics.OverlapSphere(transform.position, blastRadius);

        for (int i = 0; i < coll.Length; i++)
        {
            if (coll[i].GetComponent<Rigidbody>())
            {
                Rigidbody rb = coll[i].GetComponent<Rigidbody>();

                rb.AddExplosionForce(explosiveForce, transform.position, blastRadius, upwardsModifier, ForceMode.Impulse);
            }
        }

        Destroy(gameObject);
    }

}
