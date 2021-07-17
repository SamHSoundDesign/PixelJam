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

    //Rewind
    private bool isRewinding = false;
    private List<Rewind> allRewinds;


    private NotHeroController notHeroController;
    private HeroController heroController;
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
        notHeroController = new NotHeroController(notHero , heroController);
        userInputController = new UserInputController(notHeroController , this);
        cameraController = new CameraController(cameraObject , notHero);

        speedBoosts = FindObjectsOfType<SpeedBoost>();

        foreach(SpeedBoost speedBoost in speedBoosts)
        {
            speedBoost.SetUp(this);
        }

        assetPool = new AssetPool(assetPoolGameObject , this , asteroidPrefab , FindObjectsOfType<Asteroid>());
        SetupAstroidShowers();

        SetupRewindController();
    }

    
    void Update()
    {
        userInputController.Updates(speedMultiplier , rewindController);
        notHeroController.Updates(jumpHeight , speed);
        heroController.Updates(jumpHeight , speed);
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

    private void SetupAstroidShowers()
    {
        astroidShowers = new List<AstroidShower>();

        AstroidShower[] astroidShowerArray = FindObjectsOfType<AstroidShower>();

        foreach (AstroidShower astroidShower in astroidShowerArray)
        {
            astroidShowers.Add(astroidShower);
            astroidShower.assetPool = assetPool;
        }
    }

    public GameObject InitiateAsset(GameObject asset)
    {
        return Instantiate(asset);
    }

    public void NotHeroBoost()
    {
        notHeroController.Boost();
      
    }

}
