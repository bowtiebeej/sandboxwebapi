using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using WebApiSandbox.Repository.Mappings;


namespace WebApiSandbox.Repository
{
    internal static class ModelMapperWrapper
    {
        public static HbmMapping CompileMapping()
        {
            var modelMapper = new ModelMapper();

            modelMapper.BeforeMapClass += (mi, p, map) =>
            {
                map.DynamicInsert(true);
                map.DynamicUpdate(true);
                map.SelectBeforeUpdate(true);
            };

            modelMapper.AddMapping<AddressMapping>();

            return modelMapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}
