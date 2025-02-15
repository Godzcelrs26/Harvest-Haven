using UnityEngine;
using System.Collections;

public class PJMovimiento : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float velocidad;
    [SerializeField] float velocidaBase = 100;
    [SerializeField] float sprintSpeed;
    
    //Stamina
    [SerializeField] int Stamina = 100;
    [SerializeField] int maxStamina = 100;
    [SerializeField] int recuperacionStamina = 1;
    [SerializeField] int perdidaStaminaXsprint = 1;
    [SerializeField] int tiempoRecuperacion = 1;
    [SerializeField] int tiempoPerdida = 1;

    private bool Sprinteando = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Esto es para consumir y recuperar la stamina en tiempo real (Osea en X segundos)
        StartCoroutine(ConsumirStamina());
        StartCoroutine(RecuperarStamina());
    }

    void Update()
    {
        Moviemiento();
    }

    void Moviemiento()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) && Stamina > 0)
        {
            velocidad = velocidaBase + sprintSpeed;
            Sprinteando = true;
        }
        else
        {
            velocidad = velocidaBase;
            Sprinteando = false;
        }

        Vector2 Movimiento = new Vector2(movimientoHorizontal, movimientoVertical) * velocidad;

        rb.AddForce(Movimiento);
    }

    IEnumerator ConsumirStamina()
    {
        while (true)
        {
            if (Sprinteando && Stamina > 0)
            {
                Stamina -= perdidaStaminaXsprint;
            }
            yield return new WaitForSeconds(tiempoPerdida);
        }
    }
    IEnumerator RecuperarStamina()
    {
        while (true)
        {
            if (!Sprinteando && Stamina < maxStamina)
            {
                Stamina += recuperacionStamina;
            }
            yield return new WaitForSeconds(tiempoRecuperacion);
        }
    }
}