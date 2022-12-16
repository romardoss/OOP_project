using School_Schedule.DataBase.Services;


namespace School_Schedule.Logic.TeacherFolder
{
    public abstract class Teacher
    {
        private readonly TeacherService TeacherService = new TeacherService();
        public string Name { get; set; }
        //Тут треба без сетов, бо призначення лише через конструктор, або метод ChangeInfo()
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string AdditionalInfo { get; set; }

        public Teacher(string name, string surname = "", string patronymic = "", 
            string phone = "", string additionalInfo = "")
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            PhoneNumber = phone;
            TeacherService.Add(this);
            AdditionalInfo = additionalInfo;
        }

        public abstract void ChangeInfo();

    }
}
