namespace FizzBuzzComponent
{
    public class FizzBuzz
    {
        public Dictionary<int, string> Process(int Limit)
        {
            var result = new Dictionary<int, string>();
            

            for (int i = 1; i <= Limit; i++)
            {
                string tmpStr = string.Empty;
                if (i % 3 == 0)
                {
                    tmpStr = "Fizz";
                }
                if(i % 5 == 0)
                {
                    tmpStr += "Buzz";
                }
                if(string.IsNullOrEmpty(tmpStr))
                {
                    tmpStr = i.ToString();
                }
                result.Add(i, tmpStr);
            }
            return result;
        }
    }
}
