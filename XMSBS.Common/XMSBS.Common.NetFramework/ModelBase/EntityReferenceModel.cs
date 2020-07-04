using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.ModelBase
{
    public class EntityReferenceModel<IdType>
    {
        public IdType Id { get; set; }

        public string Name { get; set; }
        
        public EntityReferenceModel() { }

        public EntityReferenceModel(IdType id)
        {
            this.Id = id;
        }

        public EntityReferenceModel(IdType id, string name)
        {
            this.Id = id;
            this.Name = name;
        }


    }
}
