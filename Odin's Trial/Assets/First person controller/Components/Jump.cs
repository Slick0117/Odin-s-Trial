using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    GroundCheck groundCheck;
    Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;
    AudioSource footStepAudio;

    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (!groundCheck)
            groundCheck = GroundCheck.Create(transform);
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        footStepAudio = GetComponent<AudioSource>();
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical") && groundCheck.isGrounded && !footStepAudio.isPlaying)
        {
            footStepAudio.volume = Random.Range(0.8f, 1);
            footStepAudio.pitch = Random.Range(0.8f, 1.1f);
            footStepAudio.Play();
        }
        else if(!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") || !groundCheck.isGrounded && footStepAudio.isPlaying)
        {
            footStepAudio.Pause();
        }
    }
}
