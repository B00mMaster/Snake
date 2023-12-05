using UnityEngine;
using System.Collections;
using UnityEditor.SceneTemplate;

public class LevelGrid
{
    private Vector2Int foodGridPosition, powerUpGridPosition;
    private GameObject foodGameObject, powerUpGameObject;

    bool hasShield;
    
    private int width;
    private int height;

    private Snake snake;

    void Start()
    {
        
    }
    IEnumerator PU()
    {
        yield return new WaitForSeconds(5);

        SpawnPowerUp();
    }
    public LevelGrid(int w, int h)
    {
        width = w;
        height = h;
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
        SpawnPowerUp();
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            Score.AddScore(Score.POINTS);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TrySnakeEatPowerUp(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == powerUpGridPosition)
        {
            Object.Destroy(powerUpGameObject);

            
            return true;
        }
        else
        {
            return false;
        }
    }

    
    private void SpawnFood()
    {
        // while (condicion){
        // cosas
        // }

        // { cosas }
        // while (condicion)

        do
        {
            foodGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(foodGridPosition) != -1);

        foodGameObject = new GameObject("Food");
        SpriteRenderer foodSpriteRenderer = foodGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = GameAssets.Instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y, 0);
    }

    void SpawnPowerUp()
    {
        do
        {
            powerUpGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(powerUpGridPosition) != -1);

        powerUpGameObject = new GameObject("PowerUp");
        SpriteRenderer powerUpSpriteRenderer = powerUpGameObject.AddComponent<SpriteRenderer>();
        powerUpSpriteRenderer.sprite = GameAssets.Instance.PowerUp;
        powerUpGameObject.transform.position = new Vector3(powerUpGridPosition.x, powerUpGridPosition.y, 0);


    }
    

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        int w = Half(width);
        int h = Half(height);
        
        // Me salgo por la derecha
        if (gridPosition.x > w)
        {
            gridPosition.x = -w;
        }
        if (gridPosition.x < -w)
        {
            gridPosition.x = w;
        }
        if (gridPosition.y > h)
        {
            gridPosition.y = -h;
        }
        if (gridPosition.y < -h)
        {
            gridPosition.y = h;
        }

        return gridPosition;
    }

    private int Half(int number)
    {
        return number / 2;
    }
}
