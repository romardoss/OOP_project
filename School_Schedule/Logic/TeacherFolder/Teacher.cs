using School_Schedule.DataBase.Services;


namespace School_Schedule.Logic.TeacherFolder
{
    public abstract class Teacher
    {
        private readonly TeacherService TeacherService = new TeacherService();
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        public string PhoneNumber { get; }
        public string AdditionalInfo { get; }
        public int ID { get; }

        protected static int newID = 0;
        public int NewID
        {
            get 
            {
                newID++;
                return newID;
            }
            set { }
        }


        public Teacher(string name, string surname = "", string patronymic = "", 
            string phone = "", string additionalInfo = "")
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            PhoneNumber = phone;
            TeacherService.Add(this);
            AdditionalInfo = additionalInfo;
            ID = NewID;
        }

        //public abstract void ChangeInfo();

    }
}
