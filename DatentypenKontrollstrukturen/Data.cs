
namespace DatentypenKontrollstrukturen
{
    struct Data
    {
        public int NumberA;
        public byte NumberB;
        public string TextA;
        void Addition( int c)
        {

        }
        public Data(int a, byte b, string c)
        {
            NumberA = a;
            NumberB = b;
            TextA = c;
        }
    }

    class Structexamples
    {

        public void DoSomething()
        {
            Data b;
            b.NumberA = 4;
            b.NumberB = 2;
            b.TextA = "Hallo";
        }

    }
}
