using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class EnemyAI : MonoBehaviour
{
    public float lookRadius = 30f;

    public float speed = 10f;
    Transform target;
    Rigidbody rig;
    public float count  = 0;
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
            rig.AddExplosionForce(11f, explosionPos, 5f, 0,ForceMode.Force);
        }
    }




    private void FixedUpdate()
    {

        if (target != null)
        {
            /* 
             Vector3 lTargetDir = target.position - transform.position;
             lTargetDir.y = 0.0f;
             transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * speed);
            */
            Quaternion OriginalRot = transform.rotation;
            transform.LookAt(target);
            Quaternion NewRot = transform.rotation;
            transform.rotation = OriginalRot;
            transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, speed * Time.deltaTime);

            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rig.AddRelativeForce(0f, 0f, 1 * speed);
           
        }
        else if(target==null )
        {
            target = randomTarget().transform;
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
        GameObject[] gos1;
        gos = GameObject.FindGameObjectsWithTag("Player");
        gos1 = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject randomObject = null;

        Vector3 position = transform.position;
        int length = gos1.Length;
        int index = Random.Range(0, length + 1);
        if (index == 0)
            randomObject = gos[0];
        else
        {
            if (gos1[index - 1] != null)
                randomObject = gos1[index - 1];
            else
                return randomTarget();
        }
            
        return randomObject;
    }



}