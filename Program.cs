namespace dz9_MyString
{
    public class String
    {
        public char[] str { get; set; }
        public int length => str.Length;

        public String(char[] str)
        {
            this.str = str;
        }

        public char StartWith() => str[0];
        public char EndWith() => str[str.Length - 1];
        public char[] Substring(int startIndex, int endIndex)
        {
            int length = endIndex - startIndex + 1;
            char[] result = new char[length];
            Array.Copy(str, startIndex, result, 0, length);
            return result;
        }
        public void Remove(int startIndex, int endIndex)
        {
            int length = endIndex - startIndex + 1;
            char[] result = new char[str.Length - length];
            Array.Copy(str, 0, result, 0, startIndex);
            Array.Copy(str, endIndex + 1, result, startIndex, str.Length - endIndex - 1);
            str = result;
        }
        public void RemoveAll()
        {
            str = new char[0];
        }
        public int IndexOf(char[] search)
        {
            for (int i = 0; i <= str.Length - search.Length; i++)
            {
                bool found = true;
                for (int j = 0; j < search.Length; j++)
                {
                    if (str[i + j] != search[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Concat(char[] str1, char[] str2)
        {
            str = new char[str1.Length + str2.Length];
            Array.Copy(str1, str, str1.Length);
            Array.Copy(str2, 0, str, str1.Length, str2.Length);
        }
        public void Replace(char[] newValue)
        {
            str = newValue;
        }
        public void Replace(char[] oldValue, char[] newValue)
        {
            string strValue = new string(str);
            strValue = strValue.Replace(new string(oldValue), new string(newValue));
            str = strValue.ToCharArray();
        }
        public void Trim(char ch)
        {
            List<char> result = new List<char>();
            bool previousCharWasCh = false;
            foreach (char c in str)
            {
                if (c != ch || !previousCharWasCh)
                {
                    result.Add(c);
                }
                previousCharWasCh = (c == ch);
            }
            str = result.ToArray();
        }
        public bool CompareTo(char[] str1, char[] str2)
        {
            return new string(str1) == new string(str2);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] str = "Some text".ToCharArray();
            String myString = new String(str);

            Console.WriteLine($"Starts with: {myString.StartWith()}");
            Console.WriteLine($"Ends with: {myString.EndWith()}");
            Console.WriteLine($"Substring(3, 5): {new string(myString.Substring(3, 5))}");

            myString.Remove(1, 3);
            Console.WriteLine($"After remove(1, 3): {new string(myString.str)}");

            myString.RemoveAll();
            Console.WriteLine($"After remove all: {new string(myString.str)}");

            char[] search = "hi".ToCharArray();
            Console.WriteLine($"Index of 'hi': {myString.IndexOf(search)}");

            char[] str1 = "Hello, ".ToCharArray();
            char[] str2 = "World!".ToCharArray();
            myString.Concat(str1, str2);
            Console.WriteLine($"After concat: {new string(myString.str)}");

            char[] newValue = "Hello".ToCharArray();
            myString.Replace(newValue);
            Console.WriteLine($"After replace: {new string(myString.str)}");

            char[] oldValue = "Hello".ToCharArray();
            myString.Replace(oldValue, newValue);
            Console.WriteLine($"After replace: {new string(myString.str)}");

            char ch = ' ';
            myString.Trim(ch);
            Console.WriteLine($"After trim: {new string(myString.str)}");

            char[] str3 = "Hello".ToCharArray();
            char[] str4 = "Hello".ToCharArray();
            Console.WriteLine($"Compare 'Hello' with 'Hello': {myString.CompareTo(str3, str4)}");
        }
    }
}
