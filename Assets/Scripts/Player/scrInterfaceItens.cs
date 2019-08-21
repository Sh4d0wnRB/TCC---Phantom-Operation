using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrInterfaceItens : MonoBehaviour
{
	public Camera cam;
	private Vector3 target;

	public float MoedaVelocidade;
	public GameObject Moeda;
	public GameObject Incio;
	public int Moedas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	target = cam.transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

    	Vector3 difference = target - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if(Input.GetKeyDown(KeyCode.Z) && Moedas >= 1)
        {
        	float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
            Moedas--;	
        }
    }

    void fireBullet(Vector2 direction, float rotationZ){
        GameObject b = Instantiate(Moeda) as GameObject;
        b.transform.position = Incio.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * MoedaVelocidade;
    }
}
