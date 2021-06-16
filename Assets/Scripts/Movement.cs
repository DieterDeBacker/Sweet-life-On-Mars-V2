using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust;
    [SerializeField] float rotationThrust;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainThrustParticle;
    [SerializeField] ParticleSystem leftThrustParticle;
    [SerializeField] ParticleSystem rightThrustParticle;
    
    
    Rigidbody rb;
    AudioSource aSource;
    // This comment has been added to test GitHub functionality
    // This comment has been re-added to test GitHub functionality some more
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
        
        mainThrust = 700f;
        rotationThrust = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        thrustUpwards();
        thrustSideways();
    }

    void thrustUpwards(){
        //thrusting up
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StopThrusting()
    {
        // stop playing sound when not pressing space bar
        aSource.Stop();
        mainThrustParticle.Clear();
    }

    private void StartThrusting()
    {
        // play particles when thrusting upwards
        mainThrustParticle.Play();
        ApplyThrust();
        // if sound is not already playing - start playing sound
        if (!aSource.isPlaying)
        {
            aSource.PlayOneShot(mainEngine);
        }
    }

    void thrustSideways() {
        // thrusting backward
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q)){
            ApplyRotation(rotationThrust);
            //rightThrustParticle.Play();
        }
        //thrusting forward
        else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationThrust);
            //leftThrustParticle.Play();
        } else {
            //rightThrustParticle.Stop();
            //leftThrustParticle.Stop();
        }
    }

    void ApplyThrust(){
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
    }

    void ApplyRotation(float thrust){
        rb.freezeRotation = true; // freezing rotation when we manually change rotation
        transform.Rotate(Vector3.forward * thrust * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so phyisics can do their work again
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ; // freezing the x and y rotation, only z rotation allowed
    }
}
