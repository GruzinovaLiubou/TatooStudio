using AutoMapper;

namespace Project.Logic.Mappings
{
    public class MappingConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<AccountMappingProfile>();
            });
        }
    }
}
