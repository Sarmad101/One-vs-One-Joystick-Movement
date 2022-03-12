using UnityEngine;

public class mover : MonoBehaviour
{
    public FixedJoystick moverJoystick;
    public Animator anim;
    private Rigidbody rb;
    public float val = 1f;
    public float jumpForce = 10f;
    public bool Grounded = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void LateUpdate()
    {
        anim.SetFloat("x", moverJoystick.Horizontal);
        anim.SetFloat("y", moverJoystick.Vertical);
        anim.SetFloat("Jump", moverJoystick.Vertical);
        if (Grounded)
        {
            
            rb.velocity = new Vector3(-moverJoystick.Horizontal * val, 0, 0);
        }
        if(moverJoystick.Vertical>0.4f && Grounded)
        {
            anim.SetFloat("Jump", 0);
            jump();
        }
       
    }
    void jump()
    {
        rb.velocity = new Vector3(-moverJoystick.Horizontal * val, jumpForce, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Grounded = true;
        }
       
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Grounded = false;
        }
    }
    public void Kick()
    {
        anim.SetTrigger("kick");
    }public void punch()
    {
        anim.SetTrigger("punch");
    }

}
