namespace School_Schedule.Logic.TeacherFolder
{
    public class PrivateTeacher : Teacher
    {
        public string Address { get; }
        public int PriceOfLesson { get; }

        public PrivateTeacher(string name, string surname, string patronymic, 
            string phone, string address, int price, string additionalInfo) 
            : base(name, surname, patronymic, phone, additionalInfo)
        {
            Address = address;
            PriceOfLesson = price;
        }
    }
}
