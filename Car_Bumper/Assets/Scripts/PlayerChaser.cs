using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class PlayerChaser : MonoBehaviour
{
    public float lookRadius = 30f;
    public float speed = 5f;
    Transform target;
    Rigidbody rig;
    public float count = 0;
    bool hit;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (count == 0)
        {
            target = randomTarget().transform;
            count++;
        }


    }


    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            count = 0;
            Vector3 explosionPos = transform.position;
            rig.AddExplosionForce(10f, explosionPos, 5f, 0, ForceMode.Force);
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rig.AddRelativeForce(0f, 0f, 1 * speed);
            transform.LookAt(target);
        }
        

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

 
    public GameObject randomTarget()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject randomObject = null;
        randomObject = gos[0];
        return randomObject;
    }



}