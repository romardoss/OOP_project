namespace School_Schedule.Logic.TeacherFolder
{
    public class PrivateTeacher : Teacher
    {
        public string Address { get; set; }
        public int PriceOfLesson { get; set; }

        public PrivateTeacher(string name, string surname, string patronymic, 
            string phone, string address, int price, string additionalInfo) 
            : base(name, surname, patronymic, phone, additionalInfo)
        {
            Address = address;
            PriceOfLesson = price;
        }

        public override void ChangeInfo()
        {
            
        }
    }
}
