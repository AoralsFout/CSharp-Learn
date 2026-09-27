namespace Learn.Lessons;

public class V014_foreach : ILesson
{
    public string Title => "014 foreach";

    public void Run()
    {
        int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        // foreach 是拷贝的，不能修改数组中的元素
        foreach (int item in arr)
        {
            Console.WriteLine(item);
            // item = 0;
        }
    }
}
