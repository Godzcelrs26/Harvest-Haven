using UnityEngine;

public class StartUpUI : MonoBehaviour
{
    public void NuevaPartida() { Debug.Log("Nueva Partida"); }
    public void Continuar() { Debug.Log("Continuar"); }
    public void CargarPartida() { Debug.Log("Cargar partida"); }
    public void SalirAlEscritorio() { Application.Quit(); Debug.Log("Saliendo al escritorio..."); }
}