namespace UniversityManagement.Services
{
    public abstract class EntityDto
    {
        public long Id { get; set; }

        protected EntityDto()
        {
        }

        protected EntityDto(long id)
        {
            Id = id;
        }
    }
}
