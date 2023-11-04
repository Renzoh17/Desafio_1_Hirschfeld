using UnityEngine;

public class PlayerProgression : MonoBehaviour
{

    private Jugador misDatos;

    private void OnEnable()
    {
        misDatos = GetComponent<Jugador>();
    }

    public void GainExperience(int newExperience)
    {
        misDatos.PlayerPerfil.CurrentExperience += newExperience;

        if (misDatos.PlayerPerfil.CurrentExperience >= misDatos.PlayerPerfil.ExperienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        misDatos.PlayerPerfil.CurrentLevel++;
        misDatos.PlayerPerfil.CurrentExperience -= misDatos.PlayerPerfil.ExperienceToNextLevel;
        misDatos.PlayerPerfil.ExperienceToNextLevel += misDatos.PlayerPerfil.ExperienceEscale; // Aumenta la experiencia necesaria para el siguiente nivel
        Jugador vidaMax = gameObject.GetComponent<Jugador>();
        vidaMax.ModificarVidaMax(10);
        // Aquí puedes agregar lógica adicional para mejorar las estadísticas del jugador, desbloquear habilidades, etc.
    }
}