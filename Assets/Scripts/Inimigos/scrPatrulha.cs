using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPatrulha : MonoBehaviour
{
	bool POlhar;
	Rigidbody2D rbEnemy;
	public float InicialTempo;
	private float Tempo;

    public float viewRadius;
    public float viewAngle;
    public Color cor;

	public int Tamanho;
	public float Velocidade;
	public int Local;
	public Transform[] posições;

    void Start()
    {
    	rbEnemy = GetComponent<Rigidbody2D>();
    	Tempo = InicialTempo;
        Local = 0;
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, posições[Local].position, Velocidade * Time.deltaTime);

        Vector3 direction = posições[Local].position - transform.position;

        float angulo = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(POlhar)
		{
        	rbEnemy.rotation = angulo;
		}

		if(Vector2.Distance(transform.position, posições[Local].position) < 0.2f)
		{
			POlhar = false;
		}
		else
		{
			POlhar = true;
		}

        if(transform.position == posições[Local].position)
        {
        	Trocar();
        }

    }

    void Trocar()
    {
    	if(Tempo <= 0)
    	{	Local++;
    		if(Local > Tamanho)
    		{
    			Local = 0;
    		}
    		Tempo = InicialTempo;
    	}
    	else
    	{
    		Tempo -= Time.deltaTime;
    	}
    }
}
