using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject notHero;
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject cameraObject;
    [SerializeField] private float jumpHeight;
    [SerializeField] public float speed = 10;
    [SerializeField] private float speedMultiplier = 0.75f;

    [SerializeField] private GameObject assetPoolGameObject;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletsParent;

    [SerializeField] private bool inUFO;

    //Rewind
    private bool isRewinding = false;
    private List<Rewind> allRewinds;


    private NotHeroController notHeroController;
    private HeroController heroController;
    private EnemyController enemyController;
    private UserInputController userInputController;
    private CameraController cameraController;
    private RewindController rewindController;
    private AssetPool assetPool;
    

    //Assets
    [SerializeField] private GameObject asteroidPrefab;
    private List<AstroidShower> astroidShowers;

    //PowerUps
    private SpeedBoost[] speedBoosts;



   
    void Start()
    {
        heroController = new HeroController(hero);
        notHeroController = new NotHeroController(notHero , heroController , bullet , bulletsParent);
        userInputController = new UserInputController(notHeroController , this);
        cameraController = new CameraController(cameraObject , notHero);

        speedBoosts = FindObjectsOfType<SpeedBoost>();

        foreach(SpeedBoost speedBoost in speedBoosts)
        {
            speedBoost.SetUp(this);
        }

        assetPool = new AssetPool(assetPoolGameObject , this , asteroidPrefab , FindObjectsOfType<Asteroid>());
       

        SetupRewindController();

        SetupEnemies();
    }

    
    void Update()
    {
        userInputController.Updates(speedMultiplier , rewindController , inUFO);
        notHeroController.Updates(jumpHeight , speed);
        heroController.Updates(jumpHeight , speed );
        cameraController.Updates();
        
    }

    private void FixedUpdate()
    {
       
        userInputController.FixedUpdates();
        notHeroController.FixedUpdates();
        heroController.FixedUpdates();
        rewindController.FixedUpdates();
    }

    public  void SetIsRewinding()
    {
        isRewinding = true;
    }

    private void SetupRewindController()
    {
        Rewind[] allRewindsArray = FindObjectsOfType<Rewind>();
        rewindController = new RewindController(allRewindsArray);
    }

    public GameObject InitiateAsset(GameObject asset)
    {
        return Instantiate(asset);
    }


    public void NotHeroBoost()
    {
        notHeroController.Boost();
      
    }

    private void SetupEnemies()
    {
        EnemyData[] enemyArray = FindObjectsOfType<EnemyData>();

        enemyController = new EnemyController(enemyArray);
    }

}
