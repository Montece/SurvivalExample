using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float MouseSensivity = 100f;
    [SerializeField]
    private Transform PlayerBody;

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //���������� ������� �������
        float mouseX = Input.GetAxis("Mouse X") * MouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensivity * Time.deltaTime;

        //��������� ������� ������
        xRotation -= mouseY;
        //������ ������� ���������� min, ���� f ������ min. ���� f ������ max, �� ���������� max. ����� ���������� f.
        //����������� �� ����������� ������
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //������� ����� ��� X
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
