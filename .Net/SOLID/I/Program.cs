namespace I
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var x30 = new NokiaX30();
            x30.VideoCall();
            x30.Photo();
            x30.Call();
            x30.Text();

            Console.WriteLine("");


            var nokia2700 = new Nokia2700();
            nokia2700.Photo();
            nokia2700.Text();
            nokia2700.Call();

            Console.WriteLine("");


            var nokia3310 = new Nokia3310();
            nokia3310.Call();
            nokia3310.Text();

        }

    }

    public interface IMobile
    {
        void Call();

        void Text();

    }

    public interface IPhoto
    {
        void Photo();
    }

    public interface IVideoCall
    {
        void VideoCall();
    }

    public class NokiaX30 : IMobile, IPhoto, IVideoCall
    {
        public void Call()
        {
            Console.WriteLine("This version is able to call");
        }

        public void Photo()
        {
            Console.WriteLine("this version is able to take photo");
        }

        public void Text()
        {
            Console.WriteLine("this version is able to send message");
        }

        public void VideoCall()
        {
            Console.WriteLine("this version is able to make video calls");
        }
    }

    public class Nokia3310 : IMobile
    {
        public void Call()
        {
            Console.WriteLine("This version is able to call");
        }

        public void Text()
        {
            Console.WriteLine("this version is able to send message");
        }
    }


    public class Nokia2700 : IMobile, IPhoto
    {
        public void Call()
        {
            Console.WriteLine("This version is able to call");
        }

        public void Photo()
        {
            Console.WriteLine("this version is able to take photo");
        }

        public void Text()
        {
            Console.WriteLine("this version is able to send message");
        }
    }


}