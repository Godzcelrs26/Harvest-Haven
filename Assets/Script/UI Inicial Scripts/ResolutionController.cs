using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionController : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public List<Vector2Int> availableResolutions;
    public List<string> resolutionMessages; // Para mostrar informacion sobre la resolucion

    public Toggle pantallaCompleta;
    public Toggle Vsync;

    void Start()
    {
        // Funciona para que se cambia la resolucion cuando se selecciona una opcion del dropdown
        resolutionDropdown.onValueChanged.AddListener(delegate { ChangeResolution(); });

        // La misma mrd de arriba pero para el toggle de pantalla completa
        pantallaCompleta.onValueChanged.AddListener(delegate { PantallaCompleta(pantallaCompleta); });

        // La misma mrd de arriba pero para el VSync
        Vsync.onValueChanged.AddListener(delegate { ToggleVSync(Vsync); });

        OpcionesDeResolucion();
        SeleccionarResolucionActual();
        AsignarEstadoPantallaCompleta();
        AsignarEstadoVSync();
    }

    void OpcionesDeResolucion()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        for (int i = 0; i < availableResolutions.Count; i++)
        {
            Vector2Int res = availableResolutions[i];
            string message = i < resolutionMessages.Count ? resolutionMessages[i] : "";
            string resolution = res.x + " x " + res.y + " (" + message + ")";
            options.Add(resolution);
        }
        resolutionDropdown.AddOptions(options);
    }

    void SeleccionarResolucionActual()
    {
        Vector2Int currentResolution = new Vector2Int(Screen.width, Screen.height);
        int currentIndex = availableResolutions.IndexOf(currentResolution);

        if (currentIndex != -1)
        {
            resolutionDropdown.value = currentIndex;
            resolutionDropdown.RefreshShownValue();
        }
    }

    void AsignarEstadoPantallaCompleta()
    {
        pantallaCompleta.isOn = Screen.fullScreen;
    }

    void AsignarEstadoVSync()
    {
        Vsync.isOn = QualitySettings.vSyncCount > 0;
    }

    void ChangeResolution()
    {
        int index = resolutionDropdown.value;
        Vector2Int res = availableResolutions[index];
        Screen.SetResolution(res.x, res.y, Screen.fullScreen);
    }

    void PantallaCompleta(Toggle change)
    {
        Screen.fullScreen = change.isOn;
        Debug.Log("Pantalla completa: " + change.isOn);
    }

    void ToggleVSync(Toggle change)
    {
        QualitySettings.vSyncCount = change.isOn ? 1 : 0;
        Debug.Log("VSync: " + change.isOn);
    }
}
