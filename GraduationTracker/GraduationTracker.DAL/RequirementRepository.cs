using GraduationTracker.Models;

namespace GraduationTracker.DAL
{
    public class RequirementRepository : IRequirementRepository
    {
        private readonly ICourseRepository _courseRepository;

        public RequirementRepository(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        public IEnumerable<Requirement> GetRequirements()
        {
            return new[]
            {
                new Requirement
                {
                    Id = 100, 
                    //Name = "Math", 
                    MinimumMark=50, 
                    Course = _courseRepository.GetCourseByName("Math"),
                    Credits=1 
                },
                new Requirement
                {
                    Id = 102, 
                    //Name = "Science",
                    MinimumMark=50,
                    Course = _courseRepository.GetCourseByName("Science"),
                    Credits=1 
                },
                new Requirement
                {
                    Id = 103, 
                    //Name = "Literature",
                    MinimumMark=50, 
                    Course = _courseRepository.GetCourseByName("Literature"),
                    Credits=1
                },
                new Requirement
                {
                    Id = 104, 
                    //Name = "Physichal Education", 
                    MinimumMark=50, 
                    Course = _courseRepository.GetCourseByName("Physichal Education"),
                    Credits=1 
                }
            };
        }

        public Requirement GetRequirementById(int requirementId)
        {
            var requirements = GetRequirements().ToArray();
            Requirement requirement = null;

            for (int i = 0; i < requirements.Length; i++)
            {
                if (requirementId == requirements[i].Id)
                {
                    requirement = requirements[i];
                    break;
                }
            }
            return requirement;
        }
    }
}
