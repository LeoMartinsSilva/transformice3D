using UnityEngine;

public class Moviment : MonoBehaviour
{
    private CharacterController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            print("CharacterController found and initialized.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, -9.8f, vertical);
        controller.Move(movimento * Time.deltaTime * 5f);
    }
}
