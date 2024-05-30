using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;

    [Header("Rotate")]
    public float mouseSpeed = 50f;
    float yRotation;
    float xRotation;
    Camera cam;

    [Header("Move")]
    public float moveSpeed = 3.5f;
    float h;
    float v;

    [Header("Jump")]
    public float jumpForce;

    [Header("Ground Check")]
    public float playerHeight;
    bool grounded;

    bool sitOn = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // ���콺 Ŀ���� ȭ�� �ȿ��� ����
        Cursor.visible = false;                     // ���콺 Ŀ���� ������ �ʵ��� ����

        rb = GetComponent<Rigidbody>();             // Rigidbody ������Ʈ ��������
        rb.freezeRotation = true;                   // Rigidbody�� ȸ���� �����Ͽ� ���� ���꿡 ������ ���� �ʵ��� ����

        cam = Camera.main;                          // ���� ī�޶� �Ҵ�
    }

    void Update()
    {
        Rotate();
        Move();
        run();
        sit();

        // �÷��̾��� �Ʒ� �������� ���̸� �߻��Ͽ� ����� �浹�ϴ��� Ȯ��
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f);

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Rotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseX;    // ���콺 X�� �Է¿� ���� ���� ȸ�� ���� ����
        xRotation -= mouseY;    // ���콺 Y�� �Է¿� ���� ���� ȸ�� ���� ����

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // ���� ȸ�� ���� -90������ 90�� ���̷� ����

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // ī�޶��� ȸ���� ����
        transform.rotation = Quaternion.Euler(0, yRotation, 0);             // �÷��̾� ĳ������ ȸ���� ����
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal"); // ���� �̵� �Է� ��
        v = Input.GetAxisRaw("Vertical");   // ���� �̵� �Է� ��

        // �Է¿� ���� �̵� ���� ���� ���
        Vector3 moveVec = transform.forward * v + transform.right * h;

        // �̵� ���͸� ����ȭ�Ͽ� �̵� �ӵ��� �ð� ������ ���� �� ���� ��ġ�� ����
        transform.position += moveVec.normalized * moveSpeed * Time.deltaTime;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // ���� ���� ����
    }

    void run()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 6f;
        }
        else
        {
            moveSpeed = 3.5f;
        }
    }

    void sit()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && sitOn == true)
        {
            this.gameObject.transform.localScale = new Vector3(0.8f, 0.5f, 0.8f);
            sitOn = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && sitOn == false)
        {
            this.gameObject.transform.localScale = new Vector3(0.8f, 1f, 0.8f);
            sitOn = true;
        }


    }
}
