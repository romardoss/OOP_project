namespace School_Schedule.Logic.TeacherFolder
{
    public class SchoolTeacher:Teacher
    {
        public string OfficeNumber { get; set; }

        public SchoolTeacher(string name, string surname, string patronymic, 
            string phone, string officeNumber, string additionalInfo)
            : base(name, surname, patronymic, phone, additionalInfo)
        {
            OfficeNumber = officeNumber;
        }

        public override void ChangeInfo()
        {
            
        }
    }
}
