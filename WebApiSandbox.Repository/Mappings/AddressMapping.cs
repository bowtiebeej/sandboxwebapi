using NHibernate.Mapping.ByCode.Conformist;
using WebApiSandbox.Models;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSandbox.Repository.Mappings
{
    public class AddressMapping : ClassMapping<Address>
    {
        public AddressMapping()
        {
            Schema(Constants.SchemaName);
            Table("Address");
            Id(p => p.Id, map => map.Column("ADDR_ID"));

            Property(p => p.AddressType, map => map.Column("ADDR_TYPE"));
            Property(p => p.Street1, map => map.Column("ADDR_STREET1"));
            Property(p => p.Street2, map => map.Column("ADDR_STREET2"));
            Property(p => p.City, map => map.Column("ADDR_CITY"));
            Property(p => p.State, map => map.Column("ADDR_STATE"));
            Property(p => p.Zip, map => map.Column("ADDR_ZIP"));
        }
    }
}
