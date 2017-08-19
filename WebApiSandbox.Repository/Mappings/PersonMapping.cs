using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using WebApiSandbox.Models;


namespace WebApiSandbox.Repository.Mappings
{
    public class PersonMap : ClassMapping<Person>
    {

        public PersonMap()
        {
            Schema(Constants.SchemaName);
            Table("Person");
            Id(x => x.Id, map => map.Column("PERSON_ID"));

            Property(x => x.FirstName, map => { map.Column("FIRST_NAME"); map.NotNullable(true); });
            Property(x => x.MiddleName, map => { map.Column("MIDDLE_NAME"); map.NotNullable(true); });
            Property(x => x.LastName, map => { map.Column("LAST_NAME"); map.NotNullable(true); });
            Property(x => x.HomePhone, map => { map.Column("HOME_PHONE"); map.NotNullable(true); });
            Property(x => x.WorkPhone, map => { map.Column("WORK_PHONE"); map.NotNullable(true); });

            Bag(x => x.Address, collectionMapping =>
            {
                collectionMapping.Table("Person_Address_Join");
                collectionMapping.Schema(Constants.SchemaName);
                collectionMapping.Cascade(Cascade.All);
                collectionMapping.Key(k => k.Column("PERSON_ID"));
                collectionMapping.Lazy(CollectionLazy.NoLazy);
            },
            map => map.ManyToMany(p =>
            {
                p.Column("ADDR_ID");
                p.NotFound(NotFoundMode.Ignore);
            })
            );
        }
    }
}

