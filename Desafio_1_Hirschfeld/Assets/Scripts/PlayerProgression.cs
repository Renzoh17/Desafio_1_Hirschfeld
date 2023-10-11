using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    public int currentLevel;
    public int currentExperience;
    [SerializeField]
    [Range(10,100)]
    public int experienceToNextLevel;
    [SerializeField]
    [Range(10,2000)]
    public int experienceEscale;

    public void GainExperience(int experience)
    {
        currentExperience += experience;

        if (currentExperience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        currentExperience -= experienceToNextLevel;
        experienceToNextLevel += experienceEscale; // Aumenta la experiencia necesaria para el siguiente nivel
        Jugador vidaMax = gameObject.GetComponent<Jugador>();
        vidaMax.ModificarVidaMax(10);
        // Aquí puedes agregar lógica adicional para mejorar las estadísticas del jugador, desbloquear habilidades, etc.
    }
}