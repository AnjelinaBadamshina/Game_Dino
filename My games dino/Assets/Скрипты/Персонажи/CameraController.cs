using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Атрибут, который требует наличия компонента Camera на объекте, к которому прикреплен этот скрипт
[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    // Сериализованные поля для указания трансформов игроков и различных параметров камеры
    [SerializeField] public Transform Player1; // Первый игрок
    [SerializeField] public Transform Player2; // Второй игрок

    private Camera camera; // Ссылка на компонент Camera
    private Vector3 startposition; // Начальное положение камеры

    // Параметры скорости движения по оси X и Y
    [SerializeField] private float speedX; // Скорость движения по оси X
    [SerializeField] private float speedY; // Скорость движения по оси Y

    // Параметры скорости изменения масштаба (ортографического размера) камеры
    [SerializeField] private float sizespeedX; // Скорость изменения масштаба камеры

    // Параметры, определяющие расстояние, на которое камера должна реагировать, чтобы начать движение
    [SerializeField] private float distanceX; // Расстояние порога по оси X
    [SerializeField] private float distanceY; // Расстояние порога по оси Y

    // Метод Awake запускается при инициализации скрипта
    private void Awake()
    {
        camera = GetComponent<Camera>(); // Получаем компонент Camera
        startposition = transform.position; // Сохраняем начальное положение камеры
    }

    // Метод Start запускается при запуске игры или сцены
    void Start()
    {
        
    }

    // Метод Update запускается каждый кадр
    void Update()
    {
        // Сглаживание движения камеры с использованием Lerp для плавного перехода
        float lerpSpeed = 3.0f; // Скорость сглаживания
        Vector3 targetPosition = new Vector3(
            Mathf.Lerp(transform.position.x, (Player1.position.x + Player2.position.x) / 2, Time.deltaTime * lerpSpeed), // Средняя позиция по оси X между игроками
            Mathf.Lerp(transform.position.y, (Player1.position.y + Player2.position.y) / 2, Time.deltaTime * lerpSpeed), // Средняя позиция по оси Y между игроками
            startposition.z // Ось Z остается неизменной
        );

        // Применяем сглаженное движение к положению камеры
        transform.position = targetPosition;

        // Логика для изменения масштаба камеры (ортографического размера) на основе расстояния между игроками
        float distanceXBetweenPlayers = Mathf.Abs(Player1.position.x - Player2.position.x); // Расстояние между игроками по оси X
        float distanceYBetweenPlayers = Mathf.Abs(Player1.position.y - Player2.position.y); // Расстояние между игроками по оси Y

        // Если расстояние между игроками больше определенного порога, увеличиваем ортографический размер (отдаляем камеру)
        if (distanceXBetweenPlayers > camera.orthographicSize * distanceX ||
            distanceYBetweenPlayers > camera.orthographicSize * distanceY)
        {
            camera.orthographicSize += Time.deltaTime * sizespeedX; // Отдаляем камеру
        }
        // Если камера отдалена больше чем нужно (более определенного минимума), уменьшаем ортографический размер
        else if (camera.orthographicSize > 5)
        {
            camera.orthographicSize -= Time.deltaTime * sizespeedX; // Приближаем камеру
        }
    }

    // Метод Reset позволяет сбросить масштаб и позицию камеры к начальным значениям
    public void Reset()
    {
        camera.orthographicSize = 5; // Сбрасываем ортографический размер камеры к начальному значению
        transform.position = startposition; // Сбрасываем позицию камеры к начальному значению
    }
}
