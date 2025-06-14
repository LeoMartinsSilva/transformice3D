using UnityEngine;
using UnityEngine.Rendering;

public class Moviment : MonoBehaviour
{
    private CharacterController controller;
    private Transform camera;
    private Animator animator;
    private bool estaNoChao = true;
    [SerializeField] private Transform peDoPersonagem;
    [SerializeField] private LayerMask colisaoLayer;
    private float forcaY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        camera = Camera.main.transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0, vertical);

        movimento = camera.TransformDirection(movimento);
        movimento.y = 0;

        controller.Move(movimento * Time.deltaTime * 5f);
        if (movimento != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimento), Time.deltaTime * 10f);
        }

        animator.SetBool("Mover", movimento != Vector3.zero);

        estaNoChao = Physics.CheckSphere(peDoPersonagem.position, 0.3f, colisaoLayer);

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            forcaY = 10;
        }
        if(forcaY > -9.81f && !estaNoChao)
        {
            forcaY -= 9.81f * Time.deltaTime;
        }
        
        controller.Move(new Vector3(0, forcaY, 0) * Time.deltaTime);
    }
}
