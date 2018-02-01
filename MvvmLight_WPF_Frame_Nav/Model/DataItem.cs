namespace MvvmLight_WPF_Frame_Nav.Model
{
    public class DataItem
    {
        public string Title
        {
            get;
            private set;
        }

        public string Screen1
        {
            get;
            set;
        }

        public string Screen2
        {
            get;
            set;
        }

        public string Screen3
        {
            get;
            set;
        }

        public DataItem(string title, string screen1, string screen2, string screen3)
        {
            Title = title;
            Screen1 = screen1;
            Screen2 = screen2;
            Screen3 = screen3;
        }
    }
}