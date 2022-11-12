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
        //Считывание позиции курсоры
        float mouseX = Input.GetAxis("Mouse X") * MouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensivity * Time.deltaTime;

        //Коррекция позиция камеры
        xRotation -= mouseY;
        //Первая функция возвращает min, если f меньше min. Если f больше max, то возвращает max. Иначе возвращает f.
        //Ограничения по перемещению камеры
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //Поворот вдоль оси X
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
