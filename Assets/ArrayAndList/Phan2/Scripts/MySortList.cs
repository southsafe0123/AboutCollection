using System.Collections.Generic;
using UnityEngine;

public class MySortList : MonoBehaviour
{
    #region Sort cơ bản
    //có thể lướt nhanh qua phần này
    /*
     //khai báo list sau đó sử dụng các hàm có sẵn trong collection để thực hiện tìm kiếm
     public List<int> numbers;
    public List<string> names;

    private void Awake()
    {
        // Khởi tạo danh sách số và tên
        numbers = new List<int> { 50, 20, 40, 10, 30 };
    }

    private void Start()
    {
        Debug.Log("=== Sắp xếp giá trị đơn giản ===");

        // Sắp xếp số theo thứ tự tăng dần
        numbers.Sort();

        // Sắp xếp số theo thứ tự giảm dần
        numbers.Reverse();
    }

    //tuy nhiên với một danh sách class phức tạp, cách thức tìm kiếm sẽ khác đi 1 chút
     */
    #endregion
    #region Sắp xếp danh sách Class trong List<Player>

    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }

    public List<Player> players;

    private void Awake()
    {
        // Khởi tạo danh sách các đối tượng Player
        players = new List<Player>
        {
            new Player("Alice", 150),
            new Player("Bob", 100),
            new Player("Charlie", 200),
            new Player("David", 120),
            new Player("Eve", 180)
        };
    }

    private void Start()
    {
        // p1.Score.CompareTo(p2.Score) sử dụng trong sort sẽ trả về 3 giá trị
        // 1 nếu p1 > p2
        // 0 nếu p1 = p2
        // -1 nếu p1 < p2

        // Sắp xếp Player theo điểm số tăng dần
        players.Sort((p1, p2) => p1.Score.CompareTo(p2.Score));

        // Sắp xếp Player theo điểm số giảm dần
        players.Sort((p1, p2) => p2.Score.CompareTo(p1.Score));

        // Sắp xếp Player theo tên (A -> Z)
        players.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));

        // Sắp xếp Player theo tên (Z -> A)
        players.Sort((p1, p2) => p2.Name.CompareTo(p1.Name));

        // Sắp xếp Player theo điểm số tăng dần, nếu điểm bằng nhau thì sắp xếp theo tên A -> Z
        players.Sort((p1, p2) =>
        {
            int scoreComparison = p1.Score.CompareTo(p2.Score);
            if (scoreComparison == 0)
            {
                return p1.Name.CompareTo(p2.Name);
            }
            return scoreComparison;
        });
    }

    #endregion
}
