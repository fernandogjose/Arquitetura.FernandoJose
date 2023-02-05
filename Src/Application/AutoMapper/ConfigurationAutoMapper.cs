using AutoMapper;

namespace Application.AutoMapper
{
    public class ConfigurationAutoMapper
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new ClassAutoMapper());
            });
        }
    }
}