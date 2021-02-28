using UnityEngine;
using System.Collections;
public class CarControl : MonoBehaviour
{
    public GameObject wheel;
    public static CarControl instance;

    public float speed = 90;
    public float turnSpeed = 5f;
    public float breakForce = 5f;
    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidbody;
    private bool isBreaking;


    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("ThemeSong");

    }

    void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    void FixedUpdate()
    {

        carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
        carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
        if (isBreaking)
        {
            carRigidbody.AddRelativeForce(0f, 0f, -breakForce);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Vector3 explosionPos = transform.position;
            carRigidbody.AddExplosionForce(11f, explosionPos, 5f, 0, ForceMode.Force);
            FindObjectOfType<AudioManager>().Play("Bounce");


        }
    }
}