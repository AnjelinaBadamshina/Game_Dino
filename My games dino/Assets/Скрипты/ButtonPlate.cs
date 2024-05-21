using UnityEngine;

public class ButtonPlate : MonoBehaviour
{
    private int pressed = 0; // ���������� ������������ � �������� ��� �������. �����, ����� ��������� �������������� ��������, ����� ��� ������ ������������ ������ �� ������
    public bool Pressed => pressed > 0; // ��������, ������� ����������� ���������� ���������� �� ������� - ������ ������ ��� ���

    [SerializeField] private Sprite releasedImage;
    [SerializeField] private Sprite pressedImage;

    private SpriteRenderer img;

    private void Awake()
    {
        img = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) // �������, ����� �� ������ �� ����������� ������ ��� ����������� ������
    {
        if (collision.GetComponent<MovementHero>() == null && !collision.gameObject.name.Contains("����")) // ���� ������������ �� � ���������� ��� ������, �� ������� �� �������
            return;
        
        img.sprite = pressedImage; // ������ ������ ������
        pressed++; // ����������� ���������� ������������
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MovementHero>() == null && !collision.gameObject.name.Contains("����"))
            return;

        img.sprite = releasedImage;
        pressed--;

    }
}