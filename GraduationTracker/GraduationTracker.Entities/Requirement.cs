namespace GraduationTracker.Entities
{
    public class Requirement
    {
        public int Id { get; set; }

        //public string Name { get; set; }
        public Course Course { get; set; }

        public Diploma Diploma { get; set; }
    }
}
