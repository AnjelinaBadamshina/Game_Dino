using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// �������, ������� ������� ������� ���������� Camera �� �������, � �������� ���������� ���� ������
[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    // ��������������� ���� ��� �������� ����������� ������� � ��������� ���������� ������
    [SerializeField] public Transform Player1; // ������ �����
    [SerializeField] public Transform Player2; // ������ �����

    private Camera camera; // ������ �� ��������� Camera
    private Vector3 startposition; // ��������� ��������� ������

    // ��������� �������� �������� �� ��� X � Y
    [SerializeField] private float speedX; // �������� �������� �� ��� X
    [SerializeField] private float speedY; // �������� �������� �� ��� Y

    // ��������� �������� ��������� �������� (���������������� �������) ������
    [SerializeField] private float sizespeedX; // �������� ��������� �������� ������

    // ���������, ������������ ����������, �� ������� ������ ������ �����������, ����� ������ ��������
    [SerializeField] private float distanceX; // ���������� ������ �� ��� X
    [SerializeField] private float distanceY; // ���������� ������ �� ��� Y

    // ����� Awake ����������� ��� ������������� �������
    private void Awake()
    {
        camera = GetComponent<Camera>(); // �������� ��������� Camera
        startposition = transform.position; // ��������� ��������� ��������� ������
    }

    // ����� Start ����������� ��� ������� ���� ��� �����
    void Start()
    {
        
    }

    // ����� Update ����������� ������ ����
    void Update()
    {
        // ����������� �������� ������ � �������������� Lerp ��� �������� ��������
        float lerpSpeed = 3.0f; // �������� �����������
        Vector3 targetPosition = new Vector3(
            Mathf.Lerp(transform.position.x, (Player1.position.x + Player2.position.x) / 2, Time.deltaTime * lerpSpeed), // ������� ������� �� ��� X ����� ��������
            Mathf.Lerp(transform.position.y, (Player1.position.y + Player2.position.y) / 2, Time.deltaTime * lerpSpeed), // ������� ������� �� ��� Y ����� ��������
            startposition.z // ��� Z �������� ����������
        );

        // ��������� ���������� �������� � ��������� ������
        transform.position = targetPosition;

        // ������ ��� ��������� �������� ������ (���������������� �������) �� ������ ���������� ����� ��������
        float distanceXBetweenPlayers = Mathf.Abs(Player1.position.x - Player2.position.x); // ���������� ����� �������� �� ��� X
        float distanceYBetweenPlayers = Mathf.Abs(Player1.position.y - Player2.position.y); // ���������� ����� �������� �� ��� Y

        // ���� ���������� ����� �������� ������ ������������� ������, ����������� ��������������� ������ (�������� ������)
        if (distanceXBetweenPlayers > camera.orthographicSize * distanceX ||
            distanceYBetweenPlayers > camera.orthographicSize * distanceY)
        {
            camera.orthographicSize += Time.deltaTime * sizespeedX; // �������� ������
        }
        // ���� ������ �������� ������ ��� ����� (����� ������������� ��������), ��������� ��������������� ������
        else if (camera.orthographicSize > 5)
        {
            camera.orthographicSize -= Time.deltaTime * sizespeedX; // ���������� ������
        }
    }

    // ����� Reset ��������� �������� ������� � ������� ������ � ��������� ���������
    public void Reset()
    {
        camera.orthographicSize = 5; // ���������� ��������������� ������ ������ � ���������� ��������
        transform.position = startposition; // ���������� ������� ������ � ���������� ��������
    }
}
