using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    //PLAYER
    [Header("Configuracion")]
    [SerializeField] private float vida = 10f;
    public float Vida {get => vida; set => vida = value;}

    [SerializeField] private int vidaMaxima = 10;
    public int VidaMaxima {get => vidaMaxima; set => vidaMaxima = value;}

    //PLAYER MOVE
     // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] private float velocidad = 5f;
    public float Velocidad {get => velocidad; set => velocidad = value;}

    // Variables de uso interno en el script
    private float moverHorizontal;
    public float MoverHorizontal {get => moverHorizontal; set => moverHorizontal = value;}
    private Vector2 direccion;
    public Vector2 Direccion {get => direccion; set => direccion = value;}

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    public Rigidbody2D MiRigidbody2D {get => miRigidbody2D; set => miRigidbody2D = value;}
    private Animator miAnimator;
    public Animator MiAnimator {get => miAnimator; set => miAnimator = value;}
    private SpriteRenderer miSprite;
    public SpriteRenderer MiSprite {get => miSprite; set => miSprite = value;}
    private PolygonCollider2D miCollider2D;
    public PolygonCollider2D MiCollider2D {get => miCollider2D; set => miCollider2D = value;}

    private int saltarMask;
    public int SaltarMask {get => saltarMask; set => saltarMask = value;}

    //PLAYER JUMP
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] private float fuerzaSalto = 5f;
    public float FuerzaSalto {get => fuerzaSalto; set => fuerzaSalto = value;}
    [SerializeField] private int hyperJumps = 0;
    public int HyperJumps {get => hyperJumps; set => hyperJumps = value;}

    [SerializeField] private AudioClip jumpSFX;
    public AudioClip JumpSFX {get => jumpSFX; set => jumpSFX = value;}
    [SerializeField] private AudioClip collisionSFX;
    public AudioClip CollisionSFX {get => collisionSFX; set => collisionSFX = value;}

    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    public bool PuedoSaltar {get => puedoSaltar; set => puedoSaltar = value;}
    private bool saltando = false;
    public bool Saltando {get => saltando; set => saltando = value;}

    // Variable para referenciar otro componente del objeto
    /*private Rigidbody2D miRigidbody2D;
    public Rigidbody2D MiRigidbody2D {get => miRigidbody2D; set => miRigidbody2D = value;}*/
    private AudioSource miAudioSource;
    public AudioSource MiAudioSource {get => miAudioSource; set => miAudioSource = value;}

    //PLAYER PROGRESSION
    [SerializeField]
    private int currentLevel;
    public int CurrentLevel {get => currentLevel; set => currentLevel = value;}

    [SerializeField]
    private int currentExperience;
    public int CurrentExperience {get => currentExperience; set => currentExperience = value;}

    [SerializeField]
    [Range(10,100)]
    private int experienceToNextLevel;
    public int ExperienceToNextLevel {get => experienceToNextLevel; set => experienceToNextLevel = value;}

    [SerializeField]
    [Range(10,2000)]
    private int experienceEscale;
    public int ExperienceEscale {get => experienceEscale; set => experienceEscale = value;}

   


}
