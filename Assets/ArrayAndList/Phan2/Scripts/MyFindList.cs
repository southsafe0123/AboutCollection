using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFindList : MonoBehaviour
{
    #region Tìm kiếm cơ bản
    /*
     //khai báo list sau đó sử dụng các hàm có sẵn trong collection để thực hiện tìm kiếm
    public List<int> numbers;
    private void Awake()
    {
        numbers = new List<int> {10,20,30,40,50};

    }

    void Start()
    {
        //trước tiên ta add thêm 30 vào cuối list 
        numbers.Add(30);

        //Tìm index đầu tiên của phần tử trong List
        int index = numbers.IndexOf(30); //kết quả là 2 vì hàm sẽ tìm phần từ 30 đầu tiên

        //Tìm index cuối cùng của phần tử trong List

        //sau đó thực hiến tìm index
        int lastIndex = numbers.LastIndexOf(30); // kết quả là 5 vì hàm sẽ tìm phần từ 30 cuối cùng

        //Kiểm tra phần tử có tồn tại trong List hay không
        bool isContain = numbers.Contains(10);

        //Tìm phần tử đầu tiên thỏa mãn điều kiện	
        int number = numbers.Find(x => x == 10);

        //Tìm tất cả các phần tử thỏa mãn điều kiện
        List<int> list = numbers.FindAll(x => x > 30);

        //Tìm index đầu tiên của phần tử thỏa mãn điều kiện
        int indexNumber = numbers.FindIndex(x => x > 20); // kết quả trả về là 2.
        int indexNumber2 = numbers.FindIndex(x => x > 500); // kết quả trả về là -1 nếu không tìm thấy số thỏa điều kiện
    }

    //tuy nhiên với một danh sách class phức tạp, cách thức tìm kiếm sẽ khác đi 1 chút
     */
    #endregion
    #region Tìm kiếm một danh sách Class
    //Trước tiên hãy tạo 1 class và khai báo list Player
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

    List<Player> players;
    void Awake()
    {
        players = new List<Player>{
            new Player("Alice", 150),
            new Player("Bob", 100),
            new Player("Charlie", 200),
            new Player("Alice", 100)
        };
    }

    void Start()
    {
        /*

         Nếu player chứa dữ liệu phức tạp hơn kết quả có thể không chính xác 
         Vì hai đối tượng khác nhau trong bộ nhớ sẽ không bằng nhau, dù thuộc tính giống hệt nhau.
          Player player = new Player("Alice", 150);
        //Tìm index đầu tiên của phần tử trong List
        int index = players.IndexOf(player);

        //Tìm index cuối cùng của phần tử trong List
        int lastIndex = players.LastIndexOf(player);

        //Kiểm tra phần tử có tồn tại trong List hay không
        bool isContain = players.Contains(player);

         */

        // cách thay thế
        //Tìm index đầu tiên của phần tử trong List
        int index = players.FindIndex(p => p.Score == 150);

        //Tìm index cuối cùng của phần tử trong List
        int lastIndex = players.FindLastIndex(p =>p.Score == 100);

        //Kiểm tra phần tử có tồn tại trong List hay không
        bool isContain = players.Exists(p => p.Score == 150);

        //Tìm phần tử đầu tiên thỏa điều kiện	
        Player playerFound = players.Find(x => x.Score == 100);

        //Tìm tất cả các phần tử thỏa mãn điều kiện
        List<Player> listFound = players.FindAll(x => x.Score > 100);

        //Tìm index đầu tiên của phần tử thỏa mãn điều kiện
        int indexPlayer = players.FindIndex(x => x.Score > 100); // kết quả trả về là 2.
        int indexNumber2 = players.FindIndex(x => x.Score > 500); // kết quả trả về là -1 nếu không tìm thấy số thỏa điều kiện

        //Kiểm tra sự tồn tại của phần tử thỏa mãn điều kiện
        bool exists = players.Exists(p => p.Name == "Volcic"); //Trả về false vì không có tên cần tìm
    }

    #endregion
}
