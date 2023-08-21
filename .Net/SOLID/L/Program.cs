namespace L
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Mobile mobile = new Nokia3310();

            mobile.Call();
            mobile.Text();
            ((Nokia3310)mobile).PlaySnake();

            mobile = new GalaxyS23();

            mobile.Call();
            mobile.Text();
            ((GalaxyS23)mobile).Photo();


        }


        public class Mobile
        {
            public void Call()
            {
                Console.WriteLine("the phone is calling");
            }

            public void Text()
            {
                Console.WriteLine("the phone is sending message");
            }

        }

        public interface IPhoto
        {
            void Photo();
        }

        public interface ISnake
        {
            void PlaySnake();
        }

        public class Nokia3310 : Mobile, ISnake
        {
            public void PlaySnake()
            {
                Console.WriteLine("this phone has snake game");
            }
        }

        public class GalaxyS23 : Mobile, IPhoto
        {
            public void Photo()
            {
                Console.WriteLine("this phone is able to take pictures ");
            }
        }


    }
}