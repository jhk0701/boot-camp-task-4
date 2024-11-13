using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node left, right;
    public Node parent;
    public RectInt rect;
    public RectInt roomRect;

    public Vector2Int center =>
        new Vector2Int(roomRect.x + roomRect.width / 2, roomRect.y + roomRect.height / 2);
    public Node(RectInt rectInfo)
    {
        rect = rectInfo;
    }
}

public class ProceduralGenerator : MonoBehaviour
{
    public GameObject block;
    
    public Vector2Int gridSize = new Vector2Int(10, 10);
    [Range(0.2f, 0.8f)] public float divideRate = 0.3f;
    [Range(0.1f, 1f)] public float minRoomSizeRandomRange = 0.5f;

    public Queue<Transform> blockQueue = new Queue<Transform>();
    
    
    public int nodeLevel = 3;

    public void Initialize(GameObject groundBlock, Vector2Int mapSize, int level)
    {
        block = groundBlock;
        gridSize = mapSize;
        nodeLevel = level;
    }
    
    [ContextMenu("Generate")]
    public IEnumerator GenerateRoutine()
    {
        Node root = new Node(new RectInt(Vector2Int.zero, gridSize));
        Divide(root, 0);
        
        yield return null;
        
        GenerateRoom(root);
        
        yield return null;
        
        GenerateRoad(root);
        
        yield return null;
    }
    
    // 분할
    void Divide(Node node, int level)
    {
        if (level == nodeLevel) 
            return;
        
        // 길이 기준 나누기
        // 길이 구하기
        int width = node.rect.width;
        int height = node.rect.height;
        
        int length = Mathf.Max(width, height);
        int divide = (int)Random.Range(length * divideRate, length * (1f - divideRate));

        if (width >= height)
        {
            // 가로 기준 나누기
            Vector2Int divLeft = new Vector2Int(divide, height);
            Vector2Int divRight = new Vector2Int(width - divide, height);
            
            node.left = new Node(
                new RectInt(
                    new Vector2Int(node.rect.x, node.rect.y),
                    divLeft)
                );
            node.right = new Node(
                new RectInt(
                    new Vector2Int(node.rect.x + divide, node.rect.y),
                    divRight)
                );
        }
        else
        {
            // 세로 기준 나누기
            Vector2Int divLeft = new Vector2Int(width, divide);
            Vector2Int divRight = new Vector2Int(width, height - divide);
            
            node.left = new Node(
                new RectInt(
                    new Vector2Int(node.rect.x, node.rect.y),
                    divLeft)
                );
            node.right = new Node(
                new RectInt(
                    new Vector2Int(node.rect.x, node.rect.y + divide),
                    divRight)
                );
        }
        
        node.left.parent = node;
        node.right.parent = node;
        Divide(node.left, level + 1);
        Divide(node.right, level + 1);
    }
    
    // 방 생성
    RectInt GenerateRoom(Node node)
    {
        RectInt rect;
        if (node.left == null || node.right == null)
        {
            rect = node.rect;
            
            GameObject obj = Instantiate(block, transform);
            obj.SetActive(true);
            int width = (int)Random.Range(rect.width * minRoomSizeRandomRange, rect.width - 2);
            int height = (int)Random.Range(rect.height * minRoomSizeRandomRange, rect.height - 2);
            int x = rect.x + Random.Range(1, rect.width - width);
            int y = rect.y + Random.Range(1, rect.height - height);
            
            obj.transform.localScale = new Vector3(width, 1, height);
            obj.transform.position = new Vector3(x, 0, y);
            rect = new RectInt(x, y, width, height);
            
            blockQueue.Enqueue(obj.transform);
        }
        else
        {
            node.left.roomRect = GenerateRoom(node.left);
            node.right.roomRect = GenerateRoom(node.right);
            rect = node.left.roomRect;
        }

        return rect;
    }

    void GenerateRoad(Node node)
    {
        if(node.left == null || node.right == null) return; // leaf 도달

        Vector2Int left = node.left.center;
        Vector2Int right = node.right.center;
        Vector3 pointLeft = new Vector3(left.x, 0, left.y);
        Vector3 pointRight = new Vector3(right.x, 0, right.y);

        GameObject obj = Instantiate(block, transform);
        obj.name = "Road";
        obj.SetActive(true);
        
        float distance = Vector2.Distance(left, right);
        obj.transform.localScale = new Vector3(2f, 1f, distance);
        obj.transform.position = Vector3.Lerp(pointLeft, pointRight, 0.5f);
        obj.transform.rotation = Quaternion.LookRotation(pointLeft - pointRight);

        GenerateRoad(node.left);
        GenerateRoad(node.right);
    }
    
}

