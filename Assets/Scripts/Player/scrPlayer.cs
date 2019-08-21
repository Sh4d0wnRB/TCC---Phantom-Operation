using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayer : MonoBehaviour
{   
    #region Variaveis de Ativação de Luz

    public bool InputadoLuz;
    public bool Acesa;
    public float couldownIncialLuz;
    public float couldownLuz;
    public GameObject Lanterna;

    #endregion

    #region Variaveis de movimento horizontal

    Rigidbody2D RigidBody;
    public float VelocidadeMaxima;
    public float EixoX;
    public float aceleraçãoX;

    #endregion

    #region Variaveis de movimento horizontal

    public float EixoY;
    public float aceleraçãoY;

    #endregion

    void Start()
    {
    	Acesa = true;
        RigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        #region Movimentação Horizontal

        aceleraçãoX = EixoX * VelocidadeMaxima;
        RigidBody.velocity = new Vector2(aceleraçãoX * Time.deltaTime, RigidBody.velocity.y);

        #endregion

        #region Movimentação Vertical

        aceleraçãoY = EixoY * VelocidadeMaxima;
        RigidBody.velocity = new Vector2(RigidBody.velocity.x, aceleraçãoY * Time.deltaTime);

        #endregion

        Debug.Log(RigidBody.velocity.x);
        Debug.Log(RigidBody.velocity.y);

        #region Ativação Luz

        if(Input.GetKeyDown(KeyCode.F) && couldownLuz <= 0)
        {
            InputadoLuz = true;
            couldownLuz = couldownIncialLuz;
        	Acesa = !Acesa;
        	Lanterna.SetActive(Acesa);

        }

        if(couldownLuz > 0)
        {
            couldownLuz -= Time.deltaTime;
        }

        #endregion
    }

    void Update()
    {
        EixoX = Input.GetAxis("Horizontal");

        EixoY = Input.GetAxis("Vertical");
    }
}
