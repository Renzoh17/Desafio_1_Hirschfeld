using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerPerfil;

    public void GainExperience(int newExperience)
    {
        playerPerfil.CurrentExperience += newExperience;

        if (playerPerfil.CurrentExperience >= playerPerfil.ExperienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        playerPerfil.CurrentLevel++;
        playerPerfil.CurrentExperience -= playerPerfil.ExperienceToNextLevel;
        playerPerfil.ExperienceToNextLevel += playerPerfil.ExperienceEscale; // Aumenta la experiencia necesaria para el siguiente nivel
        Jugador vidaMax = gameObject.GetComponent<Jugador>();
        vidaMax.ModificarVidaMax(10);
        // Aquí puedes agregar lógica adicional para mejorar las estadísticas del jugador, desbloquear habilidades, etc.
    }
}