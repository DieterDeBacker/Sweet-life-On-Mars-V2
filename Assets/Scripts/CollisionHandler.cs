using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float invokeDelay;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip succesSound;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem succesParticles;

    
    Vector3 rocketStartPos;
    Quaternion rocketRotationStart;
    Rigidbody rb;
    AudioSource aSource;

    MeshCollider meshCol;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {
        invokeDelay = 2f;

        rb = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();  
        meshCol = GetComponent<MeshCollider>();
        rocketStartPos = transform.position; 
        rocketRotationStart = Quaternion.identity;
    }

    void Update()
    {
        OnCheatKeyPressed();
    }

    void OnCollisionEnter(Collision other) {

        if(isTransitioning || collisionDisabled) { return; };

        switch(other.gameObject.tag){
        case "Friendly":
            Debug.Log("Friendly object");
            break;
        case "Finish":
            startSuccesSequence();
            break;
        default : 
             StartCrashSequence();
             break;
        }
        
    }

    void OnCheatKeyPressed(){
        // if(Input.GetKey(KeyCode.L))
        // {
        //     LoadNextLevel();
        // }
        // if(Input.GetKey(KeyCode.C))
        // {
        //     DisableEnableCollisions();
        // }
        // if(Input.GetKey(KeyCode.U))
        // {
        //    TimerController.instance.StopTimer();
        // }
        // if(Input.GetKey(KeyCode.I)){
        //     TimerController.instance.StartTimer();
        // }
        //  if(Input.GetKey(KeyCode.O)){
        //     TimerController.instance.showEndTime();
        // }
    }

    private void DisableEnableCollisions()
    {
        collisionDisabled = !collisionDisabled;
    }

    void StartCrashSequence() {
        isTransitioning = true;
        //stop current sound
        aSource.Stop();
        // removing controls from player by disabling the movement script
        GetComponent<Movement>().enabled = false;
        // Play crashing sound on crash
        aSource.PlayOneShot(crashSound, 3f);
        // Play crashing particles on crash
        crashParticles.Play();
        // reloading level on crash
        Invoke("ReloadLevelOnCrash", invokeDelay);
    }

    void startSuccesSequence() {
         isTransitioning = true;
         // removing controls from player by disabling the movement script
        GetComponent<Movement>().enabled = false;
        // play succes sound when we reach the end of level
        aSource.PlayOneShot(succesSound);
        // Play succes particles on finish
        succesParticles.Play();
        //Stop timer
        TimerController.instance.StopTimer();
        // loading next level on succes
        Invoke("LoadNextLevel", invokeDelay);
    }
    void ReloadLevelOnCrash(){
        rb.velocity = Vector3.zero; // resetting forces on rocket
        transform.position = rocketStartPos;
        transform.rotation = rocketRotationStart;
        isTransitioning = false;
        GetComponent<Movement>().enabled = true;
    }

    void LoadNextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        int totalAmountOfScenes = SceneManager.sceneCountInBuildSettings - 1;
        
        //if last scene is reached -> load first level again
        if(totalAmountOfScenes == currentSceneIndex) {
            TimerController.instance.showEndTime();

        //otherwise just load next level
        }else {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
