using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJMovimiento : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float velocidad;
    [SerializeField] float velocidaBase = 100;
    [SerializeField] float sprint;
    [SerializeField] int Stamina = 100;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moviemiento();



        void Moviemiento()
        {

            sprint = velocidaBase + velocidaBase;

            if (Input.GetKey(KeyCode.LeftShift) && Stamina != 0)
            {
                velocidad = sprint;
                Stamina = Stamina--;

                for (Stamina = 100; Stamina == 0; Stamina--)
                {
                    Debug.Log(Stamina);
                }

               
            }
            else if (!Input.GetKey(KeyCode.LeftShift ) && Stamina == 0)
            {
                velocidad = velocidaBase;
            }


            float movimientoHorizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");

            Vector2 Movimiento = new Vector2(movimientoHorizontal * velocidad, movimientoVertical * velocidad);

            rb.AddForce(Movimiento);
        }


    }
}
